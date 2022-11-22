using System;
using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class JobOfferMarket
    {
        private static readonly List<Job> jobOffers = new List<Job>();
        private static readonly NameFileHandler nameHandling = new NameFileHandler();
        private static readonly UI myUI = new UI();
        private static ConsoleKeyInfo selection;
        private static readonly UIpreparator Uiprep = new UIpreparator();
        private Company activeCompany;

        public JobOfferMarket()
        {
            CreateListOfJobsOffered();
        }

        private static void CreateListOfJobsOffered()
        {
            for (var i = 0; i < 8; i++)
            {
                var jobIndex = i;
                jobIndex++;
                jobOffers.Add(new Job(jobIndex));
            }
        }

        public void OpenJobOfferMarket(Company activeCompany)
        {
            var selectionIsValid = true;
            foreach (var job in jobOffers) Uiprep.CalcMaxStringLengthForJobs(job);

            myUI.PrintTableHeaders(Uiprep.GetHeaderStringsForJobs(), Uiprep.GetMaxStringLengthForJobs());

            foreach (var job in jobOffers)
                myUI.PrintTable(Uiprep.FileStringsAsListForJobs(job).ToArray(),
                    Uiprep.GetMaxStringLengthForJobs());
            do
            {
                Console.WriteLine("Nehmen Sie mit 1-{0} einen Auftrag an oder kehren Sie zurück mit z",
                    jobOffers.Count);
                selectionIsValid = true;
                selection = Console.ReadKey(true);
                var test = Convert.ToChar(jobOffers.Count.ToString());
                if ((selection.KeyChar < '1' ||
                     selection.KeyChar > Convert.ToChar(jobOffers.Count.ToString())) &&
                    !'z'.Equals(selection.KeyChar))
                {
                    selectionIsValid = false;
                    Console.WriteLine("Ungültige Eingabe!");
                    //.ReadKey(true);
                }
            } while (!selectionIsValid);

            if (!'z'.Equals(selection.KeyChar)) acceptJob(activeCompany, selection.KeyChar.ToString());
        }

        private void acceptJob(Company activeCompany, string selectedJobId)
        {
            var selectedJobIdAsInt = Convert.ToInt32(selectedJobId) - 1;
            activeCompany.AddJobToPendingJobsList(jobOffers[selectedJobIdAsInt]);
            RemoveJobFromMarket(selectedJobIdAsInt);
        }

        private void RemoveJobFromMarket(int selectedDriverId)
        {
            jobOffers.RemoveAt(selectedDriverId);
            UpdateJobOfferIds();
        }

        private static void UpdateJobOfferIds()
        {
            var newID = 1;
            foreach (var job in jobOffers) job.SetID(newID++);
        }
    }
}