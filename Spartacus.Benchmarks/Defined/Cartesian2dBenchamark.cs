using Spartacus.Common;

namespace Spartacus.Benchmarks.Defined
{
    public class Cartesian2DBenchamark : Benchamark
    {
        public Cartesian2DBenchamark()
        {
            SafeVariableSchemas.Add(new VariableSchema("X1", -100, 100));
            SafeVariableSchemas.Add(new VariableSchema("X2", -100, 100));
        }

        public Cartesian2DBenchamark(double min, double max)
        {
            SafeVariableSchemas.Add(new VariableSchema("X1", min, max));
            SafeVariableSchemas.Add(new VariableSchema("X2", min, max));
        }
    }
}