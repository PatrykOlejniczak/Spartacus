using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;
using System;

namespace Spartacus.Benchmarks.Defined
{
    public class Simplex : Benchmark
    {
        public static readonly double Tangens = Math.Tan(Math.PI / 12);
        public static readonly double Cotangens = 1.0 / Tangens;

        public Simplex(int dimension, double constant, int modules = 1)
        {
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

                for (int i = 0; i < dimension; i++)
                {
                    for (int j = i + 1; j < dimension; j++)
                    {
                        var secondConstraint =
                                new LinearTotalConstraint(2 * module - 2, ComparisonKind.GreaterOrEqual, module);
                        secondConstraint.Modificators.Add(SafeVariableSchemas[i], new Modificator(Cotangens, 0));
                        secondConstraint.Modificators.Add(SafeVariableSchemas[j], new Modificator((-1) * Tangens, 0));
                        SafeConstraints.Add(secondConstraint);

                        var thirdConstraint =
                                new LinearTotalConstraint(2 * module - 2, ComparisonKind.GreaterOrEqual, module);
                        thirdConstraint.Modificators.Add(SafeVariableSchemas[j], new Modificator(Cotangens, 0));
                        thirdConstraint.Modificators.Add(SafeVariableSchemas[i], new Modificator((-1) * Tangens, 0));
                        SafeConstraints.Add(thirdConstraint);
                    }
                }
            }
        }
    }
}