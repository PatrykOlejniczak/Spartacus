﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace Spartacus.Generator.Storage.Excel
{
    public class ExcelStorage
    {
        private readonly string directoryPath;

        public ExcelStorage(string directoryPath)
        {
            if (string.IsNullOrWhiteSpace(directoryPath))
            {
                throw new ArgumentException(nameof(directoryPath));
            }

            this.directoryPath = directoryPath;
        }

        public void Save(IEnumerable<Sheet> sheets, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException(nameof(fileName));
            }

            if (sheets == null || !sheets.Any())
            {
                throw new ArgumentException(nameof(sheets));
            }

            using (var excel = new ExcelPackage())
            {
                foreach (var sheet in sheets)
                {
                    var headerRow = new List<string>();
                    headerRow.AddRange(sheet.Data.First().Variables.Select(v => v.Schema.Symbol));
                    headerRow.Add("Y");

                    excel.Workbook.Worksheets.Add(sheet.Name);

                    var csv = sheet.Data.Select(example => example.ToString()).ToArray();
                    var worksheet = excel.Workbook.Worksheets[sheet.Name];
                    worksheet.Cells.LoadFromArrays(new [] { headerRow.ToArray() });

                    for (int i = 0; i < csv.Count(); i++)
                    {
                        worksheet.Cells[2 + i, 1].LoadFromText(csv[i]);
                    }
                }

                var excelFile = new FileInfo(Path.Combine(directoryPath, fileName + ".xlsx"));
                excel.SaveAs(excelFile);
            }
        }
    }
}