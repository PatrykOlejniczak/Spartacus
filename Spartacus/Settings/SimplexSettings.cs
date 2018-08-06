using CommandLine;
using System.Collections.Generic;

namespace Spartacus.Settings
{
    [Verb("simplex")]
    public class SimplexSettings : BaseGeneratorSettings
    {
        public SimplexSettings(double constant, int dimension, int points, int? minimumFeasibles, int? maximumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(constant, dimension, points, minimumFeasibles, maximumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        { }
    }
}
