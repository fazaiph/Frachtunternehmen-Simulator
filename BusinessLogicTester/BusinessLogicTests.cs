using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zusammenbauen;

namespace BusinessLogicTester
{
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        public void
            TransferTruckToAssignedTrucksList_TruckIsMovedFromDriverlessTrucksToTrucksWithDriver_TrucksWithDriverLengthShouldBe1()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");

            testCompany.AddTruckToOwnedTrucks(testTruck);
            Businesslogic.TransferTruckToNewList(testCompany.GetListOfDriverlessOwnedTrucks(), 0,
                testCompany.GetListOfTrucksWithDrivers());

            Assert.AreEqual(1, testCompany.GetListOfTrucksWithDrivers().Count);
        }

        [TestMethod]
        public void
            TransferTruckToAssignedTrucksList_TruckIsMovedFromDriverlessTrucksToTrucksWithDriver_DriverlessTrucksLengthShouldBe0()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");

            testCompany.AddTruckToOwnedTrucks(testTruck);
            Businesslogic.TransferTruckToNewList(testCompany.GetListOfDriverlessOwnedTrucks(), 0,
                testCompany.GetListOfTrucksWithDrivers());

            Assert.AreEqual(0, testCompany.GetListOfDriverlessOwnedTrucks().Count);
        }

        [TestMethod]
        public void
            ChangeTruckLocation_changingTrucksLocationToUnterwegs_TruckLocationShouldNotEqualTruckLocationFromBefore()
        {
            var testTruck = new Truck(1);
            var locationBeforeChanged = testTruck.GetCurrentLocation();
            Businesslogic.ChangeTruckLocation(testTruck, Truck.Location.Unterwegs);

            Assert.AreNotEqual(locationBeforeChanged, testTruck.GetCurrentLocation());
        }

        [TestMethod]
        public void
            DispatchTruckForJob_SendingTruckOutChangingTrucksLocationToUnterwegs_TruckLocationShouldEqualUnterwegs()
        {
            var testTruck = new Truck(1);
            var testJob = new Job(1);
            var locationBeforeChanged = testTruck.GetCurrentLocation();
            Businesslogic.DispatchTruckForJob(testTruck, testJob);

            Assert.AreEqual(Truck.Location.Unterwegs, testTruck.GetCurrentLocation());
        }

        [TestMethod]
        public void DispatchTruckForJob_ChangingJobStatusToBearbeitung_JobStatusShouldEqualBearbeitung()
        {
            var testTruck = new Truck(1);
            var testJob = new Job(1);
            var locationBeforeChanged = testTruck.GetCurrentLocation();
            Businesslogic.DispatchTruckForJob(testTruck, testJob);

            Assert.AreEqual(Job.Status.Bearbeitung, testJob.GetStatus());
        }
    }
}