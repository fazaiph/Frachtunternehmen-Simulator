using System;

namespace Zusammenbauen
{
    internal class Mapper
    {
        private readonly Random rndNum = new Random();

        public static Truck.truckType MapGoodsTypeToTruckType(Job.goodsTypes goodsType)
        {
            return goodsType switch
            {
                Job.goodsTypes.Zigaretten => Truck.truckType.Pritschenwagen,
                Job.goodsTypes.Textilien => Truck.truckType.Pritschenwagen,
                Job.goodsTypes.Schokolade => Truck.truckType.Pritschenwagen,
                Job.goodsTypes.Früchte => Truck.truckType.Kühllastwagen,
                Job.goodsTypes.Eiscreme => Truck.truckType.Kühllastwagen,
                Job.goodsTypes.Fleisch => Truck.truckType.Kühllastwagen,
                Job.goodsTypes.Rohöl => Truck.truckType.Tanklaster,
                Job.goodsTypes.Heizöl => Truck.truckType.Tanklaster,
                Job.goodsTypes.Benzin => Truck.truckType.Tanklaster,
                _ => Truck.truckType.Pritschenwagen
            };
        }

        public static int MapMaxLoad(Truck.truckSize size, Truck.truckType type)
        {
            return (int)size switch
            {
                0 => (int)type switch
                {
                    0 => 4,
                    1 => 2,
                    2 => 3,
                    _ => 0
                },
                1 => (int)type switch
                {
                    0 => 6,
                    1 => 4,
                    2 => 4,
                    _ => 0
                },
                2 => (int)type switch
                {
                    0 => 7,
                    1 => 8,
                    2 => 5,
                    _ => 0
                },
                3 => (int)type switch
                {
                    0 => 10,
                    1 => 10,
                    2 => 6,
                    _ => 0
                },
                _ => 0
            };
        }

        public static int MapMaxDays(Job.goodsTypes goodsType)
        {
            return goodsType switch
            {
                Job.goodsTypes.Zigaretten => 20,
                Job.goodsTypes.Textilien => 20,
                Job.goodsTypes.Schokolade => 10,
                Job.goodsTypes.Früchte => 14,
                Job.goodsTypes.Eiscreme => 10,
                Job.goodsTypes.Fleisch => 14,
                Job.goodsTypes.Rohöl => 14,
                Job.goodsTypes.Heizöl => 25,
                Job.goodsTypes.Benzin => 28,
                _ => 0
            };
        }

        public int MapMinPricePerTon(Job.goodsTypes goodsType)
        {
            return goodsType switch
            {
                Job.goodsTypes.Zigaretten => 100,
                Job.goodsTypes.Textilien => 50,
                Job.goodsTypes.Schokolade => 120,
                Job.goodsTypes.Früchte => 150,
                Job.goodsTypes.Eiscreme => 180,
                Job.goodsTypes.Fleisch => 130,
                Job.goodsTypes.Rohöl => 120,
                Job.goodsTypes.Heizöl => 90,
                Job.goodsTypes.Benzin => 80,
                _ => 0
            };
        }

        public static int MapBaseTruckFuelConsumption(Truck.truckSize size, Truck.truckType type)
        {
            return (int)size switch
            {
                0 => (int)type switch
                {
                    0 => 10,
                    1 => 14,
                    2 => 14,
                    _ => 0
                },
                1 => (int)type switch
                {
                    0 => 12,
                    1 => 18,
                    2 => 18,
                    _ => 0
                },
                2 => (int)type switch
                {
                    0 => 16,
                    1 => 20,
                    2 => 20,
                    _ => 0
                },
                3 => (int)type switch
                {
                    0 => 22,
                    1 => 30,
                    2 => 30,
                    _ => 0
                },
                _ => 0
            };
        }

        public static double MapBaseTruckPrice(Truck.truckSize size)
        {
            return (int)size switch
            {
                0 => 25000.0,
                1 => 65000.0,
                2 => 80000.0,
                3 => 120000.0,
                _ => 0
            };
        }

        public int MapTruckPower(Truck.truckSize size)
        {
            return (int)size switch
            {
                0 => rndNum.Next(10, 26),
                1 => rndNum.Next(30, 51),
                2 => rndNum.Next(40, 71),
                3 => rndNum.Next(60, 81),
                _ => 0
            };
        }
    }
}