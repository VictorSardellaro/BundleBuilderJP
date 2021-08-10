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
            string startPath = @"D:\TEMP\A\Teste";
            string zipPath = @"D:\TEMP\B\test_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".zip";
            ZipFile.CreateFromDirectory(startPath, zipPath);

        }

        public static void ExtractToDirectory()
        {
            string extractPath = @"D:\TEMP\C";
            string zipPath = @"D:\TEMP\B\test.zip";
            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }

    }
}

