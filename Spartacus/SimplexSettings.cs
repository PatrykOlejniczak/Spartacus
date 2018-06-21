using CommandLine;
using System.Collections.Generic;

namespace Spartacus
{
    [Verb("simplex")]
    public class SimplexSettings : Settings
    {
        [Option("dimension", Required = true, HelpText = "Dimension of the cube.")]
        public int Dimension { get; }

        public SimplexSettings(int points, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int dimension)
            : base(points, outputPath, output, sheets, linearExtension, quadraticExtension, seed)
        {
            Dimension = dimension;
        }
    }
}
