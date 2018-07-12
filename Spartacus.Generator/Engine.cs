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

        public List<Example> GenerateLabeled(int examplesCount, int minimumFeasibles = 0)
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


        //TODO Fix It temporary solution, do it some elegant way as extension for engine or something
        private List<Variable> ExtendByLinearSamples(List<Variable> variables)
        {
            var extensionVariables = new List<Variable>();

            for (int i = 0; i < variables.Count; i++)
            {
                for (int j = i; j < variables.Count; j++)
                {
                    if (j > i)
                    {

                        var linearSchemaSum =
                            new VariableSchema($"{variables[i].Schema.Symbol}+{variables[j].Schema.Symbol}", VariableType.Linear);
                        var linearSchemaMinus =
                            new VariableSchema($"{variables[i].Schema.Symbol}-{variables[j].Schema.Symbol}", VariableType.Linear);
                        var linearSchemaMinusRevert =
                            new VariableSchema($"{variables[j].Schema.Symbol}-{variables[i].Schema.Symbol}", VariableType.Linear);

                        extensionVariables.Add(
                            new Variable(linearSchemaSum, variables[i].Value + variables[j].Value));
                        extensionVariables.Add(
                            new Variable(linearSchemaMinus,variables[i].Value - variables[j].Value));
                        extensionVariables.Add(
                            new Variable(linearSchemaMinusRevert,variables[j].Value - variables[i].Value));
                    }
                }
            }

            return extensionVariables;
        }

        //TODO Fix It temporary solution, do it some elegant way as extension for engine or something
        private List<Variable> ExtendByQuadraticSamples(List<Variable> variables)
        {
            var extensionVariables = new List<Variable>();

            for (int i = 0; i < variables.Count; i++)
            {
                var quadraticSchema = new VariableSchema($"{variables[i].Schema.Symbol}*{variables[i].Schema.Symbol}", VariableType.Quadratic);
                extensionVariables.Add(new Variable(quadraticSchema, variables[i].Value * variables[i].Value));

                for (int j = i; j < variables.Count; j++)
                {
                    if (j > i)
                    {
                        var quadraticSchemaBetweenVariables = 
                            new VariableSchema($"{variables[i].Schema.Symbol}*{variables[j].Schema.Symbol}", VariableType.Quadratic);
                        extensionVariables.Add(
                            new Variable(quadraticSchemaBetweenVariables, variables[i].Value * variables[j].Value));
                    }
                }
            }

            return extensionVariables;
        }
    }
}