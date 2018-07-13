using CommandLine;
using System.Collections.Generic;

namespace Spartacus
{
    [Verb("cube")]
    public class CubeSettings : BaseGeneratorSettings
    {
        public CubeSettings(double constant, int dimension, int points, int minimumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(constant, dimension, points, minimumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        { }
    }
}
