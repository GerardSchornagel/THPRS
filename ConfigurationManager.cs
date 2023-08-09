using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;
using THPRS;

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
                InternetAvailability = false,
                ClientID = "3l7g2z9rmbpcbwbp48k1ti0lm8e3x5",
                ClientSecret = "7i5i6fc8w2td6x83r6gsc00f89s3zi",
                RedirectUri = "http://localhost:3000",
                AuthorizationEndpoint = "https://id.twitch.tv/oauth2/authorize",
                TokenEndpoint = "https://id.twitch.tv/oauth2/token",
                ScopeChannelModerator = false,
                ScopeChatEdit = true,
                ScopeChatRead = true,
                ScopeModeratorReadChatters = false
            };
            return config;
        }

        public static void WriteConfiguration(Configuration config, string file = "config.json")
        {
            string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(file, jsonString);
        }

        public static Configuration ReadConfiguration(string file = "config.json")
        {
            if (File.Exists(file))
            {
                string jsonString = File.ReadAllText(file);
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
        public string Company { get; set; }
        public string Product { get; set; }
        public string Version { get; set; }
        public bool InternetAvailability { get; set; }
        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string AuthorizationScope { get; set; }
        public string TokenEndpoint { get; set; }
        public bool ScopeChannelModerator { get; set; }
        public bool ScopeChatEdit { get; set; }
        public bool ScopeChatRead { get; set; }
        public bool ScopeModeratorReadChatters { get; set; }
    }
}