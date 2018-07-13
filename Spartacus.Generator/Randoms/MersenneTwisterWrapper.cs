using System;

namespace Spartacus.Generator.Randoms
{
    public class MersenneTwisterWrapper : IRandomizer
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