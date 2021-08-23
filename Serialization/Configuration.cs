using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace BundleBuilderJP.Serialization
{
    public class Configuration
    {
        public string startPathBackcup { get; set; }
        public string TargetZipPathBackup { get; set; }
        public string StartZipPathExtract { get; set; }
        public string TargetZipPathExtract { get; set; }

        public static List<BundleBuilderJP.Serialization.Configuration> Serialization()
        {
            var json = File.ReadAllText(@"D:\Repository\BundleBuilderJP\Repositories\Config.json");
            var configJson = JsonConvert.DeserializeObject<List<Configuration>>(json);

            return configJson;

        }

        public static List<string> Paths()
        {

            var configJson = Serialization();

            string startPathBackup = (configJson[0].startPathBackcup.ToString());
            string StartZipPathExtract = (configJson[0].StartZipPathExtract.ToString());
            string TargetZipPathBackup = (configJson[0].TargetZipPathBackup.ToString());
            string TargetZipPathExtract = (configJson[0].TargetZipPathExtract.ToString());

            List<string> ConfigPaths = new List<string>();
            ConfigPaths.Add(startPathBackup);
            ConfigPaths.Add(StartZipPathExtract);
            ConfigPaths.Add(TargetZipPathBackup);
            ConfigPaths.Add(TargetZipPathExtract);

            return ConfigPaths;

        }
    }
}
