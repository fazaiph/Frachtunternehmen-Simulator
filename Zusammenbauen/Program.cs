using System;
using static Zusammenbauen.TruckTransferCenter;
using static Zusammenbauen.UI;
using static Zusammenbauen.JobDispatcher;
using static Zusammenbauen.Businesslogic;

namespace Zusammenbauen
{
    public class Program
    {
        private static ConsoleKeyInfo selection;
        private static string companyName;
        public static DateTime gameDate = DateTime.Now;
        private static Company activeCompany;
        private static JobOfferMarket jobOfferMarket;
        private static DriversMarket driversMarket;
        private static TruckMarket truckMarket;


        private static void Main(string[] args)
        {
            NameSelectionScreen();
            companyName = Console.ReadLine();
            CreateGame();
            while (true) //fürs erste ne Dauerschleife, da noch nicht gefordert, das Spiel verlassen zu können
            {
                activeCompany.UpdateCompanyNumbers();
                MainMenu(activeCompany);

                switch (selection.KeyChar)
                {
                    case '1':
                        truckMarket.OpenTrucksMarket(activeCompany);
                        break;

                    case '2':
                        driversMarket.OpenDriversMarket(activeCompany);
                        break;

                    case '3':
                        jobOfferMarket.OpenJobOfferMarket(activeCompany);
                        break;

                    case '4':
                        activeCompany.StartAssignDriverToTruckRoutine(activeCompany);
                        break;

                    case '5':
                        StartTransferingATruck(activeCompany);
                        break;

                    case '6':
                        DispatchJob(activeCompany);
                        break;

                    case '7':
                        EndRound();
                        break;

                    default:
                        Console.WriteLine("Ende");
                        break;
                }
            }

            Console.WriteLine("escaped");
        }

        public static void EndRound()
        {
            LetTrucksDrive(activeCompany.GetListOfTrucksWithDrivers());
            gameDate = gameDate.AddDays(1);
            AreWeThereYet(activeCompany);
        }

        public static void MainMenu(Company activeCompany)
        {
            do
            {
                DisplayMainMenu(activeCompany, gameDate);
                selection = Console.ReadKey(true);
            } while (selection.KeyChar < '1' || selection.KeyChar > '7');
        }

        private static void CreateGame()
        {
            activeCompany = new Company(companyName);
            truckMarket = new TruckMarket();
            driversMarket = new DriversMarket();
            jobOfferMarket = new JobOfferMarket();
        }
    }
}