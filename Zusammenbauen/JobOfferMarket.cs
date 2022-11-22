using System.Collections.Generic;

namespace Zusammenbauen
{
    internal class JobOfferMarket
    {
        private static readonly List<Job> jobOffers = new List<Job>();

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
    }
}