using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Cube : Benchmark
    {
        public Cube(int dimension, double constant)
        {
            for (var index = 1; index <= dimension; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index, minValue: index - index * constant, maxValue: index + 2 * index * constant));

                var minConstraint = new LinearConstraint(index, ComparisonKind.GreaterOrEqual);
                minConstraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator());
                SafeConstraints.Add(minConstraint);

                var maxConstraint = new LinearConstraint(index + index * dimension, ComparisonKind.LessOrEqual);
                maxConstraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator());
                SafeConstraints.Add(maxConstraint);
            }
        }
    }
}