using Spartacus.Common;
using Spartacus.Common.Types;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Generator.Terms
{
    public class QuadraticTerms : ITerm
    {
        public void Calculate(List<Example> examples)
        {
            foreach (var example in examples)
            {
                var basicVariables = example.Variables.Where(v => v.Schema.VariableType == VariableType.Basic).ToList();

                for (int first = 0; first < basicVariables.Count; first++)
                {
                    var quadraticSchema =
                        new VariableSchema($"{basicVariables[first].Schema.Symbol}*{basicVariables[first].Schema.Symbol}", VariableType.Quadratic);
                    example.Variables.Add(new Variable(quadraticSchema, basicVariables[first].Value * basicVariables[first].Value));

                    for (int second = first + 1; second < basicVariables.Count; second++)
                    {
                        if (second > first)
                        {
                            var quadraticSchemaBetweenVariables =
                                new VariableSchema($"{basicVariables[first].Schema.Symbol}*{basicVariables[second].Schema.Symbol}", VariableType.Quadratic);
                            example.Variables.Add(new Variable(quadraticSchemaBetweenVariables, basicVariables[first].Value * basicVariables[second].Value));
                        }
                    }
                }
            }
        }
    }
}