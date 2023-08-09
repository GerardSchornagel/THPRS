using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace THPRS
{
    public partial class frmMain : Form
    {
        internal static Configuration config;
        internal static Connection connect = new Connection();

        public frmMain()
        {
            InitializeComponent();

            statusProgress.Value = 0;
            statusLabel.Text = "Check for config.json";
            // Check config.json existence and create if missing, then read to memory.
            if (System.IO.File.Exists("config.json") == false)
            {
                config = ConfigurationManager.CreateConfiguration();

                statusProgress.Value = 33;
                statusLabel.Text = "Creating ../config.json";
                ConfigurationManager.WriteConfiguration(config);
            }

            statusProgress.Value = 66;
            statusLabel.Text = "Reading config.json";
            config = ConfigurationManager.ReadConfiguration();

            statusProgress.Value = 100;
            statusLabel.Text = "Configuration file loaded";
            if (config.InternetAvailability == false) { checkInternetAvailability(); }
        }

        public void checkInternetAvailability()
        {
            bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            bool isInternetAvailable = false;

            statusProgress.Value = 0;
            statusLabel.Text = "Testing network connection";
            if (!isNetworkAvailable)
            {
                statusLabel.Text = "Network connection error";

                MessageBox.Show("Network connection is not available.");
            }
            else
            {
                statusProgress.Value = 33;
                statusLabel.Text = "Pinging 8.8.8.8";
                using (Ping ping = new Ping())
                {
                    try
                    {
                        PingReply reply = ping.Send("8.8.8.8");
                        isInternetAvailable = (reply.Status == IPStatus.Success);
                    }
                    catch (PingException)
                    {
                        statusLabel.Text = "Ping to Google DNS failed";
                        MessageBox.Show("An error occurred while trying to check internet availability.");
                    }
                }

                statusProgress.Value = 66;
                statusLabel.Text = "Testing internet connection";
                if (!isInternetAvailable)
                {
                    statusLabel.Text = "Internet connection error";

                    MessageBox.Show("Internet connection is not available.");
                }
                else
                {
                    config.InternetAvailability = true;
                    statusProgress.Value = 100;
                    statusLabel.Text = "Internet access detected";
                }
            }
        }

        private void tmrRefreshToken_Tick(object sender, EventArgs e)
        {
            ConnectionManager.oauthRefreshRequest(config, connect, statusLabel, statusProgress, statusConnection);
            tmrRefreshToken.Interval = (int.Parse(connect.tokenExpiresIn) * 1000) - 1000;
        }

        private void menuFileConnect_Click(object sender, EventArgs e)
        {
            if (config.InternetAvailability == false) { MessageBox.Show("Click OK to retry getting internet access. Make sure your firewall is configured correctly."); checkInternetAvailability(); }

            statusConnection.Text = "Disconnected";
            statusConnection.ForeColor = System.Drawing.Color.Red;

            statusLabel.Text = "Connecting to Twitch; Authorization Request";
            statusProgress.Value = 0;
            ConnectionManager.oauthAuthorizationRequest(config, connect, statusLabel, statusProgress);

            statusLabel.Text = "Connecting to Twitch; Token Request";
            ConnectionManager.oauthTokenRequest(config, connect, statusLabel, statusProgress);

            statusConnection.Text = "Connected";
            statusConnection.ForeColor = System.Drawing.Color.Green;

            tmrRefreshToken.Interval = (int.Parse(connect.tokenExpiresIn) * 1000) - 1000;
            tmrRefreshToken.Enabled = true;
        }

        private void menuOptionsSettings_Click(object sender, EventArgs e)
        {
            frmSettings frmSettings = new frmSettings(config);
            frmSettings.ShowDialog();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuFileDefault_Click(object sender, EventArgs e)
        {
            statusProgress.Value = 0;
            statusLabel.Text = "Loading Default Profile";
            config = ConfigurationManager.CreateConfiguration();

            statusProgress.Value = 33;
            statusLabel.Text = "Creating ../config.json";
            ConfigurationManager.WriteConfiguration(config);

            statusProgress.Value = 66;
            statusLabel.Text = "Reading config.json";
            config = ConfigurationManager.ReadConfiguration();

            statusProgress.Value = 100;
            statusLabel.Text = "Default Profile Applied";

            checkInternetAvailability();
        }

        private void menuFileExport_Click(object sender, EventArgs e)
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

        private void menuFileImport_Click(object sender, EventArgs e)
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
    }
}