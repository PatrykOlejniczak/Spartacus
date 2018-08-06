using Spartacus.Common;
using Spartacus.Common.Types;
using System.Collections.Generic;

namespace Spartacus.Generator
{
    public class Engine
    {
        private readonly GenerateParameter parameters;        

        public Engine(GenerateParameter parameters)
        {
            this.parameters = parameters;
        }

        public List<Example> Generate()
        {
            var examples = new List<Example>();

            while (examples.Count < parameters.Examples)
            {
                var exampleVariables = new List<Variable>();

                foreach (var schema in parameters.Benchmark.VariableSchemas)
                {
                    exampleVariables.Add(new Variable(schema, parameters.Randomizer.NextDouble(schema.MinValue, schema.MaxValue)));
                }

                var proposition = new Example(exampleVariables);

                proposition.Validate(parameters.Benchmark.Constraints);
                if (proposition.ExampleType == ExampleType.Infeasible
                        && examples.Count < parameters.MinimumFeasibleExamples)
                {
                    continue;
                }

                if (proposition.ExampleType == ExampleType.Feasible
                    && parameters.MaximumFeasiblesExamples.HasValue
                    && examples.Count >= parameters.MaximumFeasiblesExamples)
                {
                    continue;
                }

                examples.Add(proposition);
            }

            foreach (var term in parameters.Terms)
            {
                term.Calculate(examples);
            }

            return examples;
        }
    }
}