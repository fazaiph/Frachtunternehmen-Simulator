using System;
using System.Collections.Generic;

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


        private readonly string goodsType, originCity, destinationCity, requiredTruckType;
        private readonly Mapper mapper = new Mapper();
        private readonly List<string> printingList = new List<string>();
        private readonly Random rndNum = new Random();

        private readonly List<int> stringLengthPerColumn = new List<int>();
        private readonly int totalWeight, jobIndex, deliveryDays, maxDays;

        public Job(int jobIndexFromOutside)
        {
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
            jobIndex = jobIndexFromOutside;
            FileStringLengthList();
            FileStringsAsList();
        }

        private void FileStringLengthList()
        {
            stringLengthPerColumn.Add(jobIndex.ToString().Length + 2);
            stringLengthPerColumn.Add(goodsType.Length + 2);
            stringLengthPerColumn.Add(requiredTruckType.Length + 2);
            stringLengthPerColumn.Add(originCity.Length + 2);
            stringLengthPerColumn.Add(destinationCity.Length + 2);
            stringLengthPerColumn.Add(totalWeight.ToString().Length + 4);
            stringLengthPerColumn.Add(GetDeliveryDateAsString().Length + 2);
            stringLengthPerColumn.Add(payment.ToString().Length + 4);
            stringLengthPerColumn.Add(fine.ToString().Length + 5);
        }

        private void FileStringsAsList()
        {
            printingList.Add(jobIndex.ToString());
            printingList.Add(goodsType);
            printingList.Add(requiredTruckType);
            printingList.Add(originCity);
            printingList.Add(destinationCity);
            printingList.Add(totalWeight.ToString().Insert(totalWeight.ToString().Length, "T"));
            printingList.Add(GetDeliveryDateAsString());
            printingList.Add(payment.ToString().Insert(payment.ToString().Length, "EUR"));
            printingList.Add(fine.ToString().Insert(fine.ToString().Length, "EUR"));
        }

        public List<string> GetPrintingList()
        {
            return printingList;
        }

        public List<int> GetMaxStringLengthPerColumn()
        {
            return stringLengthPerColumn;
        }

        private string GetDeliveryDateAsString()
        {
            return deliveryDate.ToString("dd.MM.yyyy");
        }
    }
}