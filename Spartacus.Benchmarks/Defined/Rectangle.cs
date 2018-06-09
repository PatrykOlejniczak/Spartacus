using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Rectangle : Cartesian2D
    {
        public Rectangle()
        {
            var leftConstraint = new LinearConstraint(-40, ComparisonKind.GreaterOrEqual);
            leftConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            leftConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(leftConstraint);

            var rigthContraint = new LinearConstraint(40, ComparisonKind.LessOrEqual);
            rigthContraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            rigthContraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(rigthContraint);

            var bottomConstraint = new LinearConstraint(-40, ComparisonKind.GreaterOrEqual);
            bottomConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            bottomConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(bottomConstraint);

            var topConstraint = new LinearConstraint(40, ComparisonKind.LessOrEqual);
            topConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            topConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(topConstraint);
        }

        public Rectangle(double min, double max, double width, double height)
            : base(min, max)
        {
            var leftConstraint = new LinearConstraint((-1) * width / 2, ComparisonKind.GreaterOrEqual);
            leftConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            leftConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(leftConstraint);

            var rigthContraint = new LinearConstraint(width / 2, ComparisonKind.LessOrEqual);
            rigthContraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            rigthContraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(rigthContraint);

            var bottomConstraint = new LinearConstraint((-1) * height / 2, ComparisonKind.GreaterOrEqual);
            bottomConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            bottomConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(bottomConstraint);

            var topConstraint = new LinearConstraint(height / 2, ComparisonKind.LessOrEqual);
            topConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            topConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(topConstraint);
        }
    }
}