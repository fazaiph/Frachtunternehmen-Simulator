﻿using System;

namespace Zusammenbauen
{
    public class Program
    {
        private static readonly UI myUI = new UI();
        private static ConsoleKeyInfo selection;
        private static string companyName;
        public static DateTime gameDate = DateTime.Now;
        private static Company activeCompany;
        private static JobOfferMarket jobOfferMarket;
        private static DriversMarket driversMarket;
        private static TruckMarket truckMarket;
        private static readonly Businesslogic BL = new Businesslogic();

        private static void Main(string[] args)
        {
            myUI.NameSelectionScreen();
            companyName = Console.ReadLine();
            CreateGame();
            while (true) //fürs erste ne Dauerschleife, da noch nicht gefordert, das Spiel verlassen zu können
            {
                MainMenu(activeCompany);

                switch (selection.KeyChar)
                {
                    case '1':
                        truckMarket.OpenTrucksMarket(activeCompany);
                        break;

                    case '2':
                        driversMarket.OpenDriversMarket(activeCompany);
                        break;

                    case '3':
                        jobOfferMarket.OpenJobOfferMarket(activeCompany);
                        break;

                    case '4':
                        activeCompany.startAssignDriverToTruckRoutine(activeCompany);
                        break;

                    case '5':

                        break;

                    case '6':

                        break;

                    case '7':
                        EndRound();
                        break;

                    default:
                        Console.WriteLine("Ende");
                        break;
                }
            }

            Console.WriteLine("escaped");
        }

        public static void EndRound()
        {
            gameDate = gameDate.AddDays(1);
        }

        public static void MainMenu(Company activeCompany)
        {
            do
            {
                myUI.DisplayMainMenu(activeCompany, gameDate);
                selection = Console.ReadKey(true);
            } while (selection.KeyChar < '1' || selection.KeyChar > '4');
        }

        private static void CreateGame()
        {
            activeCompany = new Company(companyName);
            truckMarket = new TruckMarket();
            driversMarket = new DriversMarket();
            jobOfferMarket = new JobOfferMarket();
        }
    }
}