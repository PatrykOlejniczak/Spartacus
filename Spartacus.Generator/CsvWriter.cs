using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Spartacus.Common;

namespace Spartacus.Generator
{
    public class CsvWriter : IExampleStorage
    {
        private readonly string directoryPath;

        public CsvWriter(string directoryPath = "")
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            }

            this.directoryPath = directoryPath;
        }

        public void Save(IList<Example> examples, string fileName = "")
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                fileName = DateTime.Now.ToString("yyyy-dd-MM-HH-mm-ss") + ".csv";
            }

            var csv = examples.Select(example => example.ToString());

            File.WriteAllText(Path.Combine(directoryPath, fileName), string.Join("\n", csv));
        }
    }
}