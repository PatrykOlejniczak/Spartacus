using System;

namespace Spartacus.Common
{
    public class Variable
    {
        public VariableSchema Schema { get; }
        public double Value { get; }

        public Variable(VariableSchema schema, double value)
        {
            Schema = schema ?? throw new ArgumentNullException(nameof(schema));
            Value = value;
        }
    }
}