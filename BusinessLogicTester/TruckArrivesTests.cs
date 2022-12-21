using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zusammenbauen;

namespace BusinessLogicTester
{
    [TestClass]
    public class TruckArrivesTest
    {
        [TestMethod]
        public void TruckArrivesAtDestination_TruckCurrentLocationShouldEqualDestinationSet()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            testTruck.SetDistanceForCurrentTrip(1000);

            Businesslogic.TruckArrives(testCompany, testTruck);


            Assert.AreEqual(Location.Esslingen, testTruck.GetCurrentLocation());
        }

        [TestMethod]
        public void TruckArrivesAtDestination_TruckRemainingDistanceShouldEqual0()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            testTruck.SetDistanceForCurrentTrip(1000);

            Businesslogic.TruckArrives(testCompany, testTruck);

            Assert.AreEqual(0, testTruck.GetRemainingDistanceToDrive());
        }

        [TestMethod]
        public void TryToMoveTruckAfterArriving_ShouldNotMoveAnymore()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            var listOfTestTrucks = new List<Truck>();
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            testTruck.SetDistanceForCurrentTrip(1000);

            Businesslogic.TruckArrives(testCompany, testTruck);
            listOfTestTrucks.Add(testTruck);
            Businesslogic.LetTrucksDrive(listOfTestTrucks);

            Assert.AreEqual(Location.Esslingen, testTruck.GetCurrentLocation());
        }

        [TestMethod]
        public void DeleteJobAfterTruckArrives_AssignedJobShouldBeRemovedFromTruck()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            testCompany.GetListOfPendingJobs().Add(testJob);
            testTruck.SetAssignedJob(testJob);
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);

            Businesslogic.TruckArrives(testCompany, testTruck);

            Assert.IsNull(testTruck.GetAssignedJob());
        }

        [TestMethod]
        public void DeleteJobAfterTruckArrives_JobShouldBeRemovedFromPendingJobsList()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            var jobListLenghtBefore = 0;
            testCompany.GetListOfPendingJobs().Add(testJob);
            testTruck.SetAssignedJob(testJob);
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            jobListLenghtBefore = testCompany.GetListOfPendingJobs().Count;

            Businesslogic.TruckArrives(testCompany, testTruck);

            Assert.AreNotEqual(jobListLenghtBefore, testCompany.GetListOfPendingJobs().Count);
        }

        [TestMethod]
        public void PayFuelTest_PassionateDriver500km_NewCompanyCashShouldEqual49900()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testDriverPassionate = new Driver(1, "Jane", "Doe");
            var testJob = new Job(1);

            testCompany.GetListOfPendingJobs().Add(testJob);
            testTruck.SetAssignedJob(testJob);
            testDriver.SetDriverType(Driver.DriverType.passionate);
            testTruck.SetFuelConsumption(20);
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            testTruck.SetDistanceForCurrentTrip(500);


            Businesslogic.TruckArrives(testCompany, testTruck);

            Assert.AreEqual(49900, testCompany.GetCompanyCash());
        }

        [TestMethod]
        public void PayFuelTest_RacerDriver500km_NewCompanyCashShouldEqual49885()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testDriverPassionate = new Driver(1, "Jane", "Doe");
            var testJob = new Job(1);

            testCompany.GetListOfPendingJobs().Add(testJob);
            testTruck.SetAssignedJob(testJob);
            testDriver.SetDriverType(Driver.DriverType.racer);
            testTruck.SetFuelConsumption(20);
            testTruck.SetAssignedDriver(testDriver);
            testTruck.SetDestination(Location.Esslingen);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            testTruck.SetDistanceForCurrentTrip(500);


            Businesslogic.TruckArrives(testCompany, testTruck);

            Assert.AreEqual(49885, testCompany.GetCompanyCash());
        }
    }
}