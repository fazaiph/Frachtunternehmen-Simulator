using System;

namespace Zusammenbauen
{
    internal class Mapper
    {
        private static readonly Random rndNum = new Random();

        public static Truck.TruckType MapGoodsTypeToTruckType(Job.goodsTypes goodsType)
        {
            return goodsType switch
            {
                Job.goodsTypes.Zigaretten => Truck.TruckType.Pritschenwagen,
                Job.goodsTypes.Textilien => Truck.TruckType.Pritschenwagen,
                Job.goodsTypes.Schokolade => Truck.TruckType.Pritschenwagen,
                Job.goodsTypes.Früchte => Truck.TruckType.Kühllastwagen,
                Job.goodsTypes.Eiscreme => Truck.TruckType.Kühllastwagen,
                Job.goodsTypes.Fleisch => Truck.TruckType.Kühllastwagen,
                Job.goodsTypes.Rohöl => Truck.TruckType.Tanklaster,
                Job.goodsTypes.Heizöl => Truck.TruckType.Tanklaster,
                Job.goodsTypes.Benzin => Truck.TruckType.Tanklaster,
                _ => Truck.TruckType.Pritschenwagen
            };
        }

        public static int MapMaxLoad(Truck.TruckSize size, Truck.TruckType type)
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

        public static int MapBaseTruckFuelConsumption(Truck.TruckSize size, Truck.TruckType type)
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

        public static double MapBaseTruckPrice(Truck.TruckSize size)
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

        public static int MapTruckPower(Truck.TruckSize size)
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

        public static string MapDriverTypeToString(Driver.DriverType DType)
        {
            return DType switch
            {
                Driver.DriverType.old => "Alt, aber erfahren",
                Driver.DriverType.racer => "Rennfahrer",
                Driver.DriverType.dreamer => "Verträumt",
                Driver.DriverType.passionate => "Liebt seinen Job",
                Driver.DriverType.unobtrusive => "Unauffälig",
                _ => "kein Typ"
            };
        }

        public static double MapCityToEasting(Location city)
        {
            return city switch
            {
                Location.Amsterdam => 868851,
                Location.Berlin => 1442341,
                Location.Esslingen => 1232391,
                Location.Rom => 1605258,
                Location.Lissabon => -220417,
                Location.Istanbul => 3015490,
                Location.Aarhus => 1156381,
                Location.Tallin => 1889074,
                _ => 0
            };
        }

        public static double MapCityToNorthing(Location city)
        {
            return city switch
            {
                Location.Amsterdam => 297477,
                Location.Berlin => 404144,
                Location.Esslingen => -71899,
                Location.Rom => -786717,
                Location.Lissabon => -1218006,
                Location.Istanbul => -498084,
                Location.Aarhus => 763352,
                Location.Tallin => 1368933,
                _ => 0
            };
        }

        public static double MapDriverTypeToSpeedFactors(Driver.DriverType type)
        {
            return type switch
            {
                Driver.DriverType.old => 1.15,
                Driver.DriverType.racer => 1.25,
                Driver.DriverType.dreamer => 0.8,
                Driver.DriverType.passionate => 1,
                Driver.DriverType.unobtrusive => 0.95,
                _ => 1
            };
        }

        public static double MapDriverFuelConsumptionFactor(Driver.DriverType type)
        {
            return type switch
            {
                Driver.DriverType.old => 0.99,
                Driver.DriverType.racer => 1.15,
                Driver.DriverType.dreamer => 1.01,
                Driver.DriverType.passionate => 1,
                Driver.DriverType.unobtrusive => 1,
                _ => 1
            };
        }
    }
}