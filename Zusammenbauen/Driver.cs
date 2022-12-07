using System;

namespace Zusammenbauen
{
    public class Driver
    {
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
        private int driversIndex;

        public Driver(int driversIndexFromOutside, string forename, string surname)
        {
            driversIndex = driversIndexFromOutside;
            fullName = forename + " " + surname;
            wishedForSalary = number.Next(2000, 5000);
            type = availableTypes[number.Next(5)];
        }

        public string GetFullName()
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

        public void SetID(int newID)
        {
            driversIndex = newID;
        }

        public int GetDriversIndex()
        {
            return driversIndex;
        }
    }
}