#define Testing
using System;

namespace Zusammenbauen
{
    public class Truck
    {
#if Testing
        private int fuelConsumption;
#else
        private readonly int fuelConsumption;
#endif

        public enum TruckSize
        {
            Klein = 0,
            Medium = 1,
            Groß = 2,
            Riesig = 3
        }

        public enum TruckType
        {
            Pritschenwagen = 0,
            Tanklaster = 1,
            Kühllastwagen = 2
        }

        private static readonly Random rndNum = new Random();

        private readonly int age;
        private readonly int power, maxLoad, price;
        private readonly TruckSize size;
        private readonly TruckType type;
        private Driver assginedDriver;
        private Location currentLocation, destination;
        public bool isDriverless;
        private double priceFactor, distanceForCurrentTrip, remainingDistanceToDrive, driveableDistancePerDay;
        private int trucksIndex;
        private Job assignedJob;

        public Truck(int trucksIndexFromOutside)
        {
            trucksIndex = trucksIndexFromOutside;
            type = (TruckType)rndNum.Next(3);
            age = rndNum.Next(11);
            currentLocation = (Location)rndNum.Next(1, 9);
            size = (TruckSize)rndNum.Next(4);
            power = Mapper.MapTruckPower(size);
            maxLoad = Mapper.MapMaxLoad(size, type);
            fuelConsumption = CalcFuelConsumption();
            price = (int)CalcPrice();
            isDriverless = true;
            remainingDistanceToDrive = 0;
            driveableDistancePerDay = 0;
        }

        public double GetDistanceForCurrentTrip()
        {
            return distanceForCurrentTrip;
        }

        public void SetDistanceForCurrentTrip(double distance)
        {
            distanceForCurrentTrip = distance;
        }

        public Location GetDestination()
        {
            return destination;
        }

        public void SetDestination(Location newDestination)
        {
            destination = newDestination;
        }

        public Job GetAssignedJob()
        {
            return assignedJob;
        }

        public void SetAssignedJob(Job newTruck)
        {
            assignedJob = newTruck;
        }

        public void SetIsDriverless(bool state)
        {
            isDriverless = state;
        }

        public double GetDriveableDistancePerDay()
        {
            return driveableDistancePerDay;
        }

        public void SetDriveableDistancePerDay(double newDistance)
        {
            driveableDistancePerDay = newDistance;
        }

        public double GetRemainingDistanceToDrive()
        {
            return remainingDistanceToDrive;
        }

        public void SetRemainingDistanceToDrive(double newDistance)
        {
            remainingDistanceToDrive = newDistance;
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

        public TruckType GetTruckType()
        {
            return type;
        }

        public int GetAge()
        {
            return age;
        }

        public Location GetCurrentLocation()
        {
            return currentLocation;
        }

        public TruckSize GetSize()
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
            if (type == TruckType.Kühllastwagen) priceFactor += 0.1;
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

        public int GetID()
        {
            return trucksIndex;
        }

        public void SetCurrentLocation(Location newLocation)
        {
            currentLocation = newLocation;
        }

#if Testing
        public void SetFuelConsumption(int newValue)
        {
            fuelConsumption = newValue;
        }
#endif
    }
}