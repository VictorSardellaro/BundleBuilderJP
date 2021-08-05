using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;



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

        }

        public static void Backup()
        {
            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";
            try
            {
                File.Copy(sourcePath, targetPath);
                string[] lines = File.ReadAllLines(sourcePath);
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }

        public static void Zip()
        {

            string startPath = @"D:\TEMP\A\Teste";
            string zipPath = @"D:\TEMP\B";
            string extractPath = @"D:\TEMP\C";

            ZipFile.CreateFromDirectory(startPath, zipPath);
            ZipFile.ExtractToDirectory(zipPath, extractPath);

        }
    }
}

