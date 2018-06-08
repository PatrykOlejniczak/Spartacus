using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Circle : Cartesian2DBenchamark
    {
        public Circle()
        {
            var constraint = new SquarePowerConstraint(4000, ComparisonKind.LessOrEqual);
            constraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            constraint.Weights.Add(SafeVariableSchemas[1], 1.0);

            SafeConstraints.Add(constraint);
        }

        public Circle(double max, double min, double diameter)
            : base(min, max)
        {
            var constraint = new SquarePowerConstraint(diameter, ComparisonKind.LessOrEqual);
            constraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            constraint.Weights.Add(SafeVariableSchemas[1], 1.0);

            SafeConstraints.Add(constraint);
        }
    }
}