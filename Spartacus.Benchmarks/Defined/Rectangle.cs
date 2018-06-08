using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class Rectangle : Cartesian2D
    {
        public Rectangle()
        {
            var leftConstraint = new LinearConstraint(-40, ComparisonKind.GreaterOrEqual);
            leftConstraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            leftConstraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(leftConstraint);

            var rigthContraint = new LinearConstraint(40, ComparisonKind.LessOrEqual);
            rigthContraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            rigthContraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(rigthContraint);

            var bottomConstraint = new LinearConstraint(-40, ComparisonKind.GreaterOrEqual);
            bottomConstraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            bottomConstraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(bottomConstraint);

            var topConstraint = new LinearConstraint(40, ComparisonKind.LessOrEqual);
            topConstraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            topConstraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(topConstraint);
        }

        public Rectangle(double min, double max, double width, double height)
            : base(min, max)
        {
            var leftConstraint = new LinearConstraint((-1) * width / 2, ComparisonKind.GreaterOrEqual);
            leftConstraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            leftConstraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(leftConstraint);

            var rigthContraint = new LinearConstraint(width / 2, ComparisonKind.LessOrEqual);
            rigthContraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            rigthContraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(rigthContraint);

            var bottomConstraint = new LinearConstraint((-1) * height / 2, ComparisonKind.GreaterOrEqual);
            bottomConstraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            bottomConstraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(bottomConstraint);

            var topConstraint = new LinearConstraint(height / 2, ComparisonKind.LessOrEqual);
            topConstraint.Weights.Add(SafeVariableSchemas[0], 1.0);
            topConstraint.Weights.Add(SafeVariableSchemas[1], 0.0);
            SafeConstraints.Add(topConstraint);
        }
    }
}