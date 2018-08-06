using System.Collections.Generic;
using CommandLine;

namespace Spartacus.Settings
{
    [Verb("cube")]
    public class CubeSettings : BaseGeneratorSettings
    {
        public CubeSettings(double constant, int dimension, int points, int minimumFeasibles, int maximumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(constant, dimension, points, minimumFeasibles, maximumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        { }
    }
}
