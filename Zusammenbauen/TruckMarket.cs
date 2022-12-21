using System;
using System.Collections.Generic;
using static Zusammenbauen.Businesslogic;
using static Zusammenbauen.UI;

namespace Zusammenbauen
{
    public class TruckMarket
    {
        private static readonly List<Truck> trucksOnTheMarket = new List<Truck>();

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
                trucksOnTheMarket.Add(new Truck(trucksIndex));
            }
        }

        public void OpenTrucksMarket(Company activeCompany)
        {
            Console.Clear();
            ConsoleKeyInfo selectedTruckId;
            PrintListOfTrucksForMarket(trucksOnTheMarket);
            selectedTruckId = SelectATruck(trucksOnTheMarket);
            if (!'z'.Equals(selectedTruckId.KeyChar))
                BuyTruck(activeCompany, selectedTruckId.KeyChar.ToString(), trucksOnTheMarket);
        }

        public static List<Truck> GetTrucksOnTheMarketList()
        {
            return trucksOnTheMarket;
        }

        public static ConsoleKeyInfo SelectATruck(List<Truck> listOfTrucks)
        {
            ConsoleKeyInfo selection;
            bool selectionIsValid;
            do
            {
                selectionIsValid = true;
                Console.WriteLine("Wählen Sie einen Truck mit 1-{0} oder kehren Sie zurück mit z",
                    listOfTrucks.Count);

                selection = Console.ReadKey(true);
                var test = Convert.ToChar(listOfTrucks.Count.ToString());
                if ((selection.KeyChar < '1' ||
                     selection.KeyChar > Convert.ToChar(listOfTrucks.Count.ToString())) &&
                    !'z'.Equals(selection.KeyChar))
                {
                    selectionIsValid = false;
                    Console.WriteLine("Ungültige Eingabe!");
                    //.ReadKey(true);
                }
            } while (!selectionIsValid);

            return selection;
        }
    }
}