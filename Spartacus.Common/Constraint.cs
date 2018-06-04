using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Common
{
    public class SquareConstraint : Constraint
    {
        public SquareConstraint(double constant, Comparison comparison)
            : base(constant, comparison)
        { }

        public SquareConstraint(double constant, Comparison comparison, IDictionary<VariableSchema, double> weights)
            : base(constant, comparison, weights)
        { }

        public override bool Verify(IList<Variable> variables)
        {
            var leftSide = 0.0;

            foreach (var weight in Weights)
            {
                var value = variables.SingleOrDefault(v => v.Schema.Symbol.Equals(weight.Key.Symbol)).Value;

                leftSide += Math.Pow(value, 2) * weight.Value;
            }

            return Comparison.Verify(leftSide, Constant);
        }
    }

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

        public virtual bool Verify(IList<Variable> variables)
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