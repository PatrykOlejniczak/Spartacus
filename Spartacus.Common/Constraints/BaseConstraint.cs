using Spartacus.Common.Types;
using System.Collections.Generic;

namespace Spartacus.Common.Constraints
{
    public abstract class BaseConstraint
    {
        public IDictionary<VariableSchema, Modificator> Modificators { get; }
        public ComparisonKind ComparisonKind { get; }
        public double Constant { get; }
        public int GroupId { get; }

        public BaseConstraint(double constant, ComparisonKind comparisonKind, int groupId = 0)
        {
            Constant = constant;
            ComparisonKind = comparisonKind;
            GroupId = groupId;

            Modificators = new Dictionary<VariableSchema, Modificator>();
        }

        public abstract bool Verify(IList<Variable> variables);
    }
}