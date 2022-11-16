using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Zusammenbauen
{
    internal class NameFileHandler
    {
        private readonly string[] extractedName =
            File.ReadAllLines(@"names.txt");

        private readonly List<string> forenamesList = new List<string>();
        private readonly Random index = new Random();
        private readonly List<string> surnamesList = new List<string>();

        public string GetRandomForename()
        {
            var forenames = forenamesList.ToArray();
            return forenames[index.Next(forenames.Length)];
        }

        public string GetRandomSurname()
        {
            var surnames = surnamesList.ToArray();
            return surnames[index.Next(surnames.Length)];
        }

        public void SplitForenameSurnameList()
        {
            foreach (var line in extractedName)
            {
                var nameArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                forenamesList.Add(nameArray[0]);
                surnamesList.Add(nameArray[1]);
            }
        }
    }
}
