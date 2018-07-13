using CommandLine;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus
{
    [Verb("ball")]
    public class BallSettings : BaseGeneratorSettings
    {
        [Option("radius", Required = true, HelpText = "Radius of the ball.")]
        public double Radius { get; }

        [Option("center", Required = true, HelpText = "Center of the ball.")]
        public List<double> Center { get; }

        public BallSettings(double radius, IEnumerable<double> center, int minimumFeasibles, int points, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(radius, center.Count(), points, minimumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        {
            Radius = radius;

            Center = center != null ? center.ToList() : new List<double>();
        }
    }
}
