using System;

namespace Zusammenbauen
{
    internal class Trucks
    {
        private static readonly Random rndNum = new Random();

        private readonly int age;

        private readonly string[] availableLocations =
            { "Amsterdam", "Berlin", "Esslingen", "Rom", "Lissabon", "Istanbul", "Aarhus", "Tallin" };

        private readonly string[] availableTypes = { "Kühllastwagen", "Pritschenwagen", "Tanklaster" };
        private readonly string currentLocation, type, size;
        private readonly int power, maxLoad, fuelConsumption, price;
        private readonly Mapper truckMapper = new Mapper();
        private readonly string[] truckSizes = { "Klein", "Medium", "Groß", "Riesig" };
        private double priceFactor;
        private int trucksIndex;

        public Trucks(int trucksIndexFromOutside)
        {
            trucksIndex = trucksIndexFromOutside;
            type = availableTypes[rndNum.Next(3)];
            age = rndNum.Next(11);
            currentLocation = availableLocations[rndNum.Next(8)];
            size = truckSizes[rndNum.Next(4)];
            power = truckMapper.MapTruckPower(size);
            maxLoad = Mapper.MapMaxLoad(size, type);
            fuelConsumption = CalcFuelConsumption();
            price = (int)CalcPrice();
        }

        public int GetTruckIndex()
        {
            return trucksIndex;
        }

        public string GetTruckType()
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
    }
}