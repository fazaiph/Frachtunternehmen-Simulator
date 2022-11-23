using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zusammenbauen;

namespace BusinessLogicTester
{
    [TestClass]
    public class CompanyTests
    {
        [TestMethod]
        public void AddTruckToOwnedTrucks_AddingATruckToCompany_ShouldEqualTo1()
        {
            var testCompany = new Company("test");
            var testTruck = new Trucks(1);

            testCompany.AddTruckToOwnedTrucks(testTruck);

            Assert.AreEqual(1, testCompany.GetListOfOwnedTrucks().Count);
        }

        [TestMethod]
        public void SetCompanyCash_removingPriceOfTruckHere25945EUR_ShouldSetCompanyCashTo24055()
        {
            var testCompany = new Company("test");

            testCompany.SetCompanyCash(testCompany.GetCompanyCash() - 25945);

            Assert.AreEqual(24055, testCompany.GetCompanyCash());
        }

        [TestMethod]
        public void AddDriverToEmployedDriversList_AddingADriverToTheCompany_ListLengthOfEmployedDriversShouldBe1()
        {
            var testCompany = new Company("test");
            var driverToBeAdded = new Drivers(0, "Max", "Mustermann");

            testCompany.AddDriverToEmployedDriversList(driverToBeAdded);

            Assert.AreEqual(1, testCompany.GetListOfEmployedDrivers().Count);
        }

        [TestMethod]
        public void AddJobToPendingJobsList_AddONEJobToListOfPendingJobs_PendingJobsListLengthShouldBe1()
        {
            var testCompany = new Company("test");

            testCompany.AddJobToPendingJobsList(new Job(1));

            Assert.AreEqual(1, testCompany.GetListOfPendingJobs().Count);
        }
    }

    [TestClass]
    public class TruckMarketTests
    {
        [TestMethod]
        public void
            RemoveTruckFromMarket_removingTruckFromListOfAvailableTrucks_LengthOfListOfAvailableTrucksShouldBe7()
        {
            var testTruckMarket = new TruckMarket();
            TruckMarket.RemoveTruckFromMarket(7);

            Assert.AreEqual(7, TruckMarket.GetTrucksOnTheMarketList().Count);
        }
    }

    [TestClass]
    public class DriverMarketTests
    {
        [TestMethod]
        public void
            RemoveDriverFromMarket_removingDriverFromListOfJobSeekingDrivers_LengthOfListOfJobSeekingDriversShouldBe4()
        {
            var testDriversMarket = new DriversMarket();

            testDriversMarket.RemoveDriverFromMarket(4);

            Assert.AreEqual(4, testDriversMarket.GetListOfJobSeekingDrivers().Count);
        }
    }

    [TestClass]
    public class JobOfferMarketTests
    {
        [TestMethod]
        public void RemoveJobFromJobOfferMarket_removingOneJobFromJobOfferMarket_LengthOfListOfPendingJobsShouldBe7()
        {
            var testJobOffersMarket = new JobOfferMarket();

            testJobOffersMarket.RemoveJobFromJobOfferMarket(7);

            Assert.AreEqual(7, testJobOffersMarket.GetListOfJobOffers().Count);
        }
    }

    [TestClass]
    public class ProgrammTests
    {
        [TestMethod]
        public void EndRound_EndRoundByAddingADayToGameDate_gameDateShouldBeIncreasedByOne()
        {
            var gamedDateBeforeEndOfRound = Program.gameDate;
            Program.EndRound();

            Assert.AreEqual(gamedDateBeforeEndOfRound.AddDays(1), Program.gameDate);
        }
    }
}