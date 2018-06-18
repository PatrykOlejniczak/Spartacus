using Spartacus.Common.Extensions;
using Spartacus.Common.Types;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Common.Constraints
{
    public class LinearConstraint : BaseConstraint
    {
        public LinearConstraint(double constant, ComparisonKind comparisonKind)
            : base(constant, comparisonKind)
        { }

        public LinearConstraint(double constant, ComparisonKind comparisonKind, int groupId)
            : base(constant, comparisonKind, groupId)
        { }

        public override bool Verify(IList<Variable> variables)
        {
            var leftSide = 0.0;

            foreach (var modificator in Modificators)
            {
                var value = variables.Single(v => v.Schema.Symbol.Equals(modificator.Key.Symbol)).Value;

                leftSide += (value * modificator.Value.Weight) + modificator.Value.Shift;
            }

            return ComparisonKind.Verify(leftSide, Constant);
        }
    }
}