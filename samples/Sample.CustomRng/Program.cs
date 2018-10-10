using Sample.Common;
using Spartacus.Benchmarks.Defined;
using Spartacus.Generator;
using Spartacus.Generator.Randoms;
using System;

namespace Sample.CustomRng
{
    /// <summary>
    /// Sample shows how to use custom RNG(Random Number genrator) on an example <see cref="MersenneTwister"/>.
    /// For this purpose is should be wrapper with implement <see cref="IRandomNumberGenerator"/>.
    /// By default, the implementation of <see cref="Random"/> is used.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var parameters =
                    new GenerateParameter(new Plane(), 10, randomNumberGenerator: new MersenneTwisterWrapper());

            var generator = new Engine(parameters);
            var examples = generator.Generate();

            examples.ConsoleDisplay();
        }
    }

    public class MersenneTwisterWrapper : IRandomNumberGenerator
    {
        private readonly Random random;

        public MersenneTwisterWrapper(int seed = 0)
        {
            random = MersenneTwister.Randoms.Create(seed);
        }

        public double NextDouble(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}
