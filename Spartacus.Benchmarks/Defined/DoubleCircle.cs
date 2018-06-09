using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;

namespace Spartacus.Benchmarks.Defined
{
    public class DoubleCircle : Cartesian2D
    {
        public DoubleCircle()
        {
            var firstCircle = new SquarePowerConstraint(2000, ComparisonKind.LessOrEqual, 0);
            firstCircle.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, -30));
            firstCircle.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, -30));

            SafeConstraints.Add(firstCircle);

            var secondCircle = new SquarePowerConstraint(2000, ComparisonKind.LessOrEqual, 1);
            secondCircle.Modificators.Add(SafeVariableSchemas[0], new Modificator(1, 30));
            secondCircle.Modificators.Add(SafeVariableSchemas[1], new Modificator(1, 30));

            SafeConstraints.Add(secondCircle);
        }
    }
}