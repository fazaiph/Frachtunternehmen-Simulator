using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class UIpreparator
    {
        private static int[] maxStringLengthForTrucks = { 3, 5, 7, 10, 10, 11, 7, 5 };

        private static readonly string[] headerStringsForTrucks =
            { " #", " Typ", " Alter", " Leistung", " Zuladung", " Verbrauch", " Preis", " Ort" };

        public int[] GetMaxStringLengthForTrucks()
        {
            return maxStringLengthForTrucks;
        }

        public string[] GetHeaderStringsForTrucks()
        {
            return headerStringsForTrucks;
        }

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

        public void CalcMaxStringLengthForTrucks(Trucks truck)
        {
            maxStringLengthForTrucks = CalcMaxStringLengthPerColumn(maxStringLengthForTrucks,
                FileStringLengthListForTrucks(truck).ToArray());
        }

        private int[] CalcMaxStringLengthPerColumn(int[] maxStringLength, int[] stringLengthPerColumn)
        {
            for (var index = 0;
                 index < maxStringLengthForTrucks.Length;
                 index++) //für jede Anzeige prüfen, ob in der jeweiligen Spalte ein längerer String ist und gegebenenfalls aktualisieren
                if (stringLengthPerColumn[index] > maxStringLength[index])
                    maxStringLength[index] = stringLengthPerColumn[index];
            return maxStringLength;
        }
    }
}