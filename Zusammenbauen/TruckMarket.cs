using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    public class TruckMarket
    {
        private static readonly List<Trucks> trucksOnTheMarket = new List<Trucks>();
        private static readonly UI myUI = new UI();
        private static readonly UIpreparator Uiprep = new UIpreparator();
        private static ConsoleKeyInfo selection;

        public TruckMarket()
        {
            CreateListOfTrucksToBuy();
        }

        private static void CreateListOfTrucksToBuy()
        {
            for (var i = 0; i < 8; i++)
            {
                var trucksIndex = i;
                trucksIndex++;
                trucksOnTheMarket.Add(new Trucks(trucksIndex));
            }
        }

        public void OpenTrucksMarket(Company activeCompany)
        {
            var selectionIsValid = true;
            foreach (var truck in trucksOnTheMarket) Uiprep.CalcMaxStringLengthForTrucks(truck);

            myUI.PrintTableHeaders(Uiprep.GetHeaderStringsForTrucks(), Uiprep.GetMaxStringLengthForTrucks());

            foreach (var truck in trucksOnTheMarket)
                myUI.PrintTable(Uiprep.FileStringsAsListForTrucks(truck).ToArray(),
                    Uiprep.GetMaxStringLengthForTrucks());
            do
            {
                Console.WriteLine("Kaufen Sie einen Truck mit 1-{0} oder kehren Sie zurück mit z",
                    trucksOnTheMarket.Count);
                selectionIsValid = true;
                selection = Console.ReadKey(true);
                var test = Convert.ToChar(trucksOnTheMarket.Count.ToString());
                if ((selection.KeyChar < '1' ||
                     selection.KeyChar > Convert.ToChar(trucksOnTheMarket.Count.ToString())) &&
                    !'z'.Equals(selection.KeyChar))
                {
                    selectionIsValid = false;
                    Console.WriteLine("Ungültige Eingabe!");
                    //.ReadKey(true);
                }
            } while (!selectionIsValid);

            if (!'z'.Equals(selection.KeyChar)) buyTruck(activeCompany, selection.KeyChar.ToString());
        }

        private static void buyTruck(Company buyingCompany, string selectedTruckId)
        {
            var selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId) - 1;
            buyingCompany.SetCompanyCash(buyingCompany.GetCompanyCash() -
                                         trucksOnTheMarket[selectedTruckIdAsInt].GetPrice());
            buyingCompany.AddTruckToOwnedTrucks(trucksOnTheMarket[selectedTruckIdAsInt]);
            RemoveTruckFromMarket(selectedTruckIdAsInt);
        }

        public static void RemoveTruckFromMarket(int selectedTruckId)
        {
            trucksOnTheMarket.RemoveAt(selectedTruckId);
            UpdateTrucksOnTheMarketIds();
        }

        private static void UpdateTrucksOnTheMarketIds()
        {
            var newID = 1;
            foreach (var truck in trucksOnTheMarket) truck.SetID(newID++);
        }

        public static List<Trucks> GetTrucksOnTheMarketList()
        {
            return trucksOnTheMarket;
        }
    }
}