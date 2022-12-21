using System;
using System.Collections.Generic;
using static Zusammenbauen.Mapper;
using static Zusammenbauen.Businesslogic;

namespace Zusammenbauen
{
    public class Job
    {
        public enum goodsTypes
        {
            Zigaretten = 0,
            Textilien = 1,
            Schokolade = 2,
            Früchte = 3,
            Eiscreme = 4,
            Fleisch = 5,
            Rohöl = 6,
            Heizöl = 7,
            Benzin = 8
        }

        public enum Status
        {
            offen = 0,
            angenommen = 1,
            Bearbeitung = 2
        }

        private readonly double bonusFactor, payment, fine;
        private readonly DateTime deliveryDate;
        private readonly int deliveryDays, maxDays;
        private readonly goodsTypes goodsType;
        private readonly Mapper mapper = new Mapper();
        private readonly Location originCity, destinationCity;
        private readonly Truck.TruckType requiredTruckType;
        private readonly Random rndNum = new Random();
        private readonly int totalWeight;
        private double distance;
        private int jobIndex;
        private Status status;

        public Job(int jobIndexFromOutside)
        {
            jobIndex = jobIndexFromOutside;
            goodsType = (goodsTypes)rndNum.Next(9);
            requiredTruckType = MapGoodsTypeToTruckType(goodsType);
            totalWeight = rndNum.Next(1, MapMaxLoad(Truck.TruckSize.Riesig, requiredTruckType));
            originCity = (Location)rndNum.Next(1, 9);
            destinationCity = (Location)rndNum.Next(1, 9);
            distance = CalcDistance(originCity, destinationCity);
                maxDays = MapMaxDays(goodsType);
            deliveryDays = rndNum.Next(3, maxDays);
            deliveryDate = DateTime.Now.AddDays(deliveryDays);
            bonusFactor = 1.0 + (0.2 + Convert.ToDouble(deliveryDays) / Convert.ToDouble(maxDays)) *
                rndNum.NextDouble();
            payment = mapper.MapMinPricePerTon(goodsType) * totalWeight * bonusFactor;
            fine = rndNum.Next(50, 201) * payment / 100;
            status = Status.offen;
        }

        public double GetDistance()
        {
            return distance;
        }

        public Status GetStatus()
        {
            return status;
        }

        public string GetDeliveryDateAsString()
        {
            return deliveryDate.ToString("dd.MM.yyyy");
        }

        public int GetJobIndex()
        {
            return jobIndex;
        }

        public goodsTypes GetGoodsType()
        {
            return goodsType;
        }

        public Truck.TruckType GetRequiredTruckType()
        {
            return requiredTruckType;
        }

        public Location GetOriginCity()
        {
            return originCity;
        }

        public Location GetDestinationCity()
        {
            return destinationCity;
        }

        public int GetTotalWeight()
        {
            return totalWeight;
        }

        public double GetPayment()
        {
            return Math.Round(payment, 2);
        }

        public double GetFine()
        {
            return Math.Round(fine, 2);
        }

        public void SetID(int newID)
        {
            jobIndex = newID;
        }

        public void SetStatusOfJob(Status newStatus)
        {
            status = newStatus;
        }
    }
}