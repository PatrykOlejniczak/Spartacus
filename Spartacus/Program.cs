using CommandLine;
using Spartacus.Benchmarks;
using Spartacus.Benchmarks.Defined;
using Spartacus.Generator;
using System;
using System.Collections.Generic;
using System.IO;

namespace Spartacus
{
    public class Program
    {
        private static Engine engine;

        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CubeSettings, BallSettings, SimplexSettings>(args)
                          .MapResult(
                                (CubeSettings opts) => Run(new Cube(opts.Dimension, opts.Constant), opts),
                                (BallSettings opts) => Run(new Ball(opts.Radius, opts.Center.ToArray()), opts),
                                (SimplexSettings opts) => Run(new Simplex(opts.Dimension, opts.Constant), opts),
                                errors => 1);
        }

        private static int Run(Benchmark benchmark, Settings settings)
        {
            engine = new Engine(benchmark, settings.LinearExtension, settings.QuadraticExtension, settings.Seed);

            var dataToSave = GenerateExamples(settings.Sheets, settings.Points);

            var writer = new ExcelWriter(settings.OutputPath);

            writer.Save(dataToSave, settings.Output[0]);

            Console.WriteLine($"Generated! {Path.Combine(settings.OutputPath, settings.Output[0] + ".xlsx")}");

            return 0;
        }

        private static List<SheetToSave> GenerateExamples(List<string> sheets, int points)
        {
            var dataToSave = new List<SheetToSave>();

            foreach (var sheet in sheets)
            {
                dataToSave.Add(new SheetToSave()
                {
                    SheetName = sheet,
                    Examples = engine.GenerateLabeled(points)
                });
            }

            return dataToSave;
        }
    }
}
