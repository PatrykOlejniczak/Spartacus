using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Circle : Cartesian2D
    {
        public Circle()
        {
            var constraint = new SquarePowerConstraint(4000, ComparisonKind.LessOrEqual);
            constraint.Modificators.Add(SafeVariableSchemas[0], new Modificator());
            constraint.Modificators.Add(SafeVariableSchemas[1], new Modificator());

            SafeConstraints.Add(constraint);
        }

        public Circle(double max, double min, double diameter)
            : base(min, max)
        {
            var constraint = new SquarePowerConstraint(diameter, ComparisonKind.LessOrEqual);
            constraint.Modificators.Add(SafeVariableSchemas[0], new Modificator());
            constraint.Modificators.Add(SafeVariableSchemas[1], new Modificator());

            SafeConstraints.Add(constraint);
        }
    }
}