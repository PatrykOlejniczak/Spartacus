using Spartacus.Benchmarks;
using System;

namespace Spartacus.Generator
{
    public class GenerateParameter
    {
        public Benchmark Benchmark { get; }

        public int Examples { get; }
        public int MinimumFeasibleExamples { get; }
        public int MaximumFeasiblesExamples { get; }

        public GenerateParameter(Benchmark benchmark, int examples, int minimumFeasibleExamples, int maximumFeasiblesExamples)
        {
            if (minimumFeasibleExamples > maximumFeasiblesExamples
                || minimumFeasibleExamples <= 0
                || maximumFeasiblesExamples <= 0)
            {
                throw new ArgumentException();
            }

            Benchmark = benchmark;
            Examples = examples;
            MinimumFeasibleExamples = minimumFeasibleExamples;
            MaximumFeasiblesExamples = maximumFeasiblesExamples;
        }
    }
}