using System;
using Spartacus.Benchmarks;

namespace Spartacus.Generator
{
    public class GenerateParameter
    {
        public Benchmark Benchmark { get; }

        public int Examples { get; }
        public int? MinimumFeasibleExamples { get; }
        public int? MaximumFeasiblesExamples { get; }

        public GenerateParameter(Benchmark benchmark, int examples, int? minimumFeasibleExamples, int? maximumFeasiblesExamples)
        {
            if (minimumFeasibleExamples.HasValue
                    && minimumFeasibleExamples.Value <= 0)
            {
                throw new ArgumentException(nameof(minimumFeasibleExamples));
            }

            if (maximumFeasiblesExamples.HasValue
                    && maximumFeasiblesExamples.Value <= 0)
            {
                throw new ArgumentException(nameof(maximumFeasiblesExamples));
            }

            if (maximumFeasiblesExamples.HasValue && minimumFeasibleExamples.HasValue
                                                  &&
                maximumFeasiblesExamples.Value < minimumFeasibleExamples.Value)
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