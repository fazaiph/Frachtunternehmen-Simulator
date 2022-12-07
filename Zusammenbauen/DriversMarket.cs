using System;
using System.Collections.Generic;
using static Zusammenbauen.Businesslogic;
using static Zusammenbauen.UI;

namespace Zusammenbauen
{
    public class DriversMarket
    {
        private static readonly List<Driver> jobSeekingDrivers = new List<Driver>();
        private static readonly NameFileHandler nameHandling = new NameFileHandler();
        private static ConsoleKeyInfo selection;
        private Company activeCompany;

        public DriversMarket()
        {
            CreateListOfDriversToEmploy();
        }

        private static void CreateListOfDriversToEmploy()
        {
            nameHandling.SplitForenameSurnameList();
            for (var i = 0; i < 5; i++)
            {
                var driversIndex = i;
                driversIndex++;
                jobSeekingDrivers.Add(new Driver(driversIndex, nameHandling.GetRandomForename(),
                    nameHandling.GetRandomSurname()));
            }
        }

        public void OpenDriversMarket(Company activeCompany)
        {
            Console.Clear();
            ConsoleKeyInfo selectedDriverId;
            PrintListOfDrivers(jobSeekingDrivers);
            selectedDriverId = SelectDriver(jobSeekingDrivers);
            if (!'z'.Equals(selectedDriverId.KeyChar))
                employDriver(activeCompany, selectedDriverId.KeyChar.ToString(), jobSeekingDrivers);
        }

        public static ConsoleKeyInfo SelectDriver(List<Driver> listOfDrivers)
        {
            ConsoleKeyInfo selection;
            bool selectionIsValid;
            do
            {
                Console.WriteLine("Wählen Sie einen Fahrer mit 1-{0} oder kehren Sie zurück mit z",
                    listOfDrivers.Count);
                selectionIsValid = true;
                selection = Console.ReadKey(true);
                var test = Convert.ToChar(listOfDrivers.Count.ToString());
                if ((selection.KeyChar < '1' ||
                     selection.KeyChar > Convert.ToChar(listOfDrivers.Count.ToString())) &&
                    !'z'.Equals(selection.KeyChar))
                {
                    selectionIsValid = false;
                    Console.WriteLine("Ungültige Eingabe!");
                    //.ReadKey(true);
                }
            } while (!selectionIsValid);

            return selection;
        }


        public List<Driver> GetListOfJobSeekingDrivers()
        {
            return jobSeekingDrivers;
        }
    }
}