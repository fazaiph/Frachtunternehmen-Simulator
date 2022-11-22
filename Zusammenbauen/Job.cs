using System;

namespace Zusammenbauen
{
    internal class Job
    {
        private readonly string[] availableCites =
            { "Amsterdam", "Berlin", "Esslingen", "Rom", "Lissabon", "Istanbul", "Aarhus", "Tallin" };

        private readonly string[] availableGoods =
            { "Zigaretten", "Textilien", "Schokolade", "Früchte", "Eiscreme", "Fleisch", "Rohöl", "Heizöl", "Benzin" };

        private readonly double bonusFactor, payment, fine;
        private readonly DateTime deliveryDate;
        private readonly int deliveryDays, maxDays;


        private readonly string goodsType, originCity, destinationCity, requiredTruckType;
        private readonly Mapper mapper = new Mapper();
        private readonly Random rndNum = new Random();
        private readonly int totalWeight;
        private int jobIndex;

        public Job(int jobIndexFromOutside)
        {
            jobIndex = jobIndexFromOutside;
            goodsType = availableGoods[rndNum.Next(9)];
            requiredTruckType = Mapper.MapGoodsTypeToTruckType(goodsType);
            totalWeight = rndNum.Next(1, Mapper.MapMaxLoad("Riesig", requiredTruckType));
            originCity = availableCites[rndNum.Next(8)];
            destinationCity = availableCites[rndNum.Next(8)];
            maxDays = Mapper.MapMaxDays(goodsType);
            deliveryDays = rndNum.Next(3, maxDays);
            deliveryDate = DateTime.Now.AddDays(deliveryDays);
            bonusFactor = 1.0 + (0.2 + Convert.ToDouble(deliveryDays) / Convert.ToDouble(maxDays)) *
                rndNum.NextDouble();
            payment = mapper.MapMinPricePerTon(goodsType) * totalWeight * bonusFactor;
            fine = rndNum.Next(50, 201) * payment / 100;
        }

        public string GetDeliveryDateAsString()
        {
            return deliveryDate.ToString("dd.MM.yyyy");
        }

        public int GetJobIndex()
        {
            return jobIndex;
        }

        public string GetGoodsType()
        {
            return goodsType;
        }

        public string GetRequiredTruckType()
        {
            return requiredTruckType;
        }

        public string GetOriginCity()
        {
            return originCity;
        }

        public string GetDestinationCity()
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
    }
}