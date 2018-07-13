using CommandLine;
using System.Collections.Generic;

namespace Spartacus
{
    [Verb("simplex")]
    public class SimplexSettings : BaseGeneratorSettings
    {
        public SimplexSettings(double constant, int dimension, int points, int minimumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(constant, dimension, points, minimumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        { }
    }
}
