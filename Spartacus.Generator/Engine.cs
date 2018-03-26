using System;
using System.Collections.Generic;
using MersenneTwister;
using Spartacus.Common;

namespace Spartacus.Generator
{
    public class Engine
    {
        public IList<VariableSchema> VariableSchemas { get; }

        public Engine(IList<VariableSchema> variableSchemas)
        {
            if (variableSchemas == null || variableSchemas.Count == 0)
            {
                throw new ArgumentNullException(nameof(variableSchemas));
            }

            VariableSchemas = variableSchemas;
        }

        public IList<Example> Generate(int examplesCount)
        {
            var examples = new List<Example>();

            for (int i = 0; i < examplesCount; i++)
            {
                var exampleVariables = new List<Variable>();

                foreach (var schema in VariableSchemas)
                {
                    var random = Randoms.Create();

                    exampleVariables.Add(new Variable(schema, random.Next(Convert.ToInt32(schema.MinValue), Convert.ToInt32(schema.MaxValue))));
                }

                examples.Add(new Example(exampleVariables));
            }

            return examples;
        }

        public IList<Example> Generate(int examplesCount, IList<IConstraint> constraints)
        {
            var examples = Generate(examplesCount);

            foreach (var example in examples)
            {
                example.Validate(constraints);
            }

            return examples;
        }
    }
}