using System;
using System.Collections.Generic;
using static Zusammenbauen.UIpreparator;

namespace Zusammenbauen
{
    internal class UI
    {
        public static void PrintTableHeaders(string[] marketTypeSpecificStrings, int[] maxLengthPerColumn)
        {
            Console.Clear();
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

        public static void PrintTable(int[] maxLengthPerColumn, string[] stringsToPrint)
        {
            for (var index = 0; index < stringsToPrint.Length; index++)
            {
                Console.Write("| ");
                Console.Write(stringsToPrint[index].PadRight(maxLengthPerColumn[index] - 1));
            }

            Console.WriteLine("|");
        }

        public static void DisplayMainMenu(Company company, DateTime date)
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

        public static void NameSelectionScreen()
        {
            Console.WriteLine("Bitte geben Sie einen Namen für ihre Firma ein:");
        }

        public static void DisplayOverviewHeader(Company company, DateTime date)
        {
            company.UpdateCompanyNumbers();
            Console.WriteLine("| {0} | {1}EUR | {2} | {3} LKWs | {4} Fahrer | {5} Aufträge |", company.GetCompanyName(),
                company.GetCompanyCash(), date.ToShortDateString(), company.GetNumberOfOwnedTrucks(),
                company.GetNumberOfEmployees(), company.GetNumberOfJobs());
        }

        public static void PrintListOfTrucksForMarket(List<Truck> listOfTrucks)
        {
            int[] initialMaxStringLengthForTrucks = { 3, 5, 7, 10, 10, 11, 7, 5 };
            foreach (var truck in listOfTrucks) CalcMaxStringLengthForTrucks(truck);

            PrintTableHeaders(GetHeaderStringsForTrucks(), GetMaxStringLengthForTrucks());

            foreach (var truck in listOfTrucks)
                PrintTable(GetMaxStringLengthForTrucks(), FileStringsAsListForTrucks(truck).ToArray());
            SetMaxStringLengthForTrucks(initialMaxStringLengthForTrucks);
        }

        public static void PrintListOfDrivers(List<Driver> listOfDrivers)
        {
            var initialMaxStringLengthForDrivers = GetMaxStringLengthForDrivers();
            Console.Clear();
            foreach (var driver in listOfDrivers) CalcMaxStringLengthForDrivers(driver);

            PrintTableHeaders(GetHeaderStringsForDrivers(), GetMaxStringLengthForDrivers());

            foreach (var driver in listOfDrivers)
                PrintTable(GetMaxStringLengthForDrivers(), FileStringsAsListForDrivers(driver).ToArray());

            SetMaxStringLengthForDrivers(initialMaxStringLengthForDrivers);
        }

        public static void PrintListOfJobs(List<Job> acceptedJobs)
        {
            int[] initialMaxStringLengthForJob = { 3, 6, 5, 10, 9, 9, 13, 11, 8, 8 };
            Console.Clear();
            foreach (var job in acceptedJobs) CalcMaxStringLengthForJobs(job);

            PrintTableHeaders(GetHeaderStringsForJobs(), GetMaxStringLengthForJobs());

            foreach (var job in acceptedJobs)
                PrintTable(GetMaxStringLengthForJobs(), FileStringsAsListForJobs(job).ToArray());

            SetMaxStringLengthForJobs(initialMaxStringLengthForJob);
        }

        public static void PrintDestinationSelectionPage()
        {
            var index = 0;
            Console.Clear();
            foreach (var destination in Enum.GetNames(typeof(Location)))
                if (!(destination == "Unterwegs"))
                    Console.WriteLine("{0}   {1}", ++index, destination);
                else
                    Console.WriteLine("Bitte Wählen Sie eine der aufgelisteten Orte als Ziel aus:");
        }
    }
}