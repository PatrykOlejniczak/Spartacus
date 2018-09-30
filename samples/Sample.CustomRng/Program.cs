using Spartacus.Benchmarks.Defined;
using Spartacus.Generator;
using Spartacus.Generator.Randoms;
using System;

namespace Sample.CustomRng
{
    public class Program
    {
        static void Main(string[] args)
        {
            var parameters =
                    new GenerateParameter(new Cube(2, 2.7), 100, randomNumberGenerator: new MersenneTwisterWrapper());

            var generator = new Engine(parameters);
            var examples = generator.Generate();

            foreach (var example in examples)
            {
                example.Variables.ForEach(c => Console.Write(c.Value + " "));
                Console.WriteLine();
            }

            Console.ReadKey();
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
