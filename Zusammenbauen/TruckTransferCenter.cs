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
            Truck selectedTruck;
            double distanceBetweenLocations = 0;
            PrintListOfTrucksForMarket(activeCompany.GetListOfTrucksWithDrivers());
            selectedTruckId = SelectATruck(activeCompany.GetListOfTrucksWithDrivers());
            if (!'z'.Equals(selectedTruckId.KeyChar))
                selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId.KeyChar.ToString());
            else
                return;
            selectedTruck = activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt - 1];
            if (selectedTruck.GetCurrentLocation() ==
                Location.Unterwegs)
            {
                Console.WriteLine("Dieser LKW ist momentan unterwegs und kann nicht bewegt werden!");
                Console.WriteLine("Beliebige Taste drücken um zum Menü zurückzukehren");
                Console.ReadKey();
                return;
            }

            PrintDestinationSelectionPage();
            selectedDestination = SelectADestination();
            if (!'z'.Equals(selectedDestination.KeyChar))
                selectedDestinationAsInt = Convert.ToInt32(selectedDestination.KeyChar.ToString());
            else
                return;
            distanceBetweenLocations = CalcDistance(selectedTruck.GetCurrentLocation(),
                (Location)selectedDestinationAsInt);
            ChangeTruckLocation(selectedTruck, 0);
            selectedTruck.SetDriveableDistancePerDay(CalculateDriveDistancePerDay(0, selectedTruck.GetPower(),
                selectedTruck.GetAssignedDriver().GetDriverType()));
            selectedTruck.SetRemainingDistanceToDrive(distanceBetweenLocations);
            selectedTruck.SetDistanceForCurrentTrip(distanceBetweenLocations);
            selectedTruck.SetDestination((Location)selectedDestinationAsInt);
            Console.WriteLine("Der LKW brauch {0} Tage", selectedTruck.GetRemainingDistanceToDrive()/selectedTruck.GetDriveableDistancePerDay());
            Console.ReadKey();
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