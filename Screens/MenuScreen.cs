using System;
using BundleBuilderJP.Serialization;
using BundleBuilderJP.Services.Actions;
using BundleBuilderJP.Services.BundleBuilder;

namespace BundleBuilderJP.Screens.MenuScreens
{
    public class MenuScreen
    {

        public static void LoadMenu()
        {
            System.Console.Clear();
            System.Console.WriteLine("Bundle Builder Tools");
            System.Console.WriteLine("------------------");
            System.Console.WriteLine("Chose an option");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Stop NP6");
            System.Console.WriteLine("2 - Clear NP6");
            System.Console.WriteLine("3 - Backup Bundle");
            System.Console.WriteLine("4 - Zip Bundle");
            System.Console.WriteLine("5 - Merge Bundle");
            System.Console.WriteLine("6 - Exclude Item");
            System.Console.WriteLine("9 - Bundle Builder");

            System.Console.WriteLine();
            System.Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);
            System.Console.Clear();

            var paths = Configuration.Serialization();

            string startPathBackup = paths.Configuration.StartPathBackup;
            string targetZipPathBackup = paths.Configuration.TargetZipPathBackup;
            string startZipPathExtract = paths.Configuration.StartZipPathExtract;
            string targetZipPathExtract = paths.Configuration.TargetZipPathExtract;
            string startMergePath = paths.Configuration.StartMergePath;
            string targetMergePath = paths.Configuration.TargetMergePath;
            string deleteItemPath = paths.Configuration.DeleteItemPath;

            switch (option)
            {
                case 1:
                    ActionsNP6.BatExecute(1);
                    break;
                case 2:
                    ActionsNP6.BatExecute(2);
                    break;
                case 3:
                    ActionsNP6.BackupToDirectory(startPathBackup, targetZipPathBackup);
                    break;
                case 4:
                    ActionsNP6.ExtractToDirectory(startZipPathExtract, targetZipPathExtract);
                    break;
                case 5:
                    ActionsNP6.MergeDirectory(startMergePath, targetMergePath);
                    break;
                case 6:
                    ActionsNP6.DeleteItem(deleteItemPath);
                    break;
                case 9:
                    Bundle.BuilderNP6();
                    break;

                default: LoadMenu(); break;
            }


        }

        public static void ReturnMenuScreen()
        {
            System.Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            MenuScreen.LoadMenu();
        }

    }
}