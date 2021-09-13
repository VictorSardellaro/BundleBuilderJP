using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using BundleBuilderJP.Screens.MenuScreens;
using BundleBuilderJP.Serialization;

namespace BundleBuilderJP.Services.Actions
{
    public class ActionsNP6
    {

        public static void BatExecute(int option)
        {
            var paths = Configuration.Serialization();

            try
            {
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
            }
            catch (Exception e)
            {
                if (paths.Configuration.StopBatPath == null)
                    paths.Configuration.StopBatPath = "null";
                if (paths.Configuration.ClearAllBatPath == null)
                    paths.Configuration.ClearAllBatPath = "null";
                Console.WriteLine("You cannot extract from '{0}' to '{1}' because: {2}{3}", paths.Configuration.StopBatPath, paths.Configuration.ClearAllBatPath, Environment.NewLine, e.Message);

            }

            MenuScreen.ReturnMenuScreen();
        }
        public static void BackupToDirectory(string startPathBackup, string targetZipPathBackup)
        {
            try
            {

                ZipFile.CreateFromDirectory(
                    startPathBackup,
                    targetZipPathBackup
                    + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
                    + ".zip"
                    );

                System.Console.WriteLine("Backup performed successfully");
            }
            catch (Exception e)
            {
                if (startPathBackup == null)
                    startPathBackup = "null";
                if (targetZipPathBackup == null)
                    targetZipPathBackup = "null";
                Console.WriteLine("You cannot extract from '{0}' to '{1}' because: {2}{3}", startPathBackup, targetZipPathBackup, Environment.NewLine, e.Message);

            }
            MenuScreen.ReturnMenuScreen();
        }


        public static void ExtractToDirectory(string startZipPathExtract, string targetZipPathExtract)
        {
            try
            {
                var file = Directory.GetFiles(startZipPathExtract, "*.zip", SearchOption.TopDirectoryOnly);

                string archiveName = file.ToString();

                ZipFile.ExtractToDirectory(
                    startZipPathExtract + archiveName,
                    targetZipPathExtract
                    );
            }

            catch (Exception e)
            {
                if (startZipPathExtract == null)
                    startZipPathExtract = "null";
                if (targetZipPathExtract == null)
                    targetZipPathExtract = "null";
                Console.WriteLine("You cannot extract from '{0}' to '{1}' because: {2}{3}", startZipPathExtract, targetZipPathExtract, Environment.NewLine, e.Message);
            }

            MenuScreen.ReturnMenuScreen();
        }
        public static void MergeDirectory(string startMergePath, string targetMergePath)
        {
            try
            {
                string[] files = Directory.GetFiles(startMergePath);

                foreach (string file in files)
                {
                    File.Copy(file, $"{targetMergePath}{Path.GetFileName(file)}", true);
                }

            }
            catch (Exception e)
            {
                if (startMergePath == null)
                    startMergePath = "null";
                if (targetMergePath == null)
                    targetMergePath = "null";
                Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}", startMergePath, targetMergePath, Environment.NewLine, e.Message);
            }

            MenuScreen.ReturnMenuScreen();
        }
        public static void DeleteItem(string deleteItemPath)
        {
            try
            {

                File.Delete(deleteItemPath);
                Console.WriteLine("deletion completed");

            }
            catch (Exception e)
            {
                if (deleteItemPath == null)
                    deleteItemPath = "null";

                Console.WriteLine("You cannot delete '{0}' because: {2}{3}", deleteItemPath, Environment.NewLine, e.Message);
            }

            MenuScreen.ReturnMenuScreen();
        }

    }
}

