using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class Company
    {
        private readonly string companyName;
        private readonly List<Drivers> employedDrivers = new List<Drivers>();
        private readonly List<Trucks> ownedTrucks = new List<Trucks>();
        private readonly List<Job> pendingJobs = new List<Job>();
        private long companyCash;
        private int numberOfEmployees, numberOfOwnedTrucks, numberOfJobs;

        public Company(string chosenName)
        {
            companyName = chosenName;
            companyCash = 50000;
            numberOfEmployees = 0;
            numberOfOwnedTrucks = 0;
            numberOfJobs = 0;
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
            return numberOfJobs;
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
            numberOfOwnedTrucks = ownedTrucks.Count;
            numberOfJobs = pendingJobs.Count;
        }

        public void SetCompanyCash(long newCash)
        {
            companyCash = newCash;
        }

        public void addTruckToOwnedTrucks(Trucks truckToAdd)
        {
            ownedTrucks.Add(truckToAdd);
            numberOfOwnedTrucks++;
        }
    }
}