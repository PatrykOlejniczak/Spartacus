using CommandLine;
using System.Collections.Generic;

namespace Spartacus
{
    [Verb("cube")]
    public class CubeSettings : BaseSettings
    {
        [Option("constant", Required = true, HelpText = "Constant of the cube.")]
        public double Constant { get; }

        [Option("dimension", Required = true, HelpText = "Dimension of the cube.")]
        public int Dimension { get; }

        public CubeSettings(double constant, int dimension, int points, bool onlyFeasible, int minimumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(points, onlyFeasible, minimumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        {
            Constant = constant;
            Dimension = dimension;
        }
    }
}
