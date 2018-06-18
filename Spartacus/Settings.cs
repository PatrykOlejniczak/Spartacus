using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<string> Output { get; }

        [Option("sheets", Required = false, HelpText = "List with names of sheets in each result file. Default is benchmark name.")]
        public List<string> Sheets { get; }

        [Option('l', "linearextension", Required = false, HelpText = "Sets whether to generate linear dependencies between variables.")]
        public bool LinearExtension { get; }

        [Option('q', "quadraticextension", Required = false, HelpText = "Sets whether to generate quadratic dependencies between variables.")]
        public bool QuadraticExtension { get; }

        public Settings(string benchmark, int points, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension)
        {
            Benchmark = benchmark;
            Points = points;
            LinearExtension = linearExtension;
            QuadraticExtension = quadraticExtension;

            OutputPath = outputPath ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            Output = output != null ? output.ToList() : new List<string>() { Benchmark };
            Sheets = sheets != null ? sheets.ToList() : new List<string>() { Benchmark };
        }
    }
}
