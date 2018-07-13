using Spartacus.Benchmarks;

namespace Spartacus.Generator
{
    public class GenerateParameter
    {
        public Benchmark Benchmark { get; }

        public int Examples { get; }
        public int MinimumFeasibleExamples { get; }

        public GenerateParameter(Benchmark benchmark, int examples, int minimumFeasibleExamples = 0)
        {
            Benchmark = benchmark;
            Examples = examples;
            MinimumFeasibleExamples = minimumFeasibleExamples;
        }
    }
}