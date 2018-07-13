using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus
{
    public abstract class BaseGeneratorSettings
    {
        public string Benchmark { get; }

        [Option("constant", Default = 2.7, Required = false, HelpText = "Constant of the cube.")]
        public double Constant { get; }

        [Option("dimension", Default = 2, Required = false, HelpText = "Dimension of the cube.")]
        public int Dimension { get; }

        [Option('p', "points", Required = true, HelpText = "Number of points to be drawn.")]
        public int Points { get; }

        [Option("minimumFeasibles", Required = false, Default = 0, HelpText = "Determinate minimum feasible states in every sheet.")]
        public int MinimumFeasibles { get; }

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

        [Option("seed", Required = false, HelpText = "Seed number.")]
        public int Seed { get; }

        [Option("elements", Required = false, Default = 1, HelpText = "Elements number.")]
        public int Elements { get; }

        protected BaseGeneratorSettings(double constant, int dimension, int points, int minimumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
        {
            Benchmark = this.GetType().Name;

            Constant = constant;
            Dimension = dimension;

            Points = points;
            LinearExtension = linearExtension;
            QuadraticExtension = quadraticExtension;

            Seed = seed;
            Elements = elements;
            MinimumFeasibles = minimumFeasibles;

            OutputPath = outputPath ?? Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            Output = output != null ? output.ToList() : new List<string>() { $"{Benchmark}_{elements}n_{dimension}_{seed}" };
            Sheets = sheets != null ? sheets.ToList() : new List<string>() { Benchmark };
        }
    }
}
