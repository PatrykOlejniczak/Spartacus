using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using CommandLine;
using Spartacus.Benchmarks;
using Spartacus.Generator;

namespace Spartacus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Settings>(args)
                  .WithParsed<Settings>(Run);
        }

        private static void Run(Settings opts)
        {
            var benchmarks = new List<Benchmark>();
            foreach (Type type in Assembly.GetAssembly(typeof(Benchmark)).GetTypes()
                                          .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Benchmark))))
            {
                benchmarks.Add((Benchmark)Activator.CreateInstance(type));
            }

            var benchmark = benchmarks.Single(bench => bench.Name.ToLower().Equals(opts.Benchmark.ToLower()));

            var engine = new Engine(benchmark.VariableSchemas.ToList());

            var dataToSave = new List<SheetToSave>();
            for (int i = 0; i < opts.Sheets.Count(); i++)
            {
                dataToSave.Add(new SheetToSave()
                {
                    SheetName = opts.Sheets[i],
                    Examples = engine.Generate(opts.Points, benchmark.Constraints.ToList(), opts.LinearExtension, opts.QuadraticExtension)
                });
            }

            var writer = new ExcelWriter(opts.OutputPath);

            writer.Save(dataToSave, opts.Output[0]);

            Console.WriteLine($"Generated! { Path.Combine(opts.OutputPath, opts.Output[0] + ".xlsx") }");
        }
    }
}
