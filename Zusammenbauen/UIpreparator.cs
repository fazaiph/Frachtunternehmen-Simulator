using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class UIpreparator
    {
        private static int[] maxStringLengthForTrucks = { 3, 5, 7, 10, 10, 11, 7, 5 };

        private static int[] maxStringLengthForDrivers = { 3, 8, 8, 5 };

        private static int[] maxStringLengthForJobs = { 3, 6, 5, 10, 9, 9, 13, 11, 8, 8 };

        private static readonly string[] headerStringsForTrucks =
            { " #", " Typ", " Alter", " Leistung", " Zuladung", " Verbrauch", " Preis", " Ort" };

        private static readonly string[] headerStringsForDrivers =
            { " # ", " Fahrer", " Gehalt", " Typ" };

        private static readonly string[] headerStringsForJob =
        {
            " # ", " Ware", " Typ", " Startort", " Zielort", " Gewicht", " Lieferdatum", " Vergütung", " Strafe",
            " Status"
        };

        public static List<int> FileStringLengthListForTrucks(Truck truck)
        {
            var stringLengthPerColumn = new List<int>();
            stringLengthPerColumn.Add(truck.GetTruckIndex().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetTruckType().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetAgeAsString().Length + 2);
            stringLengthPerColumn.Add(truck.GetPower().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetMaxLoad().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetFuelConsumption().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetPrice().ToString().Length + 6);
            stringLengthPerColumn.Add(truck.GetCurrentLocation().ToString().Length + 2);
            return stringLengthPerColumn;
        }


        public static List<string> FileStringsAsListForTrucks(Truck truck)
        {
            var printingList = new List<string>();
            printingList.Add(truck.GetTruckIndex().ToString());
            printingList.Add(truck.GetTruckType().ToString());
            printingList.Add(truck.GetAgeAsString());
            printingList.Add(truck.GetPower().ToString().Insert(truck.GetPower().ToString().Length, "kW"));
            printingList.Add(truck.GetMaxLoad().ToString().Insert(truck.GetMaxLoad().ToString().Length, "T"));
            printingList.Add(truck.GetFuelConsumption().ToString()
                .Insert(truck.GetFuelConsumption().ToString().Length, "L"));
            printingList.Add(truck.GetPrice().ToString().Insert(truck.GetPrice().ToString().Length, "EUR"));
            printingList.Add(truck.GetCurrentLocation().ToString());
            return printingList;
        }

        private static List<int> FileStringLengthListForDrivers(Driver driver)
        {
            var stringLengthPerColumn = new List<int>();
            stringLengthPerColumn.Add(driver.GetDriversIndex().ToString().Length + 2);
            stringLengthPerColumn.Add(driver.GetFullName().Length + 2);
            stringLengthPerColumn.Add(driver.GetWishedForSalary().ToString().Length + 5);
            stringLengthPerColumn.Add(driver.GetDriverType().Length + 2);
            return stringLengthPerColumn;
        }

        public static List<string> FileStringsAsListForDrivers(Driver driver)
        {
            var printingList = new List<string>();
            printingList.Add(driver.GetDriversIndex().ToString());
            printingList.Add(driver.GetFullName());
            printingList.Add(driver.GetWishedForSalary().ToString()
                .Insert(driver.GetWishedForSalary().ToString().Length, "EUR"));
            printingList.Add(driver.GetDriverType());
            return printingList;
        }

        private static List<int> FileStringLengthListForJobs(Job job)
        {
            var stringLengthPerColumn = new List<int>();
            stringLengthPerColumn.Add(job.GetJobIndex().ToString().Length + 2);
            stringLengthPerColumn.Add(job.GetGoodsType().ToString().Length + 2);
            stringLengthPerColumn.Add(job.GetRequiredTruckType().ToString().Length + 2);
            stringLengthPerColumn.Add(job.GetOriginCity().ToString().Length + 2);
            stringLengthPerColumn.Add(job.GetDestinationCity().ToString().Length + 2);
            stringLengthPerColumn.Add(job.GetTotalWeight().ToString().Length + 4);
            stringLengthPerColumn.Add(job.GetDeliveryDateAsString().Length + 2);
            stringLengthPerColumn.Add(job.GetPayment().ToString().Length + 4);
            stringLengthPerColumn.Add(job.GetFine().ToString().Length + 5);
            stringLengthPerColumn.Add(job.GetStatus().ToString().Length + 2);
            return stringLengthPerColumn;
        }

        public static List<string> FileStringsAsListForJobs(Job job)
        {
            var printingList = new List<string>();
            printingList.Add(job.GetJobIndex().ToString());
            printingList.Add(job.GetGoodsType().ToString());
            printingList.Add(job.GetRequiredTruckType().ToString());
            printingList.Add(job.GetOriginCity().ToString());
            printingList.Add(job.GetDestinationCity().ToString());
            printingList.Add(job.GetTotalWeight().ToString().Insert(job.GetTotalWeight().ToString().Length, "T"));
            printingList.Add(job.GetDeliveryDateAsString());
            printingList.Add(job.GetPayment().ToString().Insert(job.GetPayment().ToString().Length, "EUR"));
            printingList.Add(job.GetFine().ToString().Insert(job.GetFine().ToString().Length, "EUR"));
            printingList.Add(job.GetStatus().ToString());
            return printingList;
        }

        public static void CalcMaxStringLengthForTrucks(Truck truck)
        {
            maxStringLengthForTrucks = CalcMaxStringLengthPerColumn(maxStringLengthForTrucks,
                FileStringLengthListForTrucks(truck).ToArray(), maxStringLengthForTrucks.Length);
        }

        public static void CalcMaxStringLengthForDrivers(Driver driver)
        {
            maxStringLengthForDrivers = CalcMaxStringLengthPerColumn(maxStringLengthForDrivers,
                FileStringLengthListForDrivers(driver).ToArray(),
                maxStringLengthForDrivers.Length);
        }

        private static int[] CalcMaxStringLengthPerColumn(int[] maxStringLength, int[] stringLengthPerColumn,
            int maxIndex)
        {
            for (var index = 0;
                 index < maxIndex;
                 index++) //für jede Anzeige prüfen, ob in der jeweiligen Spalte ein längerer String ist und gegebenenfalls aktualisieren
                if (stringLengthPerColumn[index] > maxStringLength[index])
                    maxStringLength[index] = stringLengthPerColumn[index];
            return maxStringLength;
        }

        public static int[] GetMaxStringLengthForTrucks()
        {
            return maxStringLengthForTrucks;
        }

        public static string[] GetHeaderStringsForTrucks()
        {
            return headerStringsForTrucks;
        }

        public static int[] GetMaxStringLengthForDrivers()
        {
            return maxStringLengthForDrivers;
        }

        public static string[] GetHeaderStringsForDrivers()
        {
            return headerStringsForDrivers;
        }

        public static void CalcMaxStringLengthForJobs(Job job)
        {
            maxStringLengthForJobs = CalcMaxStringLengthPerColumn(maxStringLengthForJobs,
                FileStringLengthListForJobs(job).ToArray(),
                maxStringLengthForJobs.Length);
        }

        public static string[] GetHeaderStringsForJobs()
        {
            return headerStringsForJob;
        }

        public static int[] GetMaxStringLengthForJobs()
        {
            return maxStringLengthForJobs;
        }

        public List<Truck> PickDriverlessTrucks(List<Truck> ListOfOwnedTrucks)
        {
            var listOfDriverlessTrucks = new List<Truck>();
            foreach (var truck in ListOfOwnedTrucks)
                if (truck.isDriverless)
                    listOfDriverlessTrucks.Add(truck);

            return listOfDriverlessTrucks;
        }

        public static void SetMaxStringLengthForTrucks(int[] newArray)
        {
            maxStringLengthForTrucks = newArray;
        }

        public static void SetMaxStringLengthForDrivers(int[] initialMaxStringLengthForDrivers)
        {
            maxStringLengthForDrivers = initialMaxStringLengthForDrivers;
        }

        public static void SetMaxStringLengthForJobs(int[] initialMaxStringLengthForJobs)
        {
            maxStringLengthForJobs = initialMaxStringLengthForJobs;
        }
    }
}