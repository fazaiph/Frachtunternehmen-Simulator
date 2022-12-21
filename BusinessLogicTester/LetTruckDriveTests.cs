using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zusammenbauen;

namespace BusinessLogicTester
{
    [TestClass]
    public class LetTruckDriveTests
    {
        [TestMethod]
        public void TrucksDriveCalculatedDistanceperDay_NewRemainingDistanceShouldBeLesserByDistancePerDay()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            testTruck.SetRemainingDistanceToDrive(1000);
            testTruck.SetDriveableDistancePerDay(420);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            var listOfTestTrucks = new List<Truck>();
            listOfTestTrucks.Add(testTruck);
            Businesslogic.LetTrucksDrive(listOfTestTrucks);


            Assert.AreEqual(580, listOfTestTrucks[0].GetRemainingDistanceToDrive());
        }

        [TestMethod]
        public void TrucksArrivingDestination_NewRemainingDistanceShouldBeLesserThan0()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            testTruck.SetRemainingDistanceToDrive(100);
            testTruck.SetDriveableDistancePerDay(420);
            testTruck.SetCurrentLocation(Location.Unterwegs);
            var listOfTestTrucks = new List<Truck>();
            listOfTestTrucks.Add(testTruck);
            Businesslogic.LetTrucksDrive(listOfTestTrucks);


            Assert.AreEqual(-320, listOfTestTrucks[0].GetRemainingDistanceToDrive());
        }

        [TestMethod]
        public void TruckIsNotOnTheRoad_ValueOfRemainingDistanceShouldNotChange()
        {
            var testCompany = new Company("test");
            var testTruck = new Truck(1);
            var testDriver = new Driver(0, "Max", "Mustermann");
            var testJob = new Job(1);
            testTruck.SetRemainingDistanceToDrive(1000);
            testTruck.SetDriveableDistancePerDay(420);
            testTruck.SetCurrentLocation(Location.Esslingen);
            var listOfTestTrucks = new List<Truck>();
            listOfTestTrucks.Add(testTruck);
            Businesslogic.LetTrucksDrive(listOfTestTrucks);


            Assert.AreEqual(1000, listOfTestTrucks[0].GetRemainingDistanceToDrive());
        }
    }
}