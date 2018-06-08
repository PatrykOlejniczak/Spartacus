using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Common
{
    public class SquarePowerConstraint : BaseConstraint
    {
        public SquarePowerConstraint(double constant, ComparisonKind comparisonKind)
            : base(constant, comparisonKind)
        { }

        public SquarePowerConstraint(double constant, ComparisonKind comparisonKind, IDictionary<VariableSchema, double> weights)
            : base(constant, comparisonKind, weights)
        { }

        public override bool Verify(IList<Variable> variables)
        {
            var leftSide = 0.0;

            foreach (var weight in Weights)
            {
                var value = variables.Single(v => v.Schema.Symbol.Equals(weight.Key.Symbol)).Value;

                leftSide += Math.Pow(value, 2) * weight.Value;
            }

            return ComparisonKind.Verify(leftSide, Constant);
        }
    }
}