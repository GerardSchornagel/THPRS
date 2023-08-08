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
        internal Configuration config;

        public frmMain()
        {
            InitializeComponent();

            // Check config.json existence and create if missing, then read to memory.
            if (System.IO.File.Exists("config.json") == false)
            {
                config = new Configuration
                {
                    InternetAvailability = false
                };
                ConfigurationManager.WriteConfiguration(config);
            }
            config = ConfigurationManager.ReadConfiguration();

            if (config.InternetAvailability == false) { checkInternetAvailability(); }
        }


        public void checkInternetAvailability()
        {
            bool isNetworkAvailable = NetworkInterface.GetIsNetworkAvailable();
            bool isInternetAvailable = false;
            Dictionary<string, string> errorMessages = new Dictionary<string, string>
            {
                { "NetworkUnavailable", "Network connection is not available." },
                { "InternetUnavailable", "Internet connection is not available." },
                { "PingException", "An error occurred while trying to check internet availability." }
            };

            if (!isNetworkAvailable)
            {
                string errorMessage = errorMessages["NetworkUnavailable"];
                MessageBox.Show(errorMessage);
            }
            else
            {
                using (Ping ping = new Ping())
                {
                    try
                    {
                        PingReply reply = ping.Send("8.8.8.8"); // Google's DNS server
                        isInternetAvailable = (reply.Status == IPStatus.Success);
                    }
                    catch (PingException)
                    {
                        string errorMessage = errorMessages["PingException"];
                        MessageBox.Show(errorMessage);
                    }
                }

                if (!isInternetAvailable)
                {
                    string errorMessage = errorMessages["InternetUnavailable"];
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    config.InternetAvailability = true;
                }
            }
        }
    }
}