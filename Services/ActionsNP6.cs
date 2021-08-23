using System;
using System.Diagnostics;
using System.IO.Compression;
using BundleBuilderJP.Screens.MenuScreens;
using BundleBuilderJP.Serialization;

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

            MenuScreen.ReturnMenuScreen();

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

            MenuScreen.ReturnMenuScreen();

        }

        public static void Backup()
        {
            string startPath = Configuration.Serialization()[0];
            //string startPath = @"D:\TEMP\A\Teste";

            string zipPath = Configuration.Serialization()[1] + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".zip";
            //string zipPath = @"D:\TEMP\B\BundleBackup_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".zip";

            ZipFile.CreateFromDirectory(startPath, zipPath);

            System.Console.WriteLine("Backup performed successfully");

            MenuScreen.ReturnMenuScreen();
        }

        public static void ExtractToDirectory()
        {
            string zipPath = @"D:\TEMP\B\test.zip";
            string extractPath = @"D:\TEMP\C";
            ZipFile.ExtractToDirectory(zipPath, extractPath);

            MenuScreen.ReturnMenuScreen();
        }

    }
}

