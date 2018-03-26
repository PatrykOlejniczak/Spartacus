using System;
using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Benchmarks
{
    public class Benchamark
    {
        public string Name { get; }

        public IList<Variable> Variables { get; } = new List<Variable>();
        public IList<Constraint> Constraints { get; } = new List<Constraint>();

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