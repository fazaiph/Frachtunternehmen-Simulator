﻿using System;

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

        public enum Location
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
        private readonly Truck.truckType requiredTruckType;
        private readonly Random rndNum = new Random();
        private readonly int totalWeight;
        private int jobIndex;
        private Status status;

        public Job(int jobIndexFromOutside)
        {
            jobIndex = jobIndexFromOutside;
            goodsType = (goodsTypes)rndNum.Next(9);
            requiredTruckType = Mapper.MapGoodsTypeToTruckType(goodsType);
            totalWeight = rndNum.Next(1, Mapper.MapMaxLoad(Truck.truckSize.Riesig, requiredTruckType));
            originCity = (Location)rndNum.Next(1, 9);
            destinationCity = (Location)rndNum.Next(1, 9);
            maxDays = Mapper.MapMaxDays(goodsType);
            deliveryDays = rndNum.Next(3, maxDays);
            deliveryDate = DateTime.Now.AddDays(deliveryDays);
            bonusFactor = 1.0 + (0.2 + Convert.ToDouble(deliveryDays) / Convert.ToDouble(maxDays)) *
                rndNum.NextDouble();
            payment = mapper.MapMinPricePerTon(goodsType) * totalWeight * bonusFactor;
            fine = rndNum.Next(50, 201) * payment / 100;
            status = Status.offen;
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

        public Truck.truckType GetRequiredTruckType()
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