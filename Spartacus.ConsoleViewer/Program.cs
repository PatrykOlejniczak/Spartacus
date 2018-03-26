using System;
using System.Collections.Generic;
using Spartacus.Common;
using Spartacus.Generator;

namespace Spartacus.ConsoleViewer
{
    // Temp helper to test engine
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Spartacus!");


            var x_schema = new VariableSchema("x", -10, 10);
            var y_schema = new VariableSchema("y", -10, 10);
            //var z_schema = new VariableSchema("z", -10, 10);

            var schemas = new List<VariableSchema>();
            schemas.Add(x_schema);
            schemas.Add(y_schema);
            //schemas.Add(z_schema);

            var engine = new Engine(schemas);

            var constraints = new List<IConstraint>();
            var constraint = new Constraint(2.7, Comparison.Greater);

            constraint.Weights.Add(x_schema, 1.0);
            constraint.Weights.Add(y_schema, 2.0);
            //constraint.Weights.Add(z_schema, 4.0);

            constraints.Add(constraint);


            var constraint2 = new Constraint(2.7, Comparison.Greater);

            constraint2.Weights.Add(x_schema, 3.0);
            constraint2.Weights.Add(y_schema, 0.0);

            constraints.Add(constraint2);

            var examples = engine.Generate(1000, constraints);

            var writer = new CsvWriter();

            writer.Save(examples);


            Console.WriteLine("Generated!");
            Console.ReadKey();
        }
    }
}
