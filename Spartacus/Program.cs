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
                                (CubeSettings opts) => Run(new Cube(opts.Dimension, opts.Constant, opts.Elements), opts),
                                (BallSettings opts) => Run(new Ball(opts.Radius, opts.Elements, opts.Center.ToArray()), opts),
                                (SimplexSettings opts) => Run(new Simplex(opts.Dimension, opts.Constant, opts.Elements), opts),
                                errors => 1);
        }

        private static int Run(Benchmark benchmark, BaseSettings baseSettings)
        {
            engine = new Engine(benchmark, baseSettings.LinearExtension, baseSettings.QuadraticExtension, baseSettings.Seed);

            var dataToSave = GenerateExamples(baseSettings.Sheets, baseSettings.Points, baseSettings.MinimumFeasibles);

            var writer = new ExcelWriter(baseSettings.OutputPath);

            writer.Save(dataToSave, baseSettings.Output[0]);

            Console.WriteLine($"Generated! {Path.Combine(baseSettings.OutputPath, baseSettings.Output[0] + ".xlsx")}");

            return 0;
        }

        private static List<SheetToSave> GenerateExamples(List<string> sheets, int points, int minimumFeasibles)
        {
            var dataToSave = new List<SheetToSave>();

            foreach (var sheet in sheets)
            {
                dataToSave.Add(new SheetToSave()
                {
                    SheetName = sheet,
                    Examples = engine.GenerateLabeled(points, minimumFeasibles)
                });
            }

            return dataToSave;
        }
    }
}
