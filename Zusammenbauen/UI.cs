using System;

namespace Zusammenbauen
{
    internal class UI
    {
        private readonly string[] employeeHeaderStrings =
            { " # ", " Ware", " Typ", " Startort", " Zielort", " Gewicht", " Lieferdatum", " Vergütung", " Strafe" };

        private readonly string[] jobHeaderStrings =
            { " # ", " Ware", " Typ", " Startort", " Zielort", " Gewicht", " Lieferdatum", " Vergütung", " Strafe" };


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
            Console.WriteLine("4.Runde beenden");
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
    }
}