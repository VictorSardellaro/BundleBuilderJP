using System;
using BundleBuilderJP.Services.ActionsNP6;

namespace BundleBuilderJP.Screens.MenuScreens
{
    public class MenuScreen
    {

        public static void MainScreen()
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
            System.Console.WriteLine();
            System.Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ActionsNP6.Clear();
                    break;
                case 2:
                    ActionsNP6.Stop();
                    break;
                case 3:
                    ActionsNP6.Backup();
                    break;
                case 4:
                    ActionsNP6.ExtractToDirectory();
                    break;

                default: MainScreen(); break;
            }
        }

    }
}