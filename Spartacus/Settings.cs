using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace Spartacus
{
    public class Settings
    {
        [Option('b', "benchamark", Required = true, HelpText = "Benchmark name.")]
        public string Benchmark { get; }

        [Option('p', "points", Required = true, HelpText = "Number of points to be drawn.")]
        public int Points { get; }

        [Option("outputpath", Required = false, HelpText = "Path to the place where the resulting files are saved. Default is user profile.")]
        public string OutputPath { get; }

        [Option("output", Required = false, HelpText = "List with the result file names. Default is benchmark name.")]
        public IEnumerable<string> Output { get; }

        [Option("sheets", Required = false, HelpText = "List with names of sheets in each result file. Default is benchmark name.")]
        public IEnumerable<string> Sheets { get; }

        public Settings(string benchmark, int points, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets)
        {
            Benchmark = benchmark;
            Points = points;

            OutputPath = outputPath ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Output = output.Count() != 0 ? output : new List<string>() { Benchmark };
            Sheets = sheets.Count() != 0 ? sheets : new List<string>() { Benchmark }; ;
        }
    }
}
