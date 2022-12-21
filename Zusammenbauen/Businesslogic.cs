using System;
using System.Collections.Generic;
using static Zusammenbauen.Mapper;

namespace Zusammenbauen
{
    public class Businesslogic
    {
        private static readonly double kwNeededPerTon = 7.5;
        private static readonly double fuelPricePerLitre = 1.0;
        private static readonly double truckBaseSpeed = 70.0;
        private static readonly double maxDrivingHoursPerDay = 8.0;

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

        public static void TransferTruckToNewList(List<Truck> driverlessTrucks, int formerTruckId,
            List<Truck> listOfTrucksWithDrivers)
        {
            listOfTrucksWithDrivers.Add(driverlessTrucks[formerTruckId]);
            RemoveTruckFromList(formerTruckId, driverlessTrucks);
            UpdateTruckIds(driverlessTrucks);
            UpdateTruckIds(listOfTrucksWithDrivers);
        }

        public static void ChangeTruckLocation(Truck truck, Location newLocation)
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

        public static void TransferDriverToNewList(List<Driver> sourceList, int formerDriverId,
            List<Driver> destinationList)
        {
            destinationList.Add(sourceList[formerDriverId]);
            RemoveDriverFromList(formerDriverId, sourceList);
            UpdateDriversIds(sourceList);
            UpdateDriversIds(destinationList);
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
            truck.SetDriveableDistancePerDay(CalculateDriveDistancePerDay(job.GetTotalWeight(), truck.GetPower(),
                truck.GetAssignedDriver().GetDriverType()));
            truck.SetRemainingDistanceToDrive(job.GetDistance());
            truck.SetDistanceForCurrentTrip(job.GetDistance());
            truck.SetAssignedJob(job);
            truck.SetDestination(job.GetDestinationCity());
        }

        public static double CalculateDriveDistancePerDay(int weight, int truckPower, Driver.DriverType driverType)
        {
            var weightfactor = CalcWeightfactor(weight, truckPower);
            var distancePDay = truckBaseSpeed * weightfactor * MapDriverTypeToSpeedFactors(driverType) *
                               maxDrivingHoursPerDay;
            return distancePDay;
        }

        private static double CalcWeightfactor(int weight, int truckPower)
        {
            var neededPower = weight * kwNeededPerTon;
            if (neededPower > truckPower)
                return 1 - (neededPower - truckPower) * 0.01;
            return 1;
        }

        public static double CalcDistance(Location origin, Location destination)
        {
            return Math.Floor(Math.Sqrt(Math.Pow(MapCityToEasting(destination) - MapCityToEasting(origin), 2) +
                                        Math.Pow(MapCityToNorthing(destination) - MapCityToNorthing(origin), 2)) /
                              1000);
        }

        public static void AreWeThereYet(Company company)
        {
            foreach (var truck in company.GetListOfTrucksWithDrivers())
                if (truck.GetRemainingDistanceToDrive() <= 0)
                    TruckArrives(company, truck);
        }

        public static void LetTrucksDrive(List<Truck> trucksList)
        {
            foreach (var truck in trucksList)
                if (truck.GetCurrentLocation() == Location.Unterwegs)
                    truck.SetRemainingDistanceToDrive(truck.GetRemainingDistanceToDrive() -
                                                      truck.GetDriveableDistancePerDay());
        }

        public static void TruckArrives(Company company, Truck truck)
        {
            truck.SetCurrentLocation(truck.GetDestination());
            truck.SetRemainingDistanceToDrive(0);
            truck.SetDriveableDistancePerDay(0);
            PayFuel(company, truck);
            if (truck.GetAssignedJob() != null)
            {
                company.GetListOfPendingJobs().RemoveAt(truck.GetAssignedJob().GetJobIndex() - 1);
                UpdateJobIds(company.GetListOfPendingJobs());
                truck.SetAssignedJob(null);
            }
        }

        public static void PayFuel(Company company, Truck truck)
        {
            var usedFuel = truck.GetDistanceForCurrentTrip() / 100 * truck.GetFuelConsumption() *
                           MapDriverFuelConsumptionFactor(truck.GetAssignedDriver().GetDriverType());
            var costForUsedFuel = usedFuel * fuelPricePerLitre;
            costForUsedFuel = Math.Ceiling(costForUsedFuel);
            company.SetCompanyCash(company.GetCompanyCash() - (long)costForUsedFuel);
        }
    }
}