using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;
using System;

namespace Spartacus.Benchmarks.Defined
{
    public class Ball : Benchmark
    {
        public Ball(double radius, params double[] center)
        {
            var constraint = new SquarePowerConstraint(Math.Pow(radius, 2), ComparisonKind.LessOrEqual);

            for (var index = 1; index <= center.Length; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index, minValue: index - 2 * radius, maxValue: index + 2 * radius));
                constraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator(1, center[index - 1] * (-1)));
            }

            SafeConstraints.Add(constraint);
        }
    }
}