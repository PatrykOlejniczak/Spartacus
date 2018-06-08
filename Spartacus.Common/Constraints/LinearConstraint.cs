using System.Collections.Generic;
using System.Linq;
using Spartacus.Common.Extensions;

namespace Spartacus.Common.Constraints
{
    public class LinearConstraint : BaseConstraint
    {
        public LinearConstraint(double constant, ComparisonKind comparisonKind)
            : base(constant, comparisonKind)
        { }

        public LinearConstraint(double constant, ComparisonKind comparisonKind, IDictionary<VariableSchema, double> weights)
            : base(constant, comparisonKind, weights)
        { }

        public override bool Verify(IList<Variable> variables)
        {
            var leftSide = 0.0;

            foreach (var weight in Weights)
            {
                var value = variables.Single(v => v.Schema.Symbol.Equals(weight.Key.Symbol)).Value;

                leftSide += value * weight.Value;
            }

            return ComparisonKind.Verify(leftSide, Constant);
        }
    }
}