using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Spartacus.Common
{
    public class Example
    {
        public ExampleType ExampleType { get; private set; }
        public IReadOnlyCollection<Variable> Variables { get; }

        public Example(IList<Variable> variables)
        {
            if (variables == null)
            {
                throw new ArgumentNullException(nameof(variables));
            }

            ExampleType = ExampleType.Undefined;
            Variables = new ReadOnlyCollection<Variable>(variables);
        }

        public void Validate(IList<IConstraint> constraints)
        {
            ExampleType = ExampleType.Feasible;

            foreach (var constraint in constraints)
            {
                if (!constraint.Verify(Variables.ToList()))
                {
                    ExampleType = ExampleType.Infeasible;
                    break;
                }
            }
        }

        public override string ToString()
        {
            return string.Join(",", Variables.Select(e => e.Value)) + "," + ExampleType;
        }
    }
}