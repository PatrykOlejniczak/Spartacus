using System;
using System.Collections.Generic;
using CommandLine;
using Spartacus.Common;
using Spartacus.Generator;

namespace Spartacus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Settings>(args)
                  .WithParsed<Settings>(RunOptionsAndReturnExitCode);
        }

        private static void RunOptionsAndReturnExitCode(Settings opts)
        {

            var x_schema = new VariableSchema("X1", -100, 100);
            var y_schema = new VariableSchema("X2", -100, 100);
            //var z_schema = new VariableSchema("z", -10, 10);

            var schemas = new List<VariableSchema>();
            schemas.Add(x_schema);
            schemas.Add(y_schema);
            //schemas.Add(z_schema);

            var engine = new Engine(schemas);

            var constraints = new List<BaseConstraint>();

            // todo circle
            var constraint = new SquarePowerConstraint(3500, ComparisonKind.LessOrEqual);
            constraint.Weights.Add(x_schema, 1.0);
            constraint.Weights.Add(y_schema, 1.0);
            constraints.Add(constraint);


            // todo rectagle
            //var constraint = new LinearConstraint(-20, ComparisonKind.GreaterOrEqual);
            //constraint.Weights.Add(x_schema, 1.0);
            //constraint.Weights.Add(y_schema, 0.0);
            //constraints.Add(constraint);


            //var constraint2 = new LinearConstraint(70, ComparisonKind.LessOrEqual);
            //constraint2.Weights.Add(x_schema, 1.0);
            //constraint2.Weights.Add(y_schema, 0.0);
            //constraints.Add(constraint2);

            //var constraint3 = new LinearConstraint(20, ComparisonKind.GreaterOrEqual);
            //constraint3.Weights.Add(x_schema, 0.0);
            //constraint3.Weights.Add(y_schema, 1.0);
            //constraints.Add(constraint3);

            //var constraint4 = new LinearConstraint(70, ComparisonKind.LessOrEqual);
            //constraint4.Weights.Add(x_schema, 0.0);
            //constraint4.Weights.Add(y_schema, 1.0);
            //constraints.Add(constraint4);




            var examples = engine.Generate(50000, constraints);
            var examples2 = engine.Generate(50000, constraints);
            var examples3 = engine.Generate(50000, constraints);

            var writer = new CsvWriter();

            //writer.Save(examples, examples2, examples3, "circle_50k.xls");


            Console.WriteLine("Generated!");
            Console.ReadKey();
        }
    }
}
