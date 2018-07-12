using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus
{
    public abstract class BaseSettings
    {
        public string Benchmark { get; }

        [Option('p', "points", Required = true, HelpText = "Number of points to be drawn.")]
        public int Points { get; }

        [Option("onlyFeasible", Required = false, Default = false, HelpText = "Save only feasible state examples.")]
        public bool OnlyFeasible { get; }

        [Option("minimumFeasibles", Required = false, Default = 0, HelpText = "Determinate minimum feasible states in every sheet.")]
        public int MinimumFeasibles { get; }

        [Option("outputpath", Required = false, HelpText = "Path to the place where the resulting files are saved. Default is user profile.")]
        public string OutputPath { get; }

        [Option("output", Required = false, HelpText = "List with the result file names. Default is benchmark name.")]
        public List<string> Output { get; protected set;  }

        [Option("sheets", Required = false, HelpText = "List with names of sheets in each result file. Default is benchmark name.")]
        public List<string> Sheets { get; }

        [Option('l', "linearextension", Required = false, HelpText = "Sets whether to generate linear dependencies between variables.")]
        public bool LinearExtension { get; }

        [Option('q', "quadraticextension", Required = false, HelpText = "Sets whether to generate quadratic dependencies between variables.")]
        public bool QuadraticExtension { get; }

        [Option("seed", Required = false, HelpText = "Seed number.")]
        public int Seed { get; }

        [Option("elements", Required = false, Default = 1, HelpText = "Elements number.")]
        public int Elements { get; }

        public BaseSettings(int points, bool onlyFeasible, int minimumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
        {
            Benchmark = this.GetType().Name;

            Points = points;
            LinearExtension = linearExtension;
            QuadraticExtension = quadraticExtension;

            Seed = seed;
            Elements = elements;
            OnlyFeasible = onlyFeasible;
            MinimumFeasibles = minimumFeasibles;

            OutputPath = outputPath ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            Output = output != null ? output.ToList() : new List<string>() { Benchmark };
            Sheets = sheets != null ? sheets.ToList() : new List<string>() { Benchmark };
        }
    }
}
