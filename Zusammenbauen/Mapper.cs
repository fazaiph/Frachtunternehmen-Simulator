using System;

namespace Zusammenbauen
{
    internal class Mapper
    {
        private readonly Random rndNum = new Random();

        public static string MapGoodsTypeToTruckType(string goodsType)
        {
            return goodsType switch
            {
                "Zigaretten" => "Pritschenwagen",
                "Textilien" => "Pritschenwagen",
                "Schokolade" => "Pritschenwagen",
                "Früchte" => "Kühllastwagen",
                "Eiscreme" => "Kühllastwagen",
                "Fleisch" => "Kühllastwagen",
                "Rohöl" => "Tanklaster",
                "Heizöl" => "Tanklaster",
                "Benzin" => "Tanklaster",
                _ => "kein passender Wagen!"
            };
        }

        public static int MapMaxLoad(string size, string type)
        {
            return size switch
            {
                "Klein" => type switch
                {
                    "Pritschenwagen" => 4,
                    "Tanklaster" => 2,
                    "Kühllastwagen" => 3,
                    _ => 0
                },
                "Medium" => type switch
                {
                    "Pritschenwagen" => 6,
                    "Tanklaster" => 4,
                    "Kühllastwagen" => 4,
                    _ => 0
                },
                "Groß" => type switch
                {
                    "Pritschenwagen" => 7,
                    "Tanklaster" => 8,
                    "Kühllastwagen" => 5,
                    _ => 0
                },
                "Riesig" => type switch
                {
                    "Pritschenwagen" => 10,
                    "Tanklaster" => 10,
                    "Kühllastwagen" => 6,
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

        public static int MapBaseTruckFuelConsumption(string size, string type)
        {
            return size switch
            {
                "Klein" => type switch
                {
                    "Pritschenwagen" => 10,
                    "Tanklaster" => 14,
                    "Kühllastwagen" => 14,
                    _ => 0
                },
                "Medium" => type switch
                {
                    "Pritschenwagen" => 12,
                    "Tanklaster" => 18,
                    "Kühllastwagen" => 18,
                    _ => 0
                },
                "Groß" => type switch
                {
                    "Pritschenwagen" => 16,
                    "Tanklaster" => 20,
                    "Kühllastwagen" => 20,
                    _ => 0
                },
                "Riesig" => type switch
                {
                    "Pritschenwagen" => 22,
                    "Tanklaster" => 30,
                    "Kühllastwagen" => 30,
                    _ => 0
                },
                _ => 0
            };
        }

        public static double MapBaseTruckPrice(string size)
        {
            return size switch
            {
                "Klein" => 25000.0,
                "Medium" => 65000.0,
                "Groß" => 80000.0,
                "Riesig" => 120000.0,
                _ => 0
            };
        }

        public int MapTruckPower(string size)
        {
            return size switch
            {
                "Klein" => rndNum.Next(10, 26),
                "Medium" => rndNum.Next(30, 51),
                "Groß" => rndNum.Next(40, 71),
                "Riesig" => rndNum.Next(60, 81),
                _ => 0
            };
        }
    }
}