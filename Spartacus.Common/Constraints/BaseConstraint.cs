using System.Collections.Generic;

namespace Spartacus.Common.Constraints
{
    public abstract class BaseConstraint
    {
        public IDictionary<VariableSchema, double> Weights { get; }
        public ComparisonKind ComparisonKind { get; }
        public double Constant { get; }

        public BaseConstraint(double constant, ComparisonKind comparisonKind, IDictionary<VariableSchema, double> weights = null)
        {
            Constant = constant;
            ComparisonKind = comparisonKind;

            Weights = weights ?? new Dictionary<VariableSchema, double>();
        }

        public abstract bool Verify(IList<Variable> variables);
    }
}