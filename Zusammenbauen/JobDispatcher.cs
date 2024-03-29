﻿using System;
using static Zusammenbauen.Businesslogic;
using static Zusammenbauen.JobOfferMarket;
using static Zusammenbauen.TruckMarket;
using static Zusammenbauen.UI;

namespace Zusammenbauen
{
    internal class
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
                selectedJobIdAsInt = Convert.ToInt32(selectedJobId.KeyChar.ToString()) - 1;
            else
                return;

            if (activeCompany.GetListOfPendingJobs()[selectedJobIdAsInt].GetStatus() == Job.Status.Bearbeitung)
            {
                Console.WriteLine("Dieser Auftrag wird bereits ausgeführt");
                Console.WriteLine("Beliebige Taste zum zurrückkehren drücken...");
                Console.ReadKey();
                return;
            }

            PrintListOfTrucksForMarket(activeCompany.GetListOfTrucksWithDrivers());
            selectedTruckId = SelectATruck(activeCompany.GetListOfTrucksWithDrivers());
            if (!'z'.Equals(selectedTruckId.KeyChar))
                selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId.KeyChar.ToString()) - 1;
            else
                return;
            if (activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt].GetCurrentLocation() ==
                Location.Unterwegs)
            {
                Console.WriteLine("Dieser LKW ist momentan unterwegs und kann nicht bewegt werden!");
                Console.WriteLine("Beliebige Taste drücken um zum Menü zurückzukehren");
                Console.ReadKey();
                return;
            }

            truckIsSuitedForJob = ValidateIfTruckIsSuitedForJob(
                activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt],
                activeCompany.GetListOfPendingJobs()[selectedJobIdAsInt]);
            if (truckIsSuitedForJob)
            {
                DispatchTruckForJob(activeCompany.GetListOfTrucksWithDrivers()[selectedTruckIdAsInt],
                    activeCompany.GetListOfPendingJobs()[selectedJobIdAsInt]);
            }
            else
            {
                Console.WriteLine("Der LKW erfüllt nicht dei entsprechenden Anfordeungen für den Auftrag");
                Console.WriteLine("Drücken Sie eine beliebige Taste zum fortfahren");
                Console.ReadKey();
            }
        }

        private static bool ValidateIfTruckIsSuitedForJob(Truck selectedTruck, Job selectedJob)
        {
            string truckLocation = selectedTruck.GetCurrentLocation().ToString(),
                jobOrigin = selectedJob.GetOriginCity().ToString(),
                truckType = selectedTruck.GetTruckType().ToString(),
                requiredTruckTypeForJob = selectedJob.GetRequiredTruckType().ToString();
            int truckCapacity = selectedTruck.GetMaxLoad(), freightWeight = selectedJob.GetTotalWeight();
            return truckLocation == jobOrigin && truckCapacity >= freightWeight &&
                   truckType == requiredTruckTypeForJob;
        }
    }
}