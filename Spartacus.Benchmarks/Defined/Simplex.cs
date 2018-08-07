using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;
using System;

namespace Spartacus.Benchmarks.Defined
{
    public class Simplex : Benchmark
    {
        public Simplex(int dimension, double constant, int modules = 1)
        {
            double tangens = Math.Tan(Math.PI / 12);
            double cotangens = 1.0 / tangens;


            for (var index = 1; index <= dimension; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index,
                                        minValue: -1,
                                        maxValue: 2 * modules + constant));
            }

            for (int module = 1; module <= modules; module++)
            {
                var firstConstraint = new LinearTotalConstraint(module * constant, ComparisonKind.LessOrEqual, module);
                for (var index = 1; index <= dimension; index++)
                {
                    firstConstraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator());
                }
                SafeConstraints.Add(firstConstraint);

                for (int i = 0; i < dimension - 1; i++)
                {
                    var secondConstraint = new LinearTotalConstraint(2 * module - 2, ComparisonKind.GreaterOrEqual, module);
                    secondConstraint.Modificators.Add(SafeVariableSchemas[i], new Modificator(cotangens, 0));
                    secondConstraint.Modificators.Add(SafeVariableSchemas[i + 1], new Modificator((-1) * tangens, 0));
                    SafeConstraints.Add(secondConstraint);

                    var thirdConstraint = new LinearTotalConstraint(2 * module - 2, ComparisonKind.GreaterOrEqual, module);
                    thirdConstraint.Modificators.Add(SafeVariableSchemas[i + 1], new Modificator(cotangens, 0));
                    thirdConstraint.Modificators.Add(SafeVariableSchemas[i], new Modificator((-1) * tangens, 0));
                    SafeConstraints.Add(thirdConstraint);
                }
            }
        }
    }
}