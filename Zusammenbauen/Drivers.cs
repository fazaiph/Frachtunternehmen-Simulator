using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class Drivers
    {
        private static readonly List<int> stringLengthPerColumn = new List<int>();
        private static readonly List<string> printingList = new List<string>();

        private readonly string[] availableTypes =
        {
            "Alt, aber erfahren",
            "Rennfahrer",
            "Verträumt",
            "Liebt seinen Job",
            "Unauffälig"
        };

        private readonly string fullName;

        private readonly Random number = new Random();
        private readonly string type;

        private readonly int wishedForSalary;

        public Drivers(string forename, string surname)
        {
            fullName = forename + " " + surname;
            wishedForSalary = number.Next(2000, 5000);
            type = availableTypes[number.Next(5)];
            FileStringLengthList();
            FileStringsAsList();
        }

        private void FileStringLengthList()
        {
            stringLengthPerColumn.Add(fullName.Length + 2);
            stringLengthPerColumn.Add(wishedForSalary.ToString().Length + 2);
            stringLengthPerColumn.Add(type.Length + 2);
        }

        private void FileStringsAsList()
        {
            printingList.Add(fullName);
            printingList.Add(wishedForSalary.ToString().Insert(wishedForSalary.ToString().Length, "EUR"));
            printingList.Add(type);
        }

        public List<string> GetPrintingList()
        {
            return printingList;
        }

        public List<int> GetStringLengthPerColumn()
        {
            return stringLengthPerColumn;
        }

        public string GetFullname()
        {
            return fullName;
        }

        public int GetWishedForSalary()
        {
            return wishedForSalary;
        }

        public string GetDriverType()
        {
            return type;
        }
    }
}