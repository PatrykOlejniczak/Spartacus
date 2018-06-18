using CommandLine;
using Spartacus.Benchmarks;
using Spartacus.Generator;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Spartacus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Settings>(args)
                .WithParsed<Settings>(Run);
        }

        private static void Run(Settings settings)
        {
            var benchamarkType = Assembly.GetAssembly(typeof(Benchmark)).GetTypes()
                                         .Single(myType => myType.IsClass &&
                                                          !myType.IsAbstract &&
                                                           myType.IsSubclassOf(typeof(Benchmark)) &&
                                                           myType.Name.ToLower().Equals(settings.Benchmark.ToLower()));
            var benchmark = (Benchmark)Activator.CreateInstance(benchamarkType);

            var engine = new Engine(benchmark.VariableSchemas.ToList(), settings.LinearExtension, settings.QuadraticExtension, settings.Seed);

            var consoleInterface = new ConsoleInterface(engine, benchmark, settings.Points);

            var dataToSave = consoleInterface.Generate(settings.Sheets);

            var writer = new ExcelWriter(settings.OutputPath);

            writer.Save(dataToSave, settings.Output[0]);

            Console.WriteLine($"Generated! {Path.Combine(settings.OutputPath, settings.Output[0] + ".xlsx")}");
        }
    }
}
