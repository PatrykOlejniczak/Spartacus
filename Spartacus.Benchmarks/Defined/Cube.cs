using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Cube : Benchmark
    {
        public Cube(int dimension, double constant, int modules = 1)
        {
            for (var index = 1; index <= dimension; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index, minValue: index - index * modules * constant, maxValue: index + 2 * index * modules * constant));

                for (var module = 1; module <= modules; module++)
                {
                    var minConstraint = new LinearConstraint(index * module, ComparisonKind.GreaterOrEqual, module);
                    minConstraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator());
                    SafeConstraints.Add(minConstraint);

                    var maxConstraint = new LinearConstraint(index * module + index * dimension, ComparisonKind.LessOrEqual, module);
                    maxConstraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator());
                    SafeConstraints.Add(maxConstraint);
                }
            }
        }
    }
}