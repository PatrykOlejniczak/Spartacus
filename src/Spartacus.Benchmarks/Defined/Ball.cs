using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;
using System;

namespace Spartacus.Benchmarks.Defined
{
    public class Ball : Benchmark
    {
        public Ball(double radius, int modules, params double[] center)
        {
            for (var index = 1; index <= center.Length; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index,
                                                           minValue: index - 2 * radius,
                                                           maxValue: index + Constance(modules, radius) + 2 * radius));
            }

            for (int module = 1; module <= modules; module++)
            {
                var constraint = new SquarePowerConstraint(Math.Pow(radius, 2), ComparisonKind.LessOrEqual, module);

                for (var index = 1; index <= center.Length; index++)
                {
                    constraint.Modificators.Add(SafeVariableSchemas[index - 1],
                                                new Modificator(1, (center[index - 1] - index - Constance(module, radius, index))));
                }

                SafeConstraints.Add(constraint);
            }
        }

        private double Constance(double module, double radius, int index = 1)
        {
            return ((double)2 * Math.Sqrt(6) * (module - 1) * radius) / (index * Math.PI);
        }
    }
}