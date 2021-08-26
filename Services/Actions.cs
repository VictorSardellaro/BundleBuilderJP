using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using BundleBuilderJP.Screens.MenuScreens;
using BundleBuilderJP.Serialization;

namespace BundleBuilderJP.Services.Actions
{
    public class Actions
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

        public static void BackupToDirectory()
        {
            var paths = Configuration.Serialization();

            try
            {

                ZipFile.CreateFromDirectory(
                    paths.Configuration.StartPathBackup,
                    paths.Configuration.TargetZipPathBackup
                    + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")
                    + ".zip"
                    );

                System.Console.WriteLine("Backup performed successfully");
            }
            catch (Exception e)
            {
                if (paths.Configuration.StartPathBackup == null)
                    paths.Configuration.StartPathBackup = "null";
                if (paths.Configuration.TargetZipPathBackup == null)
                    paths.Configuration.TargetZipPathBackup = "null";
                Console.WriteLine("You cannot extract from '{0}' to '{1}' because: {2}{3}", paths.Configuration.StartPathBackup, paths.Configuration.TargetZipPathBackup, Environment.NewLine, e.Message);

            }

            MenuScreen.ReturnMenuScreen();
        }


        public static void ExtractToDirectory()
        {

            var paths = Configuration.Serialization();

            try
            {
                ZipFile.ExtractToDirectory(
                    paths.Configuration.StartZipPathExtract,
                    paths.Configuration.TargetZipPathExtract
                    );
            }

            catch (Exception e)
            {
                if (paths.Configuration.StartZipPathExtract == null)
                    paths.Configuration.StartZipPathExtract = "null";
                if (paths.Configuration.TargetZipPathExtract == null)
                    paths.Configuration.TargetZipPathExtract = "null";
                Console.WriteLine("You cannot extract from '{0}' to '{1}' because: {2}{3}", paths.Configuration.StartZipPathExtract, paths.Configuration.TargetZipPathExtract, Environment.NewLine, e.Message);
            }

            MenuScreen.ReturnMenuScreen();
        }

        public static void MergeDirectory()
        {

            var paths = Configuration.Serialization();

            try
            {
                string[] files = Directory.GetFiles(paths.Configuration.StartMergePath);
                string destinationFolder = paths.Configuration.TargetMergePath;

                foreach (string file in files)
                {
                    File.Copy(file, $"{destinationFolder}{Path.GetFileName(file)}", true);
                }

                Console.WriteLine("Merge Completed");

            }
            catch (Exception e)
            {
                if (paths.Configuration.StartMergePath == null)
                    paths.Configuration.StartMergePath = "null";
                if (paths.Configuration.TargetMergePath == null)
                    paths.Configuration.TargetMergePath = "null";
                Console.WriteLine("You cannot combine '{0}' and '{1}' because: {2}{3}", paths.Configuration.StartMergePath, paths.Configuration.TargetMergePath, Environment.NewLine, e.Message);
            }

            MenuScreen.ReturnMenuScreen();
        }

        public static void DeleteItem()
        {

            var paths = Configuration.Serialization();

            try
            {
                // string[] files = Directory.GetFiles(paths.Configuration.StartMergePath);
                // string destinationFolder = paths.Configuration.TargetMergePath;

                // foreach (string file in files)
                // {
                //     File.Copy(file, $"{destinationFolder}{Path.GetFileName(file)}", true);
                // }

                File.Delete(paths.Configuration.DeleteItem);
                Console.WriteLine("deletion completed");

            }
            catch (Exception e)
            {
                if (paths.Configuration.DeleteItem == null)
                    paths.Configuration.DeleteItem = "null";

                Console.WriteLine("You cannot delete '{0}' because: {2}{3}", paths.Configuration.DeleteItem, Environment.NewLine, e.Message);
            }

            MenuScreen.ReturnMenuScreen();
        }

    }
}

