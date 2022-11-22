using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class DriversMarket
    {
        private static readonly List<Drivers> jobSeekingDrivers = new List<Drivers>();
        private static readonly NameFileHandler nameHandling = new NameFileHandler();
        private static readonly UI myUI = new UI();
        private static readonly UIpreparator Uiprep = new UIpreparator();
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
                jobSeekingDrivers.Add(new Drivers(driversIndex, nameHandling.GetRandomForename(),
                    nameHandling.GetRandomSurname()));
            }
        }

        public void OpenDriversMarket(Company activeCompany)
        {
            var selectionIsValid = true;
            foreach (var driver in jobSeekingDrivers) Uiprep.CalcMaxStringLengthForDrivers(driver);

            myUI.PrintTableHeaders(Uiprep.GetHeaderStringsForDrivers(), Uiprep.GetMaxStringLengthForDrivers());

            foreach (var driver in jobSeekingDrivers)
                myUI.PrintTable(Uiprep.FileStringsAsListForDrivers(driver).ToArray(),
                    Uiprep.GetMaxStringLengthForDrivers());
            do
            {
                Console.WriteLine("Kaufe einen Truck mit 1-{0} oder kehre zurück mit z", jobSeekingDrivers.Count);
                selectionIsValid = true;
                selection = Console.ReadKey(true);
                var test = Convert.ToChar(jobSeekingDrivers.Count.ToString());
                if ((selection.KeyChar < '1' ||
                     selection.KeyChar > Convert.ToChar(jobSeekingDrivers.Count.ToString())) &&
                    !'z'.Equals(selection.KeyChar))
                {
                    selectionIsValid = false;
                    Console.WriteLine("Ungültige Eingabe!");
                    //.ReadKey(true);
                }
            } while (!selectionIsValid);

            if (!'z'.Equals(selection.KeyChar)) employDriver(activeCompany, selection.KeyChar.ToString());
        }

        private void employDriver(Company activeCompany, string selectedDriverId)
        {
            var selectedDriverIdAsInt = Convert.ToInt32(selectedDriverId) - 1;
            activeCompany.AddDriverToEmployedDriversList(jobSeekingDrivers[selectedDriverIdAsInt]);
            RemoveDriverFromMarket(selectedDriverIdAsInt);
        }

        private void RemoveDriverFromMarket(int selectedDriverId)
        {
            jobSeekingDrivers.RemoveAt(selectedDriverId);
            UpdateJobSeekingDriversIds();
        }

        private static void UpdateJobSeekingDriversIds()
        {
            var newID = 1;
            foreach (var driver in jobSeekingDrivers) driver.SetID(newID++);
        }
    }
}