using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Common
{
    public class Constraint : IConstraint
    {
        public IDictionary<VariableSchema, double> Weights { get; }
        public Comparison Comparison { get; }
        public double Constant { get; }

        public Constraint(double constant, Comparison comparison)
        {
            Constant = constant;
            Comparison = comparison;

            Weights = new Dictionary<VariableSchema, double>();
        }

        public Constraint(double constant, Comparison comparison, IDictionary<VariableSchema, double> weights)
        {
            Constant = constant;
            Comparison = comparison;

            Weights = weights;
        }

        public bool Verify(IList<Variable> variables)
        {
            var leftSide = 0.0;

            foreach (var weight in Weights)
            {
                var value = variables.SingleOrDefault(v => v.Schema.Symbol.Equals(weight.Key.Symbol)).Value;

                leftSide += value * weight.Value;
            }

            return Comparison.Verify(leftSide, Constant);
        }
    }
}