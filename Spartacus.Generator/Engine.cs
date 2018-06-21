using MersenneTwister;
using Spartacus.Common;
using Spartacus.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using Spartacus.Benchmarks;

namespace Spartacus.Generator
{
    public class Engine
    {
        private readonly Benchmark benchmark;
        private readonly bool linearExtended;
        private readonly bool quadraticExtended;
        private readonly int seed;

        public Engine(Benchmark benchmark, bool linearExtended = false, bool quadraticExtended = false, int seed = 1)
        {
            this.benchmark = benchmark ?? throw new ArgumentNullException(nameof(benchmark));
            this.linearExtended = linearExtended;
            this.quadraticExtended = quadraticExtended;
            this.seed = seed;
        }

        public List<Example> GenerateNotLabeled(int examplesCount)
        {
            var examples = new List<Example>();
            var random = Randoms.Create(seed);

            for (int i = 0; i < examplesCount; i++)
            {
                var exampleVariables = new List<Variable>();

                foreach (var schema in benchmark.VariableSchemas)
                {
                    exampleVariables.Add(new Variable(schema, random.NextDouble() * (schema.MaxValue - schema.MinValue) + schema.MinValue));
                }

                examples.Add(new Example(exampleVariables));
            }

            return examples;
        }

        public List<Example> GenerateLabeled(int examplesCount)
        {
            var examples = GenerateNotLabeled(examplesCount);

            foreach (var example in examples)
            {
                example.Validate(benchmark.Constraints);
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