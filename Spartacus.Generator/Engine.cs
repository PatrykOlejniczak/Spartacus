using MersenneTwister;
using Spartacus.Common;
using Spartacus.Common.Constraints;
using Spartacus.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spartacus.Generator
{
    public class Engine
    {
        public List<VariableSchema> VariableSchemas { get; }

        public Engine(List<VariableSchema> variableSchemas)
        {
            if (variableSchemas == null || variableSchemas.Count == 0)
            {
                throw new ArgumentNullException(nameof(variableSchemas));
            }

            VariableSchemas = variableSchemas;
        }

        public List<Example> Generate(int examplesCount)
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

        public List<Example> Generate(int examplesCount, List<BaseConstraint> constraints, bool linearExtended = false, bool quadraticExtended = false)
        {
            var examples = Generate(examplesCount);

            foreach (var example in examples)
            {
                example.Validate(constraints);
            }

            if (linearExtended)
            {
                foreach (var example in examples)
                {
                    example.Variables.AddRange(ExtendByLinearSamples(example.Variables.ToList()));
                }
            }

            if (quadraticExtended)
            {
                foreach (var example in examples)
                {
                    example.Variables.AddRange(ExtendByQuadraticSamples(example.Variables.ToList()));
                }
            }

            return examples;
        }


        //TODO Fix It temporary solution
        private List<Variable> ExtendByLinearSamples(List<Variable> variables)
        {
            var extensionVariables = new List<Variable>();

            var linearSchemaSum = new VariableSchema("X1+X2", VariableType.Linear);
            var linearSchemaMinus = new VariableSchema("X1-X2", VariableType.Linear);
            var linearSchemaMinusRevert = new VariableSchema("X2-X1", VariableType.Linear);

            for (int i = 0; i < variables.Count - 1; i++)
            {
                var actual = variables[i];
                var next = variables[i + 1];

                extensionVariables.Add(new Variable(linearSchemaSum, actual.Value + next.Value));
                extensionVariables.Add(new Variable(linearSchemaMinus, actual.Value - next.Value));
                extensionVariables.Add(new Variable(linearSchemaMinusRevert, next.Value - actual.Value));
            }

            return extensionVariables;
        }

        //TODO Fix It temporary solution
        private List<Variable> ExtendByQuadraticSamples(List<Variable> variables)
        {
            var extensionVariables = new List<Variable>();

            var linearSchemaSum = new VariableSchema("X1*X1", VariableType.Quadratic);
            var linearSchemaMinus = new VariableSchema("X2*X2", VariableType.Quadratic);
            var linearSchemaMinusRevert = new VariableSchema("X1*X2", VariableType.Quadratic);

            for (int i = 0; i < variables.Count - 1; i++)
            {
                var actual = variables[i];
                var next = variables[i + 1];

                extensionVariables.Add(new Variable(linearSchemaSum, actual.Value * actual.Value));
                extensionVariables.Add(new Variable(linearSchemaMinus, next.Value * next.Value));
                extensionVariables.Add(new Variable(linearSchemaMinusRevert, actual.Value * next.Value));
            }

            return extensionVariables;
        }
    }
}