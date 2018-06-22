using System;
using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Simplex : Benchmark
    {
        public Simplex(int dimension, double constant)
        {
            double tangens = Math.Tan(15.0 * Math.PI / 180.0);
            double cotangens = 1.0 / tangens;

            var firstConstraint = new LinearConstraint(constant, ComparisonKind.LessOrEqual);
            for (var index = 1; index <= dimension; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index,
                                                           minValue: -1,
                                                           maxValue: 2 + constant));
                firstConstraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator());
            }
            SafeConstraints.Add(firstConstraint);

            for (int i = 0; i < dimension - 1; i++)
            {
                var secondConstraint = new LinearConstraint(0, ComparisonKind.GreaterOrEqual);
                secondConstraint.Modificators.Add(SafeVariableSchemas[i], new Modificator(cotangens, 0));
                secondConstraint.Modificators.Add(SafeVariableSchemas[i + 1], new Modificator((-1) * tangens, 0));
                SafeConstraints.Add(secondConstraint);

                var thirdConstraint = new LinearConstraint(0, ComparisonKind.GreaterOrEqual);
                thirdConstraint.Modificators.Add(SafeVariableSchemas[i + 1], new Modificator(cotangens, 0));
                thirdConstraint.Modificators.Add(SafeVariableSchemas[i], new Modificator((-1) * tangens, 0));
                SafeConstraints.Add(thirdConstraint);
            }
        }
    }
}