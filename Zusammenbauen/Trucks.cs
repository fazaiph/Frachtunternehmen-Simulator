using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class Trucks
    {
        private static readonly Random rndNum = new Random();

        private readonly int age;

        private readonly string[] availableLocations =
            { "Amsterdam", "Berlin", "Esslingen", "Rom", "Lissabon", "Istanbul", "Aarhus", "Tallin" };

        private readonly string[] availableTypes = { "Kühllastwagen", "Pritschenwagen", "Tanklaster" };
        private readonly string currentLocation;
        private readonly int power, maxLoad, fuelConsumption;
        private readonly int price;
        private readonly List<string> printingList = new List<string>();
        private readonly List<int> stringLengthPerColumn = new List<int>();
        private readonly Mapper truckMapper = new Mapper();
        private readonly string[] truckSizes = { "Klein", "Medium", "Groß", "Riesig" };
        private readonly string type, size;
        private double priceFactor;
        private int trucksIndex;

        public Trucks(int trucksIndexFromOutside)
        {
            type = availableTypes[rndNum.Next(3)];
            age = rndNum.Next(11);
            currentLocation = availableLocations[rndNum.Next(8)];
            size = truckSizes[rndNum.Next(4)];
            power = truckMapper.MapTruckPower(size);
            maxLoad = Mapper.MapMaxLoad(size, type);
            fuelConsumption = CalcFuelConsumption();
            price = (int)CalcPrice();
            trucksIndex = trucksIndexFromOutside;
            FileStringLengthList();
            FileStringsAsList();
        }

        private void FileStringLengthList()
        {
            stringLengthPerColumn.Add(trucksIndex.ToString().Length + 2);
            stringLengthPerColumn.Add(type.Length + 2);
            stringLengthPerColumn.Add(GetAgeAsString().Length + 2);
            stringLengthPerColumn.Add(power.ToString().Length + 2);
            stringLengthPerColumn.Add(maxLoad.ToString().Length + 2);
            stringLengthPerColumn.Add(fuelConsumption.ToString().Length + 2);
            stringLengthPerColumn.Add(price.ToString().Length + 6);
            stringLengthPerColumn.Add(currentLocation.Length + 2);
        }

        private void FileStringsAsList()
        {
            printingList.Add(trucksIndex.ToString());
            printingList.Add(type);
            printingList.Add(GetAgeAsString());
            printingList.Add(power.ToString().Insert(power.ToString().Length, "kW"));
            printingList.Add(maxLoad.ToString().Insert(maxLoad.ToString().Length, "T"));
            printingList.Add(fuelConsumption.ToString().Insert(fuelConsumption.ToString().Length, "L"));
            printingList.Add(price.ToString().Insert(price.ToString().Length, "EUR"));
            printingList.Add(currentLocation);
        }

        public List<string> GetPrintingList()
        {
            return printingList;
        }

        public List<int> GetStringLengthPerColumn()
        {
            return stringLengthPerColumn;
        }


        public string GetLKWType()
        {
            return type;
        }

        public int GetAge()
        {
            return age;
        }

        public string GetCurrentLocation()
        {
            return currentLocation;
        }

        public string GetSize()
        {
            return size;
        }

        public string GetAgeAsString()
        {
            if (age == 0) return "-neu-";
            var tempString = age + " Jahre";
            return tempString;
        }

        public int GetPower()
        {
            return power;
        }

        public int GetMaxLoad()
        {
            return maxLoad;
        }

        public int GetFuelConsumption()
        {
            return fuelConsumption;
        }

        public int GetPrice()
        {
            return price;
        }

        private double CalcPrice()
        {
            CalcPriceFactor();
            return Mapper.MapBaseTruckPrice(size) * priceFactor;
        }

        private void CalcPriceFactor()
        {
            priceFactor = 1.0 + rndNum.Next(-20, 31) / 100.0 - age * 0.03;
            if (type == "Küllastwagen") priceFactor += 0.1;
        }

        private int CalcFuelConsumption()
        {
            return Mapper.MapBaseTruckFuelConsumption(size, type) +
                   Convert.ToInt32(Math.Floor(Convert.ToDouble(age) / 3));
        }

        public void SetID(int newID)
        {
            trucksIndex = newID;
        }

        public void UpdatePrintingList(int index, int newContent)
        {
            var newItem = newContent.ToString();
            printingList.RemoveAt(index);
            printingList.Insert(index, newItem);
        }
    }
}