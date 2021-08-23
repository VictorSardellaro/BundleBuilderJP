using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BundleBuilderJP.Serialization
{
    public class Configuration
    {
        public string StartPathBackup { get; set; }
        public string TargetZipPathBackup { get; set; }
        public string StartZipPathExtract { get; set; }
        public string TargetZipPathExtract { get; set; }
        public string StopBatPath { get; set; }
        public string ClearAllBatPath { get; set; }


        public static ConfigurationJson Serialization()
        {
            var json = File.ReadAllText(@"D:\Repository\BundleBuilderJP\Repositories\Config.json");
            var configJson = JsonConvert.DeserializeObject<ConfigurationJson>(json);
            

            return configJson;

        }

        public class ConfigurationJson
        {
            public Configuration Configuration { get; set; }

        }
    }
}
