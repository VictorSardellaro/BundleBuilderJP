using System;
using BundleBuilderJP.Serialization;
using BundleBuilderJP.Services.Actions;

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
            System.Console.WriteLine();
            System.Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);
            System.Console.Clear();

            switch (option)
            {
                case 1:
                    Actions.BatExecute(1);
                    break;
                case 2:
                    Actions.BatExecute(2);
                    break;
                case 3:
                    Actions.BackupToDirectory();
                    break;
                case 4:
                    Actions.ExtractToDirectory();
                    break;
                case 5:
                    Actions.MergeDirectory();
                    break;
                case 6:
                    Actions.DeleteItem();
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