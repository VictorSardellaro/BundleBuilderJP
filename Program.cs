﻿using System;
using BundleBuilderJP.Services.ActionsNP6;

namespace BundleBuilderJP
{
    class Program
    {
        static void Main(string[] args)
        {

            Load();
            Console.ReadKey();
        }

        private static void Load()
        {
            System.Console.Clear();
            System.Console.WriteLine("Bundle Builder");
            System.Console.WriteLine("------------------");
            System.Console.WriteLine("Chose an option");
            System.Console.WriteLine();
            System.Console.WriteLine("1 - Stop NP6");
            System.Console.WriteLine("2 - Clear NP6");
            System.Console.WriteLine("3 - Backup Bundle");
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

                default: Load(); break;
            }
        }
    }
}

