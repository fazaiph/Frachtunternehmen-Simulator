using System;

namespace Zusammenbauen
{
    public class Driver
    {
        public enum DriverType
        {
            old = 0,            //"Alt, aber erfahren"
            racer = 1,          //"Rennfahrer"
            dreamer = 2,        //"Verträumt"
            passionate = 3,     //"Liebt seinen Job"
            unobtrusive = 4      // "Unauffälig"
        }

        private readonly string fullName;

        private readonly Random number = new Random();
        private readonly DriverType type;

        private readonly int wishedForSalary;
        private int driversIndex;
        private Boolean assignedToTruck;

        public Driver(int driversIndexFromOutside, string forename, string surname)
        {
            driversIndex = driversIndexFromOutside;
            fullName = forename + " " + surname;
            wishedForSalary = number.Next(2000, 5000);
            type = (DriverType)number.Next(5);
            assignedToTruck = false;
        }

        public bool GetAssignedToTruck()
        {
            return assignedToTruck;
        }

        public void SetAssignedToTruck(bool newStatement)
        {
            assignedToTruck = newStatement;
        }

        public string GetFullName()
        {
            return fullName;
        }

        public int GetWishedForSalary()
        {
            return wishedForSalary;
        }

        public string GetDriverTypeAsString()
        {
            return Mapper.MapDriverTypeToString(type);
        }

        public void SetID(int newID)
        {
            driversIndex = newID;
        }

        public int GetDriversIndex()
        {
            return driversIndex;
        }

        public DriverType GetDriverType()
        {
            return type;
        }
    }
}