using System;

namespace Zusammenbauen
{
    internal class Program
    {
        private static readonly UI myUI = new UI();
        private static ConsoleKeyInfo selection;
        private static string companyName;
        private static DateTime gameDate = DateTime.Now;
        private static Company activeCompany;
        private static JobOfferMarket jobOfferMarket;
        private static DriversMarket driversMarket;
        private static TruckMarket truckMarket;

        private static void Main(string[] args)
        {
            myUI.NameSelectionScreen();
            companyName = Console.ReadLine();
            CreateGame();
            while (true) //für's erste ne Dauerschleife, da noch nicht gefordert, das Spiel verlassen zu können
            {
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
                        //Console.WriteLine("In Branch 4");
                        gameDate = gameDate.AddDays(1);
                        break;

                    default:
                        Console.WriteLine("Ende");
                        break;
                }
            }

            Console.WriteLine("escaped");
        }

        public static void MainMenu(Company activeCompany)
        {
            do
            {
                myUI.DisplayMainMenu(activeCompany, gameDate);
                selection = Console.ReadKey(true);
            } while (selection.KeyChar < '1' || selection.KeyChar > '4');
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