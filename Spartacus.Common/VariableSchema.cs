using System;
using Spartacus.Common.Types;

namespace Spartacus.Common
{
    public class VariableSchema
    {
        public string Symbol { get; }
        public VariableType VariableType { get; }
        public double MaxValue { get; }
        public double MinValue { get; }

        public VariableSchema(string symbol, VariableType variableType = VariableType.Basic, double minValue = Double.MinValue, double maxValue = Double.MaxValue)
        {
            if (string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentNullException(nameof(symbol));
            }

            VariableType = variableType;
            Symbol = symbol;
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}