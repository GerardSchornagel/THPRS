using System;
using System.Reflection;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace THPRS
{
    class ConfigurationManager
    {
        // Get the assembly of the current executing code
        static Assembly assembly = Assembly.GetExecutingAssembly();
        // Get the attribute's
        static AssemblyCompanyAttribute companyAttribute =
            (AssemblyCompanyAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyCompanyAttribute));
        static AssemblyProductAttribute productAttribute =
            (AssemblyProductAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyProductAttribute));
        static AssemblyFileVersionAttribute versionAttribute =
            (AssemblyFileVersionAttribute)Attribute.GetCustomAttribute(assembly, typeof(AssemblyFileVersionAttribute));

        public static Configuration CreateConfiguration()
        {
            Configuration config = new Configuration
            {
                Company = companyAttribute.Company,
                Product = productAttribute.Product,
                Version = versionAttribute.Version,
                StartupInternetAvailability = false,
                OAuthClientID = "3l7g2z9rmbpcbwbp48k1ti0lm8e3x5",
                OAuthClientSecret = "7i5i6fc8w2td6x83r6gsc00f89s3zi",
                OAuthRedirectUri = "http://localhost:3000",
                OAuthAuthorizationEndpoint = "https://id.twitch.tv/oauth2/authorize",
                OAuthTokenEndpoint = "https://id.twitch.tv/oauth2/token",
                OAuthScopeChannelModerator = false,
                OAuthScopeChatEdit = true,
                OAuthScopeChatRead = true,
                OAuthScopeModeratorReadChatters = false,
                IRCIP = "irc.chat.twitch.tv",
                IRCHost = "tmi.chat.tv",
                IRCPort = 6667,
                IRCNick = "feanoir85",
                IRCChannel = "feanoir85",
                AuthorizationCode = "",
                TokenCode = "",
                TokenRefresh = "",
                TokenExpiresAt = DateTime.Now
            };
            return config;
        }

        public static void WriteConfiguration(Configuration config, string file = "config.json")
        {
            string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);
            System.IO.File.WriteAllText(file, jsonString);
        }

        public static Configuration ReadConfiguration(string file = "config.json")
        {
            if (System.IO.File.Exists(file))
            {
                string jsonString = System.IO.File.ReadAllText(file);
                Configuration config = JsonConvert.DeserializeObject<Configuration>(jsonString);
                if (config.Company != companyAttribute.Company)
                {
                    MessageBox.Show("Invalid file");
                }
                else
                {
                    if (config.Product != productAttribute.Product)
                    {
                        MessageBox.Show("Wrong product");
                    }
                    else
                    {
                        if (config.Version != versionAttribute.Version)
                        {
                            MessageBox.Show("Wrong version, currently no back- or forth-ward compatibilty");
                        }
                        else
                        {
                            return config;
                        }
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }

    class Configuration
    {
        // Version Checking
        public string Company { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        // Startup
        public bool StartupInternetAvailability { get; set; }
        // OAuth Settings
        public string OAuthClientID { get; set; }
        public string OAuthClientSecret { get; set; }
        public string OAuthRedirectUri { get; set; }
        public string OAuthAuthorizationEndpoint { get; set; }
        public string OAuthAuthorizationScope { get; set; }
        public string OAuthTokenEndpoint { get; set; }
        public bool OAuthScopeChannelModerator { get; set; }
        public bool OAuthScopeChatEdit { get; set; }
        public bool OAuthScopeChatRead { get; set; }
        public bool OAuthScopeModeratorReadChatters { get; set; }
        // IRC Settings
        public string IRCIP { get; set; }
        public string IRCHost { get; set; }
        public int IRCPort { get; set; }
        public string IRCNick { get; set; }
        public string IRCChannel { get; set; }
        // Connection Information
        public string AuthorizationCode { get; set; }
        public string TokenCode { get; set; }
        public string TokenRefresh { get; set; }
        public DateTime TokenExpiresAt { get; set; }
    }
}