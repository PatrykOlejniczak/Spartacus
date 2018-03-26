using System;

namespace Spartacus.Common
{
    public class Variable
    {
        public VariableSchema Schema { get; }
        public double Value { get; }

        public Variable(VariableSchema schema, double value)
        {
            if (schema == null)
            {
                throw new ArgumentNullException(nameof(schema));
            }

            Schema = schema;
            Value = value;
        }
    }
}