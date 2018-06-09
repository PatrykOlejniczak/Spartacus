using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class DoubleRectangle : Cartesian2D
    {
        public DoubleRectangle()
        {
            var firstRectangleLeftConstraint = new LinearConstraint(-50, ComparisonKind.GreaterOrEqual, 1);
            firstRectangleLeftConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            firstRectangleLeftConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(firstRectangleLeftConstraint);

            var firstRectangleRigthContraint = new LinearConstraint(10, ComparisonKind.LessOrEqual, 1);
            firstRectangleRigthContraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            firstRectangleRigthContraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(firstRectangleRigthContraint);

            var firstRectangleBottomConstraint = new LinearConstraint(-50, ComparisonKind.GreaterOrEqual, 1);
            firstRectangleBottomConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            firstRectangleBottomConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(firstRectangleBottomConstraint);

            var firstRectangleTopConstraint = new LinearConstraint(10, ComparisonKind.LessOrEqual, 1);
            firstRectangleTopConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            firstRectangleTopConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(firstRectangleTopConstraint);

            var secondRectangleLeftConstraint = new LinearConstraint(-10, ComparisonKind.GreaterOrEqual, 2);
            secondRectangleLeftConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            secondRectangleLeftConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(secondRectangleLeftConstraint);

            var secondtRectangleRigthContraint = new LinearConstraint(50, ComparisonKind.LessOrEqual, 2);
            secondtRectangleRigthContraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 0));
            secondtRectangleRigthContraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(0, 0));
            SafeConstraints.Add(secondtRectangleRigthContraint);

            var secondRectangleBottomConstraint = new LinearConstraint(-10, ComparisonKind.GreaterOrEqual, 2);
            secondRectangleBottomConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            secondRectangleBottomConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(secondRectangleBottomConstraint);

            var secondRectangleTopConstraint = new LinearConstraint(50, ComparisonKind.LessOrEqual, 2);
            secondRectangleTopConstraint.Modificators.Add(SafeVariableSchemas[0], new Modificator(0, 0));
            secondRectangleTopConstraint.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 0));
            SafeConstraints.Add(secondRectangleTopConstraint);
        }
    }
}
