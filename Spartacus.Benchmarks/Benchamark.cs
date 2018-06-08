using System;
using System.Collections.Generic;
using Spartacus.Common;
using Spartacus.Common.Constraints;

namespace Spartacus.Benchmarks
{
    public class Benchamark
    {
        public string Name { get; }

        protected List<VariableSchema> SafeVariableSchemas { get; } = new List<VariableSchema>();
        protected List<BaseConstraint> SafeConstraints { get; } = new List<BaseConstraint>();

        public IReadOnlyList<VariableSchema> VariableSchemas => SafeVariableSchemas.AsReadOnly();
        public IReadOnlyList<BaseConstraint> Constraints => SafeConstraints.AsReadOnly();

        protected Benchamark()
        {
            Name = this.GetType().Name;
        }

        protected Benchamark(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            };

            Name = name;
        }
    }
}