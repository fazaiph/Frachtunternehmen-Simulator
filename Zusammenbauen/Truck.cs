using System;

namespace Zusammenbauen
{
    public class Truck
    {
        public enum location
        {
            Unterwegs = 0,
            Amsterdam = 1,
            Berlin = 2,
            Esslingen = 3,
            Rom = 4,
            Lissabon = 5,
            Istanbul = 6,
            Aarhus = 7,
            Tallin = 8
        }

        public enum truckSize
        {
            Klein = 0,
            Medium = 1,
            Groß = 2,
            Riesig = 3
        }

        public enum truckType
        {
            Pritschenwagen = 0,
            Tanklaster = 1,
            Kühllastwagen = 2
        }

        private static readonly Random rndNum = new Random();

        private readonly int age;
        private readonly int power, maxLoad, fuelConsumption, price;
        private readonly truckSize size;
        private readonly Mapper truckMapper = new Mapper();
        private Driver assginedDriver;
        private location currentLocation;
        public bool isDriverless;
        private double priceFactor;
        private int trucksIndex;
        private readonly truckType type;

        public Truck(int trucksIndexFromOutside)
        {
            trucksIndex = trucksIndexFromOutside;
            type = (truckType)rndNum.Next(3);
            age = rndNum.Next(11);
            currentLocation = (location)rndNum.Next(1, 9);
            size = (truckSize)rndNum.Next(4);
            power = truckMapper.MapTruckPower(size);
            maxLoad = Mapper.MapMaxLoad(size, type);
            fuelConsumption = CalcFuelConsumption();
            price = (int)CalcPrice();
            isDriverless = true;
        }

        public void SetIsDriverless(bool state)
        {
            isDriverless = state;
        }

        public Driver GetAssignedDriver()
        {
            return assginedDriver;
        }

        public void SetAssignedDriver(Driver freshlyAssignedDriver)
        {
            assginedDriver = freshlyAssignedDriver;
        }

        public int GetTruckIndex()
        {
            return trucksIndex;
        }

        public truckType GetTruckType()
        {
            return type;
        }

        public int GetAge()
        {
            return age;
        }

        public location GetCurrentLocation()
        {
            return currentLocation;
        }

        public truckSize GetSize()
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
            if (type == truckType.Kühllastwagen) priceFactor += 0.1;
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

        public void SetCurrentLocation(location newLocation)
        {
            currentLocation = newLocation;
        }
    }
}