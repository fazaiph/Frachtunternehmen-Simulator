using System;
using System.Collections.Generic;
using System.Text;
using static Zusammenbauen.UI;
using static Zusammenbauen.JobOfferMarket;
using static Zusammenbauen.TruckMarket;
using static Zusammenbauen.Businesslogic;

namespace Zusammenbauen
{
    class
        JobDispatcher
    {
        public static void DispatchJob(Company activeCompany)
        {
            ConsoleKeyInfo selectedJobId, selectedTruckId;
            bool truckIsSuitedForJob;
            int selectedJobIdAsInt, selectedTruckIdAsInt;
            PrintListOfJobs(activeCompany.GetListOfPendingJobs());
            selectedJobId = SelectJob();
            if (!'z'.Equals(selectedJobId.KeyChar))
                selectedJobIdAsInt = Convert.ToInt32(selectedJobId.KeyChar.ToString());
            else
                return;
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

            truckIsSuitedForJob = ValidateIfTruckIsSuitedForJob(activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt - 1],
                activeCompany.GetListOfPendingJobs()[selectedJobIdAsInt - 1]);
            if (truckIsSuitedForJob)
            {
                DispatchTruckForJob(activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt-1],activeCompany.GetListOfPendingJobs()[selectedJobIdAsInt - 1]);
            }
        }

        private static bool ValidateIfTruckIsSuitedForJob(Truck selectedTruck, Job selectedJob)
        {
            string truckLocation = selectedTruck.GetCurrentLocation().ToString(),
                jobOrigin = selectedJob.GetOriginCity().ToString(),
                truckType = selectedTruck.GetTruckType().ToString(),
                requiredTruckTypeForJob = selectedJob.GetRequiredTruckType().ToString();
            int truckCapacity = selectedTruck.GetMaxLoad(), freightWeight = selectedJob.GetTotalWeight();
            return ((truckLocation == jobOrigin) && (truckCapacity >= freightWeight) &&
                    (truckType == requiredTruckTypeForJob));
        }
    }
}
