using Spartacus.Common;

namespace Spartacus.Benchmarks.Defined
{
    public class Plane : Benchmark
    {
        public Plane(int dimension = 2, double min = -10, double max = 10)
        {
            for (var index = 1; index <= dimension; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index, minValue: min, maxValue: max));
            }
        }
    }
}