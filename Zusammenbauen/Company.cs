using System;
using System.Collections.Generic;
using static Zusammenbauen.TruckMarket;
using static Zusammenbauen.DriversMarket;
using static Zusammenbauen.Businesslogic;
using static Zusammenbauen.UI;

namespace Zusammenbauen
{
    public class Company
    {
        private static readonly List<Truck> ownedTrucksWithDrivers = new List<Truck>();
        private readonly string companyName;
        private readonly List<Driver> employedDrivers = new List<Driver>();
        private readonly List<Job> pendingJobs = new List<Job>();
        private long companyCash;
        private List<Truck> driverlessOwnedTrucks = new List<Truck>();

        private int numberOfEmployees, numberOfOwnedTrucks, numberOfPendingJobs;

        public Company(string chosenName)
        {
            companyName = chosenName;
            companyCash = 50000;
            numberOfEmployees = 0;
            numberOfOwnedTrucks = 0;
            numberOfPendingJobs = 0;
        }

        public List<Job> GetListOfPendingJobs()
        {
            return pendingJobs;
        }

        public List<Driver> GetListOfEmployedDrivers()
        {
            return employedDrivers;
        }

        public List<Truck> GetListOfDriverlessOwnedTrucks()
        {
            return driverlessOwnedTrucks;
        }

        public int GetNumberOfEmployees()
        {
            return numberOfEmployees;
        }

        public int GetNumberOfOwnedTrucks()
        {
            return numberOfOwnedTrucks;
        }

        public int GetNumberOfJobs()
        {
            return numberOfPendingJobs;
        }

        public string GetCompanyName()
        {
            return companyName;
        }

        public long GetCompanyCash()
        {
            return companyCash;
        }

        public void UpdateCompanyNumbers()
        {
            numberOfEmployees = employedDrivers.Count;
            numberOfOwnedTrucks = driverlessOwnedTrucks.Count + ownedTrucksWithDrivers.Count;
            numberOfPendingJobs = pendingJobs.Count;
        }

        public void SetCompanyCash(long newCash)
        {
            companyCash = newCash;
        }

        public void AddTruckToOwnedTrucks(Truck truckToAdd)
        {
            driverlessOwnedTrucks.Add(truckToAdd);
            numberOfOwnedTrucks++;
        }

        public void AddDriverToEmployedDriversList(Driver freshlyEmployedDriver)
        {
            employedDrivers.Add(freshlyEmployedDriver);
            numberOfEmployees++;
        }

        public void AddJobToPendingJobsList(Job jobOffer)
        {
            pendingJobs.Add(jobOffer);
            numberOfPendingJobs++;
        }

        public void StartAssignDriverToTruckRoutine(Company activeCompany)
        {
            ConsoleKeyInfo selectedTruckId, selectedDriverId;
            int selectedTruckIdAsInt, selectedDriverIdAsInt;
            PrintListOfTrucks(driverlessOwnedTrucks);
            selectedTruckId = SelectATruck(driverlessOwnedTrucks);
            if (!'z'.Equals(selectedTruckId.KeyChar))
                selectedTruckIdAsInt = Convert.ToInt32(selectedTruckId.KeyChar.ToString());
            else
                return;
            PrintListOfDrivers(employedDrivers);
            selectedDriverId = SelectDriver(employedDrivers);
            if (!'z'.Equals(selectedDriverId.KeyChar))
                selectedDriverIdAsInt = Convert.ToInt32(selectedDriverId.KeyChar.ToString());
            else
                return;
            AssignDriverToTruck(driverlessOwnedTrucks[selectedTruckIdAsInt - 1],
                employedDrivers[selectedDriverIdAsInt - 1]);
            TransferTruckToAssignedTrucksList(driverlessOwnedTrucks, selectedTruckIdAsInt - 1, ownedTrucksWithDrivers);
        }

        public void SetDriverlessOwnedTrucks(List<Truck> listWithUpdateTruckIds)
        {
            driverlessOwnedTrucks = listWithUpdateTruckIds;
        }

        public List<Truck> GetListOfTrucksWithDrivers()
        {
            return ownedTrucksWithDrivers;
        }
    }
}