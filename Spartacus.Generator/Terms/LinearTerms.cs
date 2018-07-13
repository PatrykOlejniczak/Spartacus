using System.Collections.Generic;
using System.Linq;
using Spartacus.Common;
using Spartacus.Common.Types;

namespace Spartacus.Generator.Terms
{
    public class LinearTerms : ITermCalculator
    {
        public void Calculate(List<Example> examples)
        {
            foreach (var example in examples)
            {
                var basicVariables = example.Variables.Where(v => v.Schema.VariableType == VariableType.Basic).ToList();

                for (int first = 0; first < basicVariables.Count(); first++)
                {
                    for (int second = first + 1; second < basicVariables.Count(); second++)
                    {
                        if (second > first)
                        {
                            var linearSchemaSum =
                                new VariableSchema($"{basicVariables[first].Schema.Symbol}+{basicVariables[second].Schema.Symbol}", VariableType.Linear);
                            var linearSchemaMinus =
                                new VariableSchema($"{basicVariables[first].Schema.Symbol}-{basicVariables[second].Schema.Symbol}", VariableType.Linear);
                            var linearSchemaMinusRevert =
                                new VariableSchema($"{basicVariables[second].Schema.Symbol}-{basicVariables[first].Schema.Symbol}", VariableType.Linear);

                            example.Variables.Add(
                                new Variable(linearSchemaSum, basicVariables[first].Value + basicVariables[second].Value));
                            example.Variables.Add(
                                new Variable(linearSchemaMinus, basicVariables[first].Value - basicVariables[second].Value));
                            example.Variables.Add(
                                new Variable(linearSchemaMinusRevert, basicVariables[second].Value - basicVariables[first].Value));
                        }
                    }
                }
            }
        }
    }
}