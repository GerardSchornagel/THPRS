using System;
using System.IO;
using Newtonsoft.Json;
using THPRS;

namespace THPRS
{
    class ConfigurationManager
    {
        private static string configFilePath = "config.json";

        public static void WriteConfiguration(Configuration config)
        {
            string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(configFilePath, jsonString);
        }

        public static Configuration ReadConfiguration()
        {
            if (File.Exists(configFilePath))
            {
                string jsonString = File.ReadAllText(configFilePath);
                return JsonConvert.DeserializeObject<Configuration>(jsonString);
            }
            else
            {
                return null;
            }
        }
    }

    class Configuration
    {
        public bool InternetAvailability { get; set; }
    }
}
