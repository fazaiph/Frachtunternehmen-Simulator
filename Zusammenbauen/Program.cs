using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class Program
    {
        private static readonly UI myUI = new UI();
        private static ConsoleKeyInfo selection;
        private static string companyName;
        private static DateTime gameDate = DateTime.Now;
        private static Company myCompany;
        private static readonly List<Drivers> jobSeekingDrivers = new List<Drivers>();
        private static readonly NameFileHandler nameHandling = new NameFileHandler();
        private static JobOfferMarket jobOfferMarket;
        private static EmployeeMarket employeeMarket;
        private static TruckMarket truckMarket;

        private static void Main(string[] args)
        {
            myUI.NameSelectionScreen();
            companyName = Console.ReadLine();
            CreateGame();
            while (true) //für's erste ne Dauerschleife, da nochnicht gefordert, das Spiel verlassen zu können
            {
                MainMenu(myCompany);

                switch (selection.KeyChar)
                {
                    case '1':
                        truckMarket.OpenTrucksMarket(myCompany);
                        break;

                    case '2':
                        Console.WriteLine("pressed 2");
                        //myUI.DisplayMarket("Employees");
                        break;

                    case '3':
                        Console.WriteLine("pressed 3");
                        //myUI.DisplayMarket("Job");
                        break;

                    case '4':
                        //Console.WriteLine("In Branch 4");
                        gameDate = gameDate.AddDays(1);
                        break;

                    default:
                        Console.WriteLine("Ende");
                        break;
                }
            }

            Console.WriteLine("escaped");
        }

        public static void MainMenu(Company myCompany)
        {
            do
            {
                myUI.DisplayMainMenu(myCompany, gameDate);
                selection = Console.ReadKey(true);
            } while (selection.KeyChar < '1' || selection.KeyChar > '4');
        }

        private static void CreateGame()
        {
            myCompany = new Company(companyName);
            truckMarket = new TruckMarket();
            employeeMarket = new EmployeeMarket();
            jobOfferMarket = new JobOfferMarket();
            nameHandling.SplitForenameSurnameList();
            CreateListOfDriversToEmploy();
        }

        private static void CreateListOfDriversToEmploy()
        {
            for (var i = 0; i < 5; i++)
                jobSeekingDrivers.Add(new Drivers(nameHandling.GetRandomForename(), nameHandling.GetRandomSurname()));
        }
    }
}