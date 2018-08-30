using Spartacus.Common.Extensions;
using Spartacus.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Common.Constraints
{
    public class SquarePowerConstraint : BaseConstraint
    {
        public SquarePowerConstraint(double constant, ComparisonKind comparisonKind)
            : base(constant, comparisonKind)
        { }

        public SquarePowerConstraint(double constant, ComparisonKind comparisonKind, int groupId)
            : base(constant, comparisonKind, groupId)
        { }

        public override bool Verify(IList<Variable> variables)
        {
            var leftSide = 0.0;

            foreach (var modificator in Modificators)
            {
                var value = variables.Single(v => v.Schema.Symbol.Equals(modificator.Key.Symbol)).Value;

                leftSide += (Math.Pow(value + modificator.Value.Shift , 2) * modificator.Value.Weight);
            }

            return ComparisonKind.Verify(leftSide, Constant);
        }

        public override string ToString()
        {
            var str = "";
            foreach (var modificator in Modificators)
            {
                if (Math.Abs(modificator.Value.Shift) > 0.01)
                {
                    str += $" + {modificator.Value.Weight} * ({modificator.Key.Symbol} + {modificator.Value.Shift})^2";
                }
                else
                {
                    str += $" + {modificator.Value.Weight} * {modificator.Key.Symbol}^2";
                }
            }

            return $"{str.Substring(3)} {ComparisonKind.GetDescription()} {Constant}";
        }
    }
}