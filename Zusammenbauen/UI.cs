using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class UI
    {
        private static readonly UIpreparator Uiprep = new UIpreparator();

        public void PrintTableHeaders(string[] marketTypeSpecificStrings, int[] maxLengthPerColumn)
        {
            for (var index = 0; index < marketTypeSpecificStrings.Length; index++)
            {
                Console.Write("|");
                Console.Write(marketTypeSpecificStrings[index].PadRight(maxLengthPerColumn[index]));
            }

            Console.WriteLine("|");

            for (var index = 0; index < marketTypeSpecificStrings.Length; index++)
            {
                Console.Write("+");
                for (var i = 0; i < maxLengthPerColumn[index]; i++) Console.Write("-");
            }

            Console.WriteLine("+");
        }

        public void PrintTable(string[] stringsToPrint, int[] maxLengthPerColumn)
        {
            for (var index = 0; index < stringsToPrint.Length; index++)
            {
                Console.Write("| ");
                Console.Write(stringsToPrint[index].PadRight(maxLengthPerColumn[index] - 1));
            }

            Console.WriteLine("|");
        }

        public void DisplayMainMenu(Company company, DateTime date)
        {
            Console.Clear();
            DisplayOverviewHeader(company, date);
            Console.WriteLine("1.LKW kaufen");
            Console.WriteLine("2.Fahrer einstellen");
            Console.WriteLine("3.Auftrag annehmen");
            Console.WriteLine("4.Fahrer zu LKW zuordnen");
            Console.WriteLine("5.LKW bewegen");
            Console.WriteLine("6.Angenommene Aufträge ausführen");
            Console.WriteLine("7.Runde beenden");
        }

        public void NameSelectionScreen()
        {
            Console.WriteLine("Bitte geben Sie einen Namen für ihre Firma ein:");
        }

        public void DisplayOverviewHeader(Company company, DateTime date)
        {
            company.UpdateCompanyNumbers();
            Console.WriteLine("| {0} | {1}EUR | {2} | {3} LKWs | {4} Fahrer | {5} Aufträge |", company.GetCompanyName(),
                company.GetCompanyCash(), date.ToShortDateString(), company.GetNumberOfOwnedTrucks(),
                company.GetNumberOfEmployees(), company.GetNumberOfJobs());
        }

        public void PrintListOfTrucks(List<Truck> listOfTrucks)
        {
            int[] initialMaxStringLengthForTrucks = { 3, 5, 7, 10, 10, 11, 7, 5 };
            Console.Clear();
            foreach (var truck in listOfTrucks) Uiprep.CalcMaxStringLengthForTrucks(truck);

            PrintTableHeaders(Uiprep.GetHeaderStringsForTrucks(), Uiprep.GetMaxStringLengthForTrucks());

            foreach (var truck in listOfTrucks)
                PrintTable(Uiprep.FileStringsAsListForTrucks(truck).ToArray(),
                    Uiprep.GetMaxStringLengthForTrucks());

            Uiprep.SetMaxStringLengthForTrucks(
                initialMaxStringLengthForTrucks); //reset the maxStringLengthForTrucksArray
        }

        public void PrintListOfDrivers(List<Driver> listOfDrivers)
        {
            int[] initialMaxStringLengthForDrivers = { 3, 8, 8, 5 };
            Console.Clear();
            foreach (var driver in listOfDrivers) Uiprep.CalcMaxStringLengthForDrivers(driver);

            PrintTableHeaders(Uiprep.GetHeaderStringsForDrivers(), Uiprep.GetMaxStringLengthForDrivers());

            foreach (var driver in listOfDrivers)
                PrintTable(Uiprep.FileStringsAsListForDrivers(driver).ToArray(),
                    Uiprep.GetMaxStringLengthForDrivers());

            Uiprep.SetMaxStringLengthForDrivers(initialMaxStringLengthForDrivers);
        }
    }
}