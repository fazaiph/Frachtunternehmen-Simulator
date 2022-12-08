using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    public class Businesslogic
    {
        //********************************************************************************************************************
        //Truck related Business Logic
        public static void BuyTruck(Company buyingCompany, string selectedTruckId, List<Truck> trucksOnTheMarket)
        {
            var selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId) - 1;
            buyingCompany.SetCompanyCash(buyingCompany.GetCompanyCash() -
                                         trucksOnTheMarket[selectedTruckIdAsInt].GetPrice());
            buyingCompany.AddTruckToOwnedTrucks(trucksOnTheMarket[selectedTruckIdAsInt]);
            RemoveTruckFromList(selectedTruckIdAsInt, trucksOnTheMarket);
            buyingCompany.SetDriverlessOwnedTrucks(UpdateTruckIds(buyingCompany.GetListOfDriverlessOwnedTrucks()));
        }

        public static void RemoveTruckFromList(int selectedTruckId, List<Truck> truckList)
        {
            truckList.RemoveAt(selectedTruckId);
            UpdateTruckIds(truckList);
        }

        public static List<Truck> UpdateTruckIds(List<Truck> listOfTrucks)
        {
            var newID = 1;
            foreach (var truck in listOfTrucks) truck.SetID(newID++);
            return listOfTrucks;
        }

        public static void AssignDriverToTruck(Truck selectedTruck, Driver assignedDriver)
        {
            selectedTruck.SetAssignedDriver(assignedDriver);
            selectedTruck.SetIsDriverless(false);
        }

        public static void TransferTruckToAssignedTrucksList(List<Truck> driverlessTrucks, int formerTruckId,
            List<Truck> listOfTrucksWithDrivers)
        {
            listOfTrucksWithDrivers.Add(driverlessTrucks[formerTruckId]);
            RemoveTruckFromList(formerTruckId, driverlessTrucks);
            UpdateTruckIds(driverlessTrucks);
            UpdateTruckIds(listOfTrucksWithDrivers);
        }

        public static void ChangeTruckLocation(Truck truck, Truck.Location newLocation)
        {
            truck.SetCurrentLocation(newLocation);
        }

        //********************************************************************************************************************
        //Driver related Business Logic
        public static void employDriver(Company activeCompany, string selectedDriverId, List<Driver> jobSeekingDrivers)
        {
            var selectedDriverIdAsInt = Convert.ToInt32(selectedDriverId) - 1;
            activeCompany.AddDriverToEmployedDriversList(jobSeekingDrivers[selectedDriverIdAsInt]);
            RemoveDriverFromList(selectedDriverIdAsInt, jobSeekingDrivers);
            UpdateDriversIds(activeCompany.GetListOfEmployedDrivers());
        }

        public static void RemoveDriverFromList(int selectedDriverId, List<Driver> listOfDrivers)
        {
            listOfDrivers.RemoveAt(selectedDriverId);
            UpdateDriversIds(listOfDrivers);
        }

        private static List<Driver> UpdateDriversIds(List<Driver> listOfDrivers)
        {
            var newID = 1;
            foreach (var driver in listOfDrivers) driver.SetID(newID++);
            return listOfDrivers;
        }

        //********************************************************************************************************************
        //Job related Business Logic
        public static void acceptJob(Company activeCompany, string selectedJobId, List<Job> jobOffers)
        {
            var selectedJobIdAsInt = Convert.ToInt32(selectedJobId) - 1;
            jobOffers[selectedJobIdAsInt].SetStatusOfJob((Job.Status)1);
            activeCompany.AddJobToPendingJobsList(jobOffers[selectedJobIdAsInt]);
            RemoveJobFromList(selectedJobIdAsInt, jobOffers);
            UpdateJobIds(activeCompany.GetListOfPendingJobs());
        }

        public static void RemoveJobFromList(int selectedDriverId, List<Job> jobList)
        {
            jobList.RemoveAt(selectedDriverId);
            UpdateJobIds(jobList);
        }

        private static void UpdateJobIds(List<Job> jobList)
        {
            var newID = 1;
            foreach (var job in jobList) job.SetID(newID++);
        }

        public static void DispatchTruckForJob(Truck truck, Job job)
        {
            job.SetStatusOfJob(Job.Status.Bearbeitung);
            ChangeTruckLocation(truck, 0);
        }
    }
}