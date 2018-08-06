using CommandLine;
using Spartacus.Benchmarks;
using Spartacus.Benchmarks.Defined;
using Spartacus.Generator;
using Spartacus.Generator.Randoms;
using Spartacus.Generator.Storage;
using Spartacus.Generator.Terms;
using Spartacus.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using Spartacus.Generator.Storage.Excel;

namespace Spartacus
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Parser.Default.ParseArguments<CubeSettings, BallSettings, SimplexSettings>(args)
                          .MapResult(
                                (CubeSettings opts) => Run(new Cube(opts.Dimension, opts.Constant, opts.Elements), opts),
                                (BallSettings opts) => Run(new Ball(opts.Radius, opts.Elements, opts.Center.ToArray()), opts),
                                (SimplexSettings opts) => Run(new Simplex(opts.Dimension, opts.Constant, opts.Elements), opts),
                                errors => 1);
        }

        private static int Run(Benchmark benchmark, BaseGeneratorSettings baseGeneratorSettings)
        {
            var parameters = new GenerateParameter(benchmark, baseGeneratorSettings.Points,
                                                   baseGeneratorSettings.MinimumFeasibles, baseGeneratorSettings.MaximumFeasibles);
            var extensions = new List<ITerm>();

            if (baseGeneratorSettings.LinearExtension)
            {
                extensions.Add(new LinearTerms());
            }

            if (baseGeneratorSettings.QuadraticExtension)
            {
                extensions.Add(new QuadraticTerms());
            }

            var dataToSave = new List<Sheet>();
            var engine = new Engine(new MersenneTwisterWrapper(baseGeneratorSettings.Seed), extensions);
            foreach (var sheet in baseGeneratorSettings.Sheets)
            {
                dataToSave.Add(new Sheet()
                {
                    Name = sheet,
                    Data = engine.Generate(parameters)
                });
            }

            var writer = new ExcelStorage(baseGeneratorSettings.OutputPath);
            writer.Save(dataToSave, baseGeneratorSettings.Output[0]);

            Console.WriteLine($"Generated! {Path.Combine(baseGeneratorSettings.OutputPath, baseGeneratorSettings.Output[0] + ".xlsx")}");

            return 0;
        }
    }
}
