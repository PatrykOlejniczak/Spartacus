using System;

namespace Spartacus.Generator.Randoms
{
    public class RandomWrapper : IRandomNumberGenerator
    {
        private readonly Random random;

        public RandomWrapper(int seed = 0)
        {
            random = new Random(seed);
        }

        public double NextDouble(double min, double max)
        {
            return random.NextDouble() * (max - min) + min;
        }
    }
}