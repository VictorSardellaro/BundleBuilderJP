using System;
using System.Diagnostics;

namespace BundleBuilderJP
{
    class Program
    {
        static void Main(string[] args)
        {
            //tring sourcePath = @"c:\temp\file1.txt";
            //string targetPath = @"c:\temp\file2.txt";

            // ProcessStartInfo ps = new ProcessStartInfo();
            // ps.FileName = "cmd.exe";
            // ps.WindowStyle = ProcessWindowStyle.Normal;
            // ps.Arguments = @"/k C:\NewPOS61\2.Stop.cmd";
            // Process.Start(ps);

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
            process.Start();
            process.StandardInput.WriteLine(@"C:\NewPOS61\3.ClearAll.bat");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            System.Console.WriteLine(process.StandardOutput.ReadToEnd());
            Console.ReadKey();

        }
    }
}
