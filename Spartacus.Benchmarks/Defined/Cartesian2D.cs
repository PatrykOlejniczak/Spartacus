using Spartacus.Common;

namespace Spartacus.Benchmarks.Defined
{
    public abstract class Cartesian2D : Benchmark
    {
        public Cartesian2D()
        {
            SafeVariableSchemas.Add(new VariableSchema("X1", minValue: -100, maxValue: 100));
            SafeVariableSchemas.Add(new VariableSchema("X2", minValue: -100, maxValue: 100));
        }

        public Cartesian2D(double min, double max)
        {
            SafeVariableSchemas.Add(new VariableSchema("X1", minValue: min, maxValue: max));
            SafeVariableSchemas.Add(new VariableSchema("X2", minValue: min, maxValue: max));
        }
    }
}