using System;
using System.Collections.Generic;
using System.Linq;
using Zusammenbauen;

namespace Zusammenbau
{
    internal class Program
    {
        private static readonly UI myUI = new UI();
        private static ConsoleKeyInfo selection;
        private static string companyName;
        private static DateTime gameDate = DateTime.Now;
        private static Company myCompany;
        private static List<Trucks> trucksOnTheMarket = new List<Trucks>();
        private static readonly List<Drivers> jobSeekingDrivers = new List<Drivers>();
        private static readonly List<Jobs> jobOffers = new List<Jobs>();
        private static readonly NameFileHandler nameHandling = new NameFileHandler();
        private static int[] maxStringLengthForTrucks = { 3, 5, 7, 10, 10, 11, 7, 5 };

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
                        PrintTrucksMarket();
                        break;

                    case '2':
                        Console.WriteLine("pressed 2");
                        //myUI.DisplayMarket("Employees");
                        break;

                    case '3':
                        Console.WriteLine("pressed 3");
                        //myUI.DisplayMarket("Jobs");
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
            CreateListOfTrucksToBuy();
            nameHandling.SplitForenameSurnameList();
            CreateListOfDriversToEmploy();
            CreateListOfJobsOffered();
        }

        private static void CreateListOfJobsOffered()
        {
            for (var i = 0; i < 8; i++)
            {
                var jobIndex = i;
                jobIndex++;
                jobOffers.Add(new Jobs(jobIndex));
            }
        }

        private static void CreateListOfDriversToEmploy()
        {
            for (var i = 0; i < 5; i++)
                jobSeekingDrivers.Add(new Drivers(nameHandling.GetRandomForename(), nameHandling.GetRandomSurname()));
        }

        private static void CreateListOfTrucksToBuy()
        {
            for (var i = 0; i < 8; i++)
            {
                var trucksIndex = i;
                trucksIndex++;
                trucksOnTheMarket.Add(new Trucks(trucksIndex));
            }
        }

        private static void PrintTrucksMarket()
        {
            var selectionIsValid = true;
            foreach (var truck in trucksOnTheMarket)
                maxStringLengthForTrucks = CalcMaxStringLengthPerColumn(maxStringLengthForTrucks,
                    truck.GetStringLengthPerColumn().ToArray());

            myUI.PrintTableHeaders(trucksOnTheMarket[0].GetHeaderStrings(), maxStringLengthForTrucks);

            foreach (var truck in trucksOnTheMarket)
                myUI.PrintTable(truck.GetPrintingList().ToArray(), maxStringLengthForTrucks);
            do
            {
                Console.WriteLine("Kaufe einen Truck mit 1-{0} oder kehre zurück mit z", trucksOnTheMarket.Count);
                selectionIsValid = true;
                selection = Console.ReadKey(true);
                var test = Convert.ToChar(trucksOnTheMarket.Count.ToString());
                if ((selection.KeyChar < '1' || selection.KeyChar > Convert.ToChar(trucksOnTheMarket.Count.ToString())) && !'z'.Equals(selection.KeyChar))
                {
                    selectionIsValid = false;
                    Console.WriteLine(("Ungültige Eingabe!"));
                    //.ReadKey(true);
                }
            } while (!selectionIsValid);

            if (!'z'.Equals(selection.KeyChar))
            {
                buyTruck(selection.KeyChar.ToString());
            }
        }

        private static void buyTruck(string selectedTruckId)
        {
            var selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId) - 1;
            myCompany.SetCompanyCash(myCompany.GetCompanyCash() - trucksOnTheMarket[selectedTruckIdAsInt].GetPrice());
            myCompany.addTruckToOwnedTrucks(trucksOnTheMarket[selectedTruckIdAsInt]);
            RemoveTruckFromMarket(selectedTruckIdAsInt);
        }

        private static void RemoveTruckFromMarket(int selectedTruckId)
        {
            trucksOnTheMarket.RemoveAt(selectedTruckId);
            UpdateTruckIds();
        }

        private static void UpdateTruckIds()
        {
            var newID = 0;
            foreach (var truck in trucksOnTheMarket)
            {
                truck.SetID(newID++);
                truck.UpdatePrintingList(0, newID);
            }
        }


        private static int[] CalcMaxStringLengthPerColumn(int[] maxStringLength, int[] stringLengthPerColumn)
        {
            for (var index = 0;
                 index < maxStringLengthForTrucks.Length;
                 index++) //für jede Anzeige prüfen, ob in der jeweiligen Spalte ein längerer String ist und gegebenenfalls aktualisieren
                if (stringLengthPerColumn[index] > maxStringLength[index])
                    maxStringLength[index] = stringLengthPerColumn[index];
            return maxStringLength;
        }
    }
}