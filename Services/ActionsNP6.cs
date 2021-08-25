using System;
using System.Diagnostics;
using System.IO;
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

        public static void BackupToDirectory()
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

        private static void MergeDirectory()
        {

            var paths = Configuration.Serialization();

            try
            {
                string combination = Path.Combine(paths.Configuration.StartMergePath, paths.Configuration.TargetMergePath);

                //Console.WriteLine("When you combine '{0}' and '{1}', the result is: {2}'{3}'", p1, p2, Environment.NewLine, combination);
            }
            catch (Exception e)
            {
                if (paths.Configuration.StartMergePath == null)
                    paths.Configuration.StartMergePath = "null";
                if (paths.Configuration.TargetMergePath == null)
                    paths.Configuration.TargetMergePath = "null";
                Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}", paths.Configuration.StartMergePath, paths.Configuration.TargetMergePath, Environment.NewLine, e.Message);
            }

            Console.WriteLine();
        }

    }
}

