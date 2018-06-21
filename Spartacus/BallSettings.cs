using CommandLine;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus
{
    [Verb("ball")]
    public class BallSettings : Settings
    {
        [Option("radius", Required = true, HelpText = "Radius of the ball.")]
        public double Radius { get; }

        [Option("center", Required = true, HelpText = "Center of the ball.")]
        public List<double> Center { get; }

        public BallSettings(double radius, IEnumerable<double> center, int points, string outputPath, IEnumerable<string> output, IEnumerable<string> sheets, bool linearExtension, bool quadraticExtension, int seed)
            : base(points, outputPath, output, sheets, linearExtension, quadraticExtension, seed)
        {
            Radius = radius;

            Center = center != null ? center.ToList() : new List<double>() { };
        }
    }
}
