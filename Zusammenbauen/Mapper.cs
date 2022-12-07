using System;

namespace Zusammenbauen
{
    internal class Mapper
    {
        private readonly Random rndNum = new Random();

        public static Truck.truckType MapGoodsTypeToTruckType(string goodsType)
        {
            return goodsType switch
            {
                "Zigaretten" => Truck.truckType.Pritschenwagen,
                "Textilien" => Truck.truckType.Pritschenwagen,
                "Schokolade" => Truck.truckType.Pritschenwagen,
                "Früchte" => Truck.truckType.Kühllastwagen,
                "Eiscreme" => Truck.truckType.Kühllastwagen,
                "Fleisch" => Truck.truckType.Kühllastwagen,
                "Rohöl" => Truck.truckType.Tanklaster,
                "Heizöl" => Truck.truckType.Tanklaster,
                "Benzin" => Truck.truckType.Tanklaster,
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

        public static int MapMaxDays(string goodsType)
        {
            return goodsType switch
            {
                "Zigaretten" => 20,
                "Textilien" => 20,
                "Schokolade" => 10,
                "Früchte" => 14,
                "Eiscreme" => 10,
                "Fleisch" => 14,
                "Rohöl" => 14,
                "Heizöl" => 25,
                "Benzin" => 28,
                _ => 0
            };
        }

        public int MapMinPricePerTon(string goodsType)
        {
            return goodsType switch
            {
                "Zigaretten" => 100,
                "Textilien" => 50,
                "Schokolade" => 120,
                "Früchte" => 150,
                "Eiscreme" => 180,
                "Fleisch" => 130,
                "Rohöl" => 120,
                "Heizöl" => 90,
                "Benzin" => 80,
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