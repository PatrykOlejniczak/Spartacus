using Spartacus.Benchmarks;
using Spartacus.Generator;
using System;
using System.Collections.Generic;

namespace Spartacus
{
    public class ConsoleInterface
    {
        private readonly Engine engine;
        private readonly Benchmark benchmark;
        private readonly int examples;

        public ConsoleInterface(Engine engine, Benchmark benchmark, int examples)
        {
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

            this.benchmark = benchmark ?? throw new ArgumentNullException(nameof(benchmark));

            this.examples = examples > 0 ? examples : throw new ArgumentOutOfRangeException(nameof(examples));
        }

        public List<SheetToSave> Generate(List<string> sheets)
        {
            var dataToSave = new List<SheetToSave>();

            foreach (var sheet in sheets)
            {
                dataToSave.Add(new SheetToSave()
                {
                    SheetName = sheet,
                    Examples = engine.GenerateLabeled(examples, benchmark)
                });
            }

            return dataToSave;
        }
    }
}
