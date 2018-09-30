using Spartacus.Common.Constraints;
using Spartacus.Common.Extensions;
using Spartacus.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Common
{
    public class Example
    {
        public ExampleType ExampleType { get; private set; }
        public List<Variable> Variables { get; }

        public Example(IList<Variable> variables)
        {
            if (variables == null)
            {
                throw new ArgumentNullException(nameof(variables));
            }

            ExampleType = ExampleType.Undefined;
            Variables = new List<Variable>(variables);
        }

        public void Validate(IEnumerable<BaseConstraint> constraints)
        {
            ExampleType = ExampleType.Infeasible;

            var groups = constraints.GroupBy(constraint => constraint.GroupId);

            foreach (var group in groups)
            {
                foreach (var constraint in group)
                {
                    if (!constraint.Verify(Variables.ToList()))
                    {
                        ExampleType = ExampleType.Infeasible;
                        break;
                    }
                    ExampleType = ExampleType.Feasible;
                }

                if (ExampleType == ExampleType.Feasible)
                    break;
            }

        }

        public override string ToString()
        {  
            //TODO Maybe instead string.Replace do it with some more elegant way
            return string.Join(",", Variables.Select(e => e.Value.ToString().Replace(',', '.'))) + "," + ExampleType.Check(ExampleType.Feasible);
        }
    }
}