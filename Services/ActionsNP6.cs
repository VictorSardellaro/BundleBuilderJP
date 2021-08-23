using System;
using System.Diagnostics;
using System.IO.Compression;
using BundleBuilderJP.Screens.MenuScreens;
using BundleBuilderJP.Serialization;

namespace BundleBuilderJP.Services.ActionsNP6
{
    public class ActionsNP6
    {

        public static void BatExecute(int option)
        {
            var paths = Configuration.Serialization();

            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            if (option == 1)
            {
                process.StandardInput.WriteLine(paths.Configuration.StopBatPath);
            }
            if (option == 2)
            {
                process.StandardInput.WriteLine(paths.Configuration.ClearAllBatPath);
            }
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            System.Console.WriteLine(process.StandardOutput.ReadToEnd());

            MenuScreen.ReturnMenuScreen();

        }

        public static void Backup()
        {

            var paths = Configuration.Serialization();

            ZipFile.CreateFromDirectory(
                paths.Configuration.StartPathBackup,
                paths.Configuration.TargetZipPathBackup
                + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") 
                + ".zip"
                );

            System.Console.WriteLine("Backup performed successfully");

            MenuScreen.ReturnMenuScreen();
        }

        public static void ExtractToDirectory()
        {

            var paths = Configuration.Serialization();

            ZipFile.ExtractToDirectory(
                paths.Configuration.StartZipPathExtract,
                paths.Configuration.TargetZipPathExtract
                );

            MenuScreen.ReturnMenuScreen();
        }

    }
}

