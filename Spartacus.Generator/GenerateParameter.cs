using Spartacus.Benchmarks;
using Spartacus.Generator.Randoms;
using Spartacus.Generator.Terms;
using System;
using System.Collections.Generic;

namespace Spartacus.Generator
{
    public class GenerateParameter
    {
        public Benchmark Benchmark { get; }

        public int Examples { get; }
        public int? MinimumFeasibleExamples { get; }
        public int? MaximumFeasiblesExamples { get; }

        public List<ITerm> Terms { get; }
        public IRandomizer Randomizer { get; }

        public GenerateParameter(Benchmark benchmark, int examples, int? minimumFeasibleExamples = null, int? maximumFeasiblesExamples = null, List<ITerm> terms = null, IRandomizer randomizer = null)
        {
            if (examples <= 0)
            {
                throw new ArgumentException(nameof(examples));
            }

            if (minimumFeasibleExamples.HasValue
                    && (minimumFeasibleExamples.Value <= 0
                    || minimumFeasibleExamples.Value > examples))
            {
                throw new ArgumentException(nameof(minimumFeasibleExamples));
            }

            if (maximumFeasiblesExamples.HasValue
                    && (maximumFeasiblesExamples.Value <= 0
                    || maximumFeasiblesExamples.Value > examples))
            {
                throw new ArgumentException(nameof(maximumFeasiblesExamples));
            }

            if (maximumFeasiblesExamples.HasValue &&
                minimumFeasibleExamples.HasValue &&
                maximumFeasiblesExamples.Value < minimumFeasibleExamples.Value)
            {
                throw new ArgumentException();
            }

            Benchmark = benchmark ?? throw new ArgumentNullException(nameof(benchmark));
            Examples = examples;            
            MinimumFeasibleExamples = minimumFeasibleExamples;
            MaximumFeasiblesExamples = maximumFeasiblesExamples;
            
            Terms = terms ?? new List<ITerm>();
            Randomizer = randomizer ?? new MersenneTwisterWrapper();
        }
    }
}