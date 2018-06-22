using CommandLine;
using System.Collections.Generic;

namespace Spartacus
{
    [Verb("simplex")]
    public class SimplexSettings : Settings
    {
        [Option("constant", Required = true, HelpText = "Constant of the cube.")]
        public double Constant { get; }

        [Option("dimension", Required = true, HelpText = "Dimension of the cube.")]
        public int Dimension { get; }

        public SimplexSettings(double constant, int dimension, int points, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed)
            : base(points, outputPath, output, sheets, linearExtension, quadraticExtension, seed)
        {
            Constant = constant;
            Dimension = dimension;
        }
    }
}
