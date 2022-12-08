using System;
using static Zusammenbauen.Businesslogic;
using static Zusammenbauen.UI;
using static Zusammenbauen.TruckMarket;

namespace Zusammenbauen
{
    internal class TruckTransferCenter
    {
        public static void StartTransferingATruck(Company activeCompany)
        {
            ConsoleKeyInfo selectedTruckId, selectedDestination;
            int selectedTruckIdAsInt, selectedDestinationAsInt;
            PrintListOfTrucks(activeCompany.GetListOfTrucksWithDrivers());
            selectedTruckId = SelectATruck(activeCompany.GetListOfTrucksWithDrivers());
            if (!'z'.Equals(selectedTruckId.KeyChar))
                selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId.KeyChar.ToString());
            else
                return;
            if (activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt - 1].GetCurrentLocation() ==
                Truck.Location.Unterwegs)
            {
                Console.WriteLine("Dieser LKW ist momentan unterwegs und kann nicht bewegt werden!");
                Console.WriteLine("Beliebige Taste drücken um zum Menü zurückzukehren");
                Console.ReadKey();
                return;
            }

            PrintDestinationSelectionPage();
            selectedDestination = SelectADestination();
            if (!'z'.Equals(selectedDestination.KeyChar))
                selectedDestinationAsInt = Convert.ToInt32(selectedTruckId.KeyChar.ToString());
            else
                return;
            ChangeTruckLocation(activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt - 1], 0);
        }

        public static ConsoleKeyInfo SelectADestination()
        {
            ConsoleKeyInfo selection;
            bool selectionIsValid;
            do
            {
                selectionIsValid = true;
                Console.WriteLine("Wählen Sie eine Stadt mit 1-8 oder kehren Sie zurück mit z");

                selection = Console.ReadKey(true);
                if ((selection.KeyChar < '1' ||
                     selection.KeyChar > '9') &&
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