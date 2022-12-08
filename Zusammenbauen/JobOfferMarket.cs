using System;
using System.Collections.Generic;
using static Zusammenbauen.Businesslogic;
using static Zusammenbauen.UIpreparator;
using static Zusammenbauen.UI;

namespace Zusammenbauen
{
    public class JobOfferMarket
    {
        private static readonly List<Job> jobOffers = new List<Job>();
        private static readonly NameFileHandler nameHandling = new NameFileHandler();
        private static ConsoleKeyInfo selection;
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
            ConsoleKeyInfo selectedJobOfferId;
            PrintListOfJobs(jobOffers);
            selectedJobOfferId = SelectJob();
            if (!'z'.Equals(selectedJobOfferId.KeyChar))
                acceptJob(activeCompany, selectedJobOfferId.KeyChar.ToString(), jobOffers);
        }

        public static ConsoleKeyInfo SelectJob()
        {
            ConsoleKeyInfo selection;
            bool selectionIsValid;
            do
            {
                Console.WriteLine("Wählen Sie mit 1-{0} einen Auftrag aus oder kehren Sie zurück mit z",
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

            return selection;
        }


        public List<Job> GetListOfJobOffers()
        {
            return jobOffers;
        }
    }
}