using CommandLine;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Settings
{
    [Verb("ball")]
    public class BallSettings : BaseGeneratorSettings
    {
        [Option("center", Required = false, HelpText = "Center of the ball.")]
        public List<double> Center { get; }

        [Option("radius", Default = 2.7, Required = false, HelpText = "Radius of the ball.")]
        public double Radius { get; }

        //TODO Fix that Constant and radius is same! and dimensions is get from center point parameters!
        public BallSettings(IEnumerable<double> center, double radius, double constant, int dimension, int points, int? minimumFeasibles, int? maximumFeasibles, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed, int elements)
            : base(radius, center.Count(), points, minimumFeasibles, maximumFeasibles, outputPath, output, sheets, linearExtension, quadraticExtension, seed, elements)
        {
            Radius = radius;

            Center = center != null ? center.ToList() : new List<double>();
        }
    }
}
