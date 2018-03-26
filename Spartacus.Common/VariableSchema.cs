using System;

namespace Spartacus.Common
{
    public class VariableSchema
    {
        public string Symbol { get; }
        public double MaxValue { get; }
        public double MinValue { get; }

        public VariableSchema(string symbol, double minValue = Double.MinValue, double maxValue = Double.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            Symbol = symbol;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}