using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class TruckMarket
    {
        private static readonly List<Trucks> trucksOnTheMarket = new List<Trucks>();
        private static readonly UI myUI = new UI();
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
            foreach (var truck in trucksOnTheMarket) myUI.CalcMaxStringLengthForTrucks(truck);

            myUI.PrintTableHeaders(myUI.GetHeaderStringsForTrucks(), myUI.GetMaxStringLengthForTrucks());

            foreach (var truck in trucksOnTheMarket)
                myUI.PrintTable(truck.GetPrintingList().ToArray(), myUI.GetMaxStringLengthForTrucks());
            do
            {
                Console.WriteLine("Kaufe einen Truck mit 1-{0} oder kehre zurück mit z", trucksOnTheMarket.Count);
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
            buyingCompany.addTruckToOwnedTrucks(trucksOnTheMarket[selectedTruckIdAsInt]);
            RemoveTruckFromMarket(selectedTruckIdAsInt);
        }

        private static void RemoveTruckFromMarket(int selectedTruckId)
        {
            trucksOnTheMarket.RemoveAt(selectedTruckId);
            UpdateTruckIds();
        }

        private static void UpdateTruckIds()
        {
            var newID = 0;
            foreach (var truck in trucksOnTheMarket)
            {
                truck.SetID(newID++);
                truck.UpdatePrintingList(0, newID);
            }
        }
    }
}