using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class UIpreparator
    {
        private static int[] maxStringLengthForTrucks = { 3, 5, 7, 10, 10, 11, 7, 5 };

        private static int[] maxStringLengthForDrivers = { 3, 8, 8, 5 };

        private static int[] maxStringLengthForJobs = { 3, 6, 5, 10, 9, 9, 13, 11, 8 };

        private static readonly string[] headerStringsForTrucks =
            { " #", " Typ", " Alter", " Leistung", " Zuladung", " Verbrauch", " Preis", " Ort" };

        private readonly string[] headerStringsForDrivers =
            { " # ", " Fahrer", " Gehalt", " Typ" };

        private readonly string[] headerStringsForJob =
            { " # ", " Ware", " Typ", " Startort", " Zielort", " Gewicht", " Lieferdatum", " Vergütung", " Strafe" };

        public List<int> FileStringLengthListForTrucks(Trucks truck)
        {
            var stringLengthPerColumn = new List<int>();
            stringLengthPerColumn.Add(truck.GetTruckIndex().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetTruckType().Length + 2);
            stringLengthPerColumn.Add(truck.GetAgeAsString().Length + 2);
            stringLengthPerColumn.Add(truck.GetPower().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetMaxLoad().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetFuelConsumption().ToString().Length + 2);
            stringLengthPerColumn.Add(truck.GetPrice().ToString().Length + 6);
            stringLengthPerColumn.Add(truck.GetCurrentLocation().Length + 2);
            return stringLengthPerColumn;
        }


        public List<string> FileStringsAsListForTrucks(Trucks truck)
        {
            var printingList = new List<string>();
            printingList.Add(truck.GetTruckIndex().ToString());
            printingList.Add(truck.GetTruckType());
            printingList.Add(truck.GetAgeAsString());
            printingList.Add(truck.GetPower().ToString().Insert(truck.GetPower().ToString().Length, "kW"));
            printingList.Add(truck.GetMaxLoad().ToString().Insert(truck.GetMaxLoad().ToString().Length, "T"));
            printingList.Add(truck.GetFuelConsumption().ToString()
                .Insert(truck.GetFuelConsumption().ToString().Length, "L"));
            printingList.Add(truck.GetPrice().ToString().Insert(truck.GetPrice().ToString().Length, "EUR"));
            printingList.Add(truck.GetCurrentLocation());
            return printingList;
        }

        private List<int> FileStringLengthListForDrivers(Drivers driver)
        {
            var stringLengthPerColumn = new List<int>();
            stringLengthPerColumn.Add(driver.GetDriversIndex().ToString().Length + 2);
            stringLengthPerColumn.Add(driver.GetFullName().Length + 2);
            stringLengthPerColumn.Add(driver.GetWishedForSalary().ToString().Length + 5);
            stringLengthPerColumn.Add(driver.GetDriverType().Length + 2);
            return stringLengthPerColumn;
        }

        public List<string> FileStringsAsListForDrivers(Drivers driver)
        {
            var printingList = new List<string>();
            printingList.Add(driver.GetDriversIndex().ToString());
            printingList.Add(driver.GetFullName());
            printingList.Add(driver.GetWishedForSalary().ToString()
                .Insert(driver.GetWishedForSalary().ToString().Length, "EUR"));
            printingList.Add(driver.GetDriverType());
            return printingList;
        }

        private List<int> FileStringLengthListForJobs(Job job)
        {
            var stringLengthPerColumn = new List<int>();
            stringLengthPerColumn.Add(job.GetJobIndex().ToString().Length + 2);
            stringLengthPerColumn.Add(job.GetGoodsType().Length + 2);
            stringLengthPerColumn.Add(job.GetRequiredTruckType().Length + 2);
            stringLengthPerColumn.Add(job.GetOriginCity().Length + 2);
            stringLengthPerColumn.Add(job.GetDestinationCity().Length + 2);
            stringLengthPerColumn.Add(job.GetTotalWeight().ToString().Length + 4);
            stringLengthPerColumn.Add(job.GetDeliveryDateAsString().Length + 2);
            stringLengthPerColumn.Add(job.GetPayment().ToString().Length + 4);
            stringLengthPerColumn.Add(job.GetFine().ToString().Length + 5);
            return stringLengthPerColumn;
        }

        public List<string> FileStringsAsListForJobs(Job job)
        {
            var printingList = new List<string>();
            printingList.Add(job.GetJobIndex().ToString());
            printingList.Add(job.GetGoodsType());
            printingList.Add(job.GetRequiredTruckType());
            printingList.Add(job.GetOriginCity());
            printingList.Add(job.GetDestinationCity());
            printingList.Add(job.GetTotalWeight().ToString().Insert(job.GetTotalWeight().ToString().Length, "T"));
            printingList.Add(job.GetDeliveryDateAsString());
            printingList.Add(job.GetPayment().ToString().Insert(job.GetPayment().ToString().Length, "EUR"));
            printingList.Add(job.GetFine().ToString().Insert(job.GetFine().ToString().Length, "EUR"));
            return printingList;
        }

        public void CalcMaxStringLengthForTrucks(Trucks truck)
        {
            maxStringLengthForTrucks = CalcMaxStringLengthPerColumn(maxStringLengthForTrucks,
                FileStringLengthListForTrucks(truck).ToArray(), maxStringLengthForTrucks.Length);
        }

        public void CalcMaxStringLengthForDrivers(Drivers driver)
        {
            maxStringLengthForDrivers = CalcMaxStringLengthPerColumn(maxStringLengthForDrivers,
                FileStringLengthListForDrivers(driver).ToArray(),
                maxStringLengthForDrivers.Length);
        }

        private int[] CalcMaxStringLengthPerColumn(int[] maxStringLength, int[] stringLengthPerColumn, int maxIndex)
        {
            for (var index = 0;
                 index < maxIndex;
                 index++) //für jede Anzeige prüfen, ob in der jeweiligen Spalte ein längerer String ist und gegebenenfalls aktualisieren
                if (stringLengthPerColumn[index] > maxStringLength[index])
                    maxStringLength[index] = stringLengthPerColumn[index];
            return maxStringLength;
        }

        public int[] GetMaxStringLengthForTrucks()
        {
            return maxStringLengthForTrucks;
        }

        public string[] GetHeaderStringsForTrucks()
        {
            return headerStringsForTrucks;
        }

        public int[] GetMaxStringLengthForDrivers()
        {
            return maxStringLengthForDrivers;
        }

        public string[] GetHeaderStringsForDrivers()
        {
            return headerStringsForDrivers;
        }

        public void CalcMaxStringLengthForJobs(Job job)
        {
            maxStringLengthForJobs = CalcMaxStringLengthPerColumn(maxStringLengthForJobs,
                FileStringLengthListForJobs(job).ToArray(),
                maxStringLengthForJobs.Length);
        }

        public string[] GetHeaderStringsForJobs()
        {
            return headerStringsForJob;
        }

        public int[] GetMaxStringLengthForJobs()
        {
            return maxStringLengthForJobs;
        }
    }
}