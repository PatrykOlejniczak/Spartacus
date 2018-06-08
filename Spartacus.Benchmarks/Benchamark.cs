using System;
using System.Collections.Generic;
using Spartacus.Common;

namespace Spartacus.Benchmarks
{
    public class Benchamark
    {
        public string Name { get; }

        public IList<Variable> Variables { get; } = new List<Variable>();
        public IList<LinearConstraint> Constraints { get; } = new List<LinearConstraint>();

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