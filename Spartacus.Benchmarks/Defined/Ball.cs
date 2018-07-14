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
            var constraint = new SquarePowerConstraint(Math.Pow(radius, 2), ComparisonKind.LessOrEqual);

            for (var index = 1; index <= center.Length; index++)
            {
                SafeVariableSchemas.Add(new VariableSchema("X" + index, minValue: index - 2 * radius, maxValue: index + 2 * radius));
                constraint.Modificators.Add(SafeVariableSchemas[index - 1], new Modificator(1, center[index - 1] * (-1)));
            }

            SafeConstraints.Add(constraint);
        }

        //TODO Alternative for multiple ball
        //public Ball(double radius, int modules, params double[] center)
        //{
        //    for (var index = 1; index <= center.Length; index++)
        //    {
        //        SafeVariableSchemas.Add(new VariableSchema("X" + index,
        //            minValue: index - 2 * radius,
        //            maxValue: index + Constance(modules, radius) + 2 * radius));
        //    }

        //    for (int i = 1; i <= modules; i++)
        //    {
        //        var constraint = new SquarePowerConstraint(Math.Pow(radius, 2), ComparisonKind.LessOrEqual, i);

        //        for (var index = 1; index <= center.Length; index++)
        //        {
        //            constraint.Modificators.Add(SafeVariableSchemas[index - 1],
        //                new Modificator(1, (center[index - 1] - Constance(modules, radius, i)) * (-1)));
        //        }

        //        SafeConstraints.Add(constraint);
        //    }
        //}

        //private double Constance(double modules, double radius, int index = 1)
        //{
        //    return ((double)2 * Math.Sqrt(6) * (modules - 1) * radius) / (index * Math.PI);
        //}
    }
}