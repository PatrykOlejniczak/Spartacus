using Spartacus.Common;

namespace Spartacus.Benchmarks.Defined
{
    public abstract class Cartesian2D : Benchmark
    {
        public Cartesian2D()
        {
            SafeVariableSchemas.Add(new VariableSchema("X1", -100, 100));
            SafeVariableSchemas.Add(new VariableSchema("X2", -100, 100));
        }

        public Cartesian2D(double min, double max)
        {
            SafeVariableSchemas.Add(new VariableSchema("X1", min, max));
            SafeVariableSchemas.Add(new VariableSchema("X2", min, max));
        }
    }
}