using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THPRS
{
    public partial class frmMain : Form
    {
        internal static Configuration config;

        static string listenerFunction = "IDLE";
        Queue<string> queueIRC = new Queue<string>();

        public TcpClient tcpIRC;
        public StreamReader readerIRC;
        public StreamWriter writerIRC;

        public frmMain()
        {
            InitializeComponent();

            // Check config.json existence and create if missing, then read to memory.
            if (File.Exists("config.json") == false)
            {
                config = ConfigurationManager.CreateConfiguration();
                ConfigurationManager.WriteConfiguration(config);
            }
            config = ConfigurationManager.ReadConfiguration();
        }

        public void CheckInternetAvailability()
        {
            bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            bool isInternetAvailable = false;

            if (!isNetworkAvailable)
            {
                MessageBox.Show("Network connection is not available.");
            }
            else
            {
                using (Ping ping = new Ping())
                {
                    try
                    {
                        PingReply reply = ping.Send("8.8.8.8");
                        isInternetAvailable = (reply.Status == IPStatus.Success);
                    }
                    catch (PingException)
                    {
                        MessageBox.Show("An error occurred while trying to check internet availability.");
                    }
                }

                if (!isInternetAvailable)
                {
                    MessageBox.Show("Internet connection is not available.");
                }
                else
                {
                    config.StartupInternetAvailability = true;
                }
            }
        }

        private void TmrRefreshToken_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > config.TokenExpiresAt)
            {
                ConnectionManager.OauthRefreshRequest(config);
            }
        }

        private void MenuFileConnect_Click(object sender, EventArgs e)
        {
            // Check internet connectivity
            if (config.StartupInternetAvailability == false) { MessageBox.Show("Click OK to retry getting internet access. Make sure your firewall is configured correctly."); CheckInternetAvailability(); }

            // Check ExpiryAt on prev. OAth token, when expired request new token
            if (DateTime.Now > config.TokenExpiresAt)
            {
                ConnectionManager.OauthAuthorizationRequest(config);
                ConnectionManager.OauthTokenRequest(config);
            }
            tmrRefreshToken.Enabled = true;

            // Connect to IRC
            tcpIRC = new TcpClient();
            tcpIRC.Connect(config.IRCIP, config.IRCPort);
            readerIRC = new StreamReader(tcpIRC.GetStream()) { };
            writerIRC = new StreamWriter(tcpIRC.GetStream()) { NewLine = "\r\n", AutoFlush = true };

            listenerFunction = "IDLE";
            ListenerIRC();
            QueueParser();
        }

        private void MenuOptionsSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings(config);
            frmSettings.ShowDialog();
        }

        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            try { writerIRC.WriteLine($"PART #{config.IRCChannel}"); writerIRC.Flush(); } catch (Exception) { }
            Thread.Sleep(250);
            try { tcpIRC.Close(); } catch (Exception) { }
            Thread.Sleep(250);
            try { readerIRC.Close(); } catch (Exception) { }
            try { writerIRC.Close(); } catch (Exception) { }
            Thread.Sleep(250);
            Close();
        }

        private void MenuFileDefault_Click(object sender, EventArgs e)
        {
            config = ConfigurationManager.CreateConfiguration();
            ConfigurationManager.WriteConfiguration(config);
            config = ConfigurationManager.ReadConfiguration();

            CheckInternetAvailability();
        }

        private void MenuFileExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportFile = new SaveFileDialog();
            exportFile.Filter = "THPRS file|*.profile";
            exportFile.AddExtension = true;
            exportFile.DefaultExt = exportFile.Filter;
            exportFile.OverwritePrompt = true;
            exportFile.Title = "Export Profile...";
            exportFile.ShowDialog();

            ConfigurationManager.WriteConfiguration(config, exportFile.FileName);
        }

        private void MenuFileImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog importFile = new OpenFileDialog();
            importFile.Filter = "THPRS file|*.profile";
            importFile.DefaultExt = importFile.Filter;
            importFile.Title = "Import Profile...";
            importFile.ShowDialog();

            Configuration configImport;
            configImport = ConfigurationManager.ReadConfiguration(importFile.FileName);
            if (configImport != null)
            {
                config = configImport;
                ConfigurationManager.WriteConfiguration(config);
            }
        }

        private void BtnParticipantsClear_Click(object sender, EventArgs e)
        {
            chklistParticipants.Items.Clear();
        }

        async Task ListenerIRC()
        {
            string channel = config.IRCChannel;

            await writerIRC.WriteLineAsync($"PASS oauth:{config.TokenCode}");
            await writerIRC.WriteLineAsync($"NICK {config.IRCNick}");
            await writerIRC.WriteLineAsync($"JOIN #{channel}");

            while (true)
            {

                string line = await readerIRC.ReadLineAsync();
                if (line != null)
                {
                    if (line.StartsWith("PING")) //PING :tmi.twitch.tv
                    {
                        await writerIRC.WriteLineAsync($"PONG :{config.IRCHost}"); //Respond with PONG :tmi.twitch.tv
                    }
                    else if (line.StartsWith(":tmi.twitch.tv NOTICE * :Login authentication failed"))
                    {
                        MessageBox.Show("--Login authentication failed, OAuth is expired. Reconnect to acquire a new one.--");
                        listenerFunction = "IDLE";
                        break;
                    }
                    else
                    {
                        queueIRC.Enqueue(line);
                    }
                }
                else { continue; }
            }
        }

        async Task QueueParser()
        {
            string channel = config.IRCChannel;
            string line = "";
            string msg = "";
            string name = "";

            while (true)
            {
                // Always running Functions
                switch (listenerFunction)
                {
                    case "IDLE":
                        break;
                    case "EXIT":
                        await writerIRC.WriteLineAsync($"PART #{channel}");
                        tcpIRC.Close();
                        readerIRC.Close();
                        writerIRC.Close();
                        break;
                    case "KEYWORD_STOP":
                        listenerFunction = "IDLE";
                        await writerIRC.WriteLineAsync($"PRIVMSG #{channel} :--STOPPED LISTENING--");
                        break;
                    default:
                        break;
                }

                // No queue = skip all after 0.5s pause
                if (queueIRC.Count == 0)
                {
                    await Task.Delay(500);
                    continue;
                }

                line = queueIRC.Dequeue();
                txtboxLog.Text += line + "\r\n";

                // Functions for incoming lines.
                switch (listenerFunction)
                {
                    case "KEYWORD_START":
                        msg = (line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[1]).ToUpper();
                        name = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)[0];
                        name = name.Split(new char[] { '!' }, StringSplitOptions.RemoveEmptyEntries)[0];
                        if (msg.Contains(txtboxTriggerword.Text.ToUpper()))
                        {
                            if (chklistParticipants.Items.Contains(name) == false)
                            {
                                chklistParticipants.Items.Add(name, true);
                                await writerIRC.WriteLineAsync($"PRIVMSG #{channel} :@{name} you're in!");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void BtnDraw_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            String[] participants;
            String[] winners;
            int drawings = decimal.ToInt32(nudReceivers.Value);
            winners = new String[drawings];

            participants = new String[chklistParticipants.CheckedItems.Count];

            for (int i = 0; i < participants.Count(); i++)
            {
                participants[i] = chklistParticipants.CheckedItems[i].ToString();
            }

            for (int i = 0; i < drawings; i++)
            {
                string winner = participants[rnd.Next(participants.Count())].ToString();
                if (winners.Contains(winner) == false)
                {
                    winners[i] = winner;
                    writerIRC.WriteLineAsync($"PRIVMSG #{config.IRCChannel} :@{winner} has been drawn as #{i + 1}");
                }
                else { i--; }
            }
        }

        private void ToolDevSend_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                writerIRC.WriteLineAsync(toolDevSend.Text);
                toolDevSend.Text = $"PRIVMSG #{config.IRCChannel} :";
            }
        }

        private void BtnKeywordStop_Click(object sender, EventArgs e)
        {
            listenerFunction = "KEYWORD_STOP";
        }

        private void BtnKeywordStart_Click(object sender, EventArgs e)
        {
            listenerFunction = "KEYWORD_START";
        }

        private void BtnIDLE_Click(object sender, EventArgs e)
        {
            listenerFunction = "IDLE";
        }

        private void BtnEXIT_Click(object sender, EventArgs e)
        {
            listenerFunction = "EXIT";
        }

        private void TmrStatusbar_Tick(object sender, EventArgs e)
        {
            statusLabel.Text = listenerFunction;
            try
            {
                if (tcpIRC.Client.Connected)
                {
                    statusConnection.Text = "Connected";
                    statusConnection.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception)
            {
                statusConnection.Text = "Disconnected";
                statusConnection.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}