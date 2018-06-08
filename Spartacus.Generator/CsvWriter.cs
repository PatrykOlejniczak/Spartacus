using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;
using Spartacus.Common;

namespace Spartacus.Generator
{
    public class CsvWriter
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

        public void Save(IList<Example> learn, IList<Example> learnValidation, IList<Example> validation, string fileName = "")
        {
            List<string[]> headerRow = new List<string[]>()
            {
                new string[] { "X1", "X2", "Y" }
            };

            using (var excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("learn_dataset");
                excel.Workbook.Worksheets.Add("learn_validation_dataset");
                excel.Workbook.Worksheets.Add("validation_dataset");

                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";

                // Target a worksheet
                var csv = learn.Select(example => example.ToString()).ToArray();
                var worksheet = excel.Workbook.Worksheets["learn_dataset"];
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                for (int i = 0; i < csv.Count(); i++)
                {
                    worksheet.Cells[2 + i, 1].LoadFromText(csv[i]);
                }



                csv = learnValidation.Select(example => example.ToString()).ToArray();
                worksheet = excel.Workbook.Worksheets["learn_validation_dataset"];
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                for (int i = 0; i < csv.Count(); i++)
                {
                    worksheet.Cells[2 + i, 1].LoadFromText(csv[i]);
                }

                csv = validation.Select(example => example.ToString()).ToArray();
                worksheet = excel.Workbook.Worksheets["validation_dataset"];
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);
                for (int i = 0; i < csv.Count(); i++)
                {
                    worksheet.Cells[2 + i, 1].LoadFromText(csv[i]);
                }

                var excelFile = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName));
                excel.SaveAs(excelFile);
            }
        }
    }
}