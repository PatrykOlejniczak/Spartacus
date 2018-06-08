using System;
using System.Linq;
using CommandLine;
using Spartacus.Benchmarks.Defined;
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
            var rectangle = new Rectangle();

            var engine = new Engine(rectangle.VariableSchemas.ToList());

            var examples = engine.Generate(50000, rectangle.Constraints.ToList());

            var writer = new CsvWriter();

            //writer.Save(examples, examples2, examples3, "circle_50k.xls");

            Console.WriteLine("Generated!");
            Console.ReadKey();
        }
    }
}
