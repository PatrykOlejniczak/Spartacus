using Spartacus.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Common
{
    public static class DisplayExtensions
    {
        private const int ColumnSize = 4;
        private const char VerticalSeparator = '|';

        public static void ConsoleDisplay(this IEnumerable<Example> examples)
        {
            var columns = examples.First().Variables.Count;
            var width = (columns + 1) * ColumnSize;

            DisplayVariableTitles(examples, width);

            DisplayVaraiblesValues(examples, width);
        }

        private static void DisplayVariableTitles(IEnumerable<Example> examples, int width)
        {
            string output = String.Empty;
            if (examples.Any())
            {
                foreach (var variable in examples.First().Variables)
                {
                    output += $"{VerticalSeparator} {variable.Schema.Symbol.PadBoth(width)} ";
                }
            }
            output += VerticalSeparator + "Type".PadBoth(width) + VerticalSeparator + Environment.NewLine;

            Console.Write(output);
        }

        private static void DisplayVaraiblesValues(IEnumerable<Example> examples, int width)
        {
            string output = String.Empty;
            foreach (var example in examples)
            {
                foreach (var variable in example.Variables)
                {
                    output += $"{VerticalSeparator} {variable.Value.ToString("0.##").PadBoth(width)} ";
                }

                output += VerticalSeparator + example.ExampleType.ToString().PadBoth(width) + VerticalSeparator + Environment.NewLine;
            }

            Console.Write(output);
        }

        private static string PadBoth(this string source, int length)
        {
            int spaces = length - source.Length;
            int padLeft = spaces / 2 + source.Length;

            return source.PadLeft(padLeft).PadRight(length);
        }
    }
}
