using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using BundleBuilderJP.Screens.MenuScreens;
using BundleBuilderJP.Serialization;
using Newtonsoft.Json;

namespace BundleBuilderJP.Services.ActionsNP6
{
    public class ActionsNP6
    {

        public static void Stop()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine(@"C:\NewPOS61\2.Stop.cmd");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            System.Console.WriteLine(process.StandardOutput.ReadToEnd());

            ReturnMenuScreen();

        }

        public static void Clear()
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.StandardInput.WriteLine(@"C:\NewPOS61\3.ClearAll.bat");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            System.Console.WriteLine(process.StandardOutput.ReadToEnd());

            ReturnMenuScreen();

        }

        public static void Backup()
        {
            Serialization();

            string startPath = @"D:\TEMP\A\Teste";
            string zipPath = @"D:\TEMP\B\BundleBackup_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".zip";
            ZipFile.CreateFromDirectory(startPath, zipPath);

            System.Console.WriteLine("Backup performed successfully");

            ReturnMenuScreen();
        }

        public static void ExtractToDirectory()
        {
            string zipPath = @"D:\TEMP\B\test.zip";
            string extractPath = @"D:\TEMP\C";
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            ReturnMenuScreen();
        }

        public static void ReturnMenuScreen()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MenuScreen.LoadMenu();
        }


        public static void Serialization()
        {
            var json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\Repositories\Config.json");

            // @"D:\Repository\BundleBuilderJP\Repositories\Config.json"
            // AppDomain.CurrentDomain.BaseDirectory + 

            var configJson = JsonConvert.DeserializeObject<List<Configuration>>(json);

            string startPathBackup = (configJson[0].startPathBackcup.ToString());
            string StartZipPathExtract = (configJson[0].StartZipPathExtract.ToString());
            string TargetZipPathBackup = (configJson[0].TargetZipPathBackup.ToString());
            string TargetZipPathExtract = (configJson[0].TargetZipPathExtract.ToString());

        }


    }
}

