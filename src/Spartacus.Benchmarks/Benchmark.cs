using Spartacus.Common;
using Spartacus.Common.Constraints;
using System;
using System.Collections.Generic;

namespace Spartacus.Benchmarks
{
    public abstract class Benchmark
    {
        public string Name { get; }

        protected List<VariableSchema> SafeVariableSchemas { get; } = new List<VariableSchema>();
        protected List<BaseConstraint> SafeConstraints { get; } = new List<BaseConstraint>();

        public IReadOnlyList<VariableSchema> VariableSchemas => SafeVariableSchemas.AsReadOnly();
        public IReadOnlyList<BaseConstraint> Constraints => SafeConstraints.AsReadOnly();

        protected Benchmark()
        {
            Name = this.GetType().Name;
        }

        protected Benchmark(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            };

            Name = name;
        }
    }
}