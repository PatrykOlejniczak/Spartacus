using System;
using System.Collections.Generic;
using System.Linq;
using Spartacus.Common;
using Spartacus.ConsoleViewer.Menu;
using Spartacus.Generator;

namespace Spartacus.ConsoleViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            //while (true)
            //{
            //    GenerateMainMenu();

            //}

            var x_schema = new VariableSchema("x", -100, 100);
            var y_schema = new VariableSchema("y", -100, 100);
            //var z_schema = new VariableSchema("z", -10, 10);

            var schemas = new List<VariableSchema>();
            schemas.Add(x_schema);
            schemas.Add(y_schema);
            //schemas.Add(z_schema);

            var engine = new Engine(schemas);

            var constraints = new List<IConstraint>();

            // todo circle
            //var constraint = new SquareConstraint(2500, Comparison.LessOrEqual);
            //constraint.Weights.Add(x_schema, 1.0);
            //constraint.Weights.Add(y_schema, 1.0);
            //constraints.Add(constraint);


            // todo rectagle
            var constraint = new Constraint(-20, Comparison.GreaterOrEqual);
            constraint.Weights.Add(x_schema, 1.0);
            constraint.Weights.Add(y_schema, 0.0);
            constraints.Add(constraint);


            var constraint2 = new Constraint(70, Comparison.LessOrEqual);
            constraint2.Weights.Add(x_schema, 1.0);
            constraint2.Weights.Add(y_schema, 0.0);
            constraints.Add(constraint2);

            var constraint3 = new Constraint(20, Comparison.GreaterOrEqual);
            constraint3.Weights.Add(x_schema, 0.0);
            constraint3.Weights.Add(y_schema, 1.0);
            constraints.Add(constraint3);

            var constraint4 = new Constraint(70, Comparison.LessOrEqual);
            constraint4.Weights.Add(x_schema, 0.0);
            constraint4.Weights.Add(y_schema, 1.0);
            constraints.Add(constraint4);




            var examples = engine.Generate(1000, constraints);

            var writer = new CsvWriter();

            writer.Save(examples);


            Console.WriteLine("Generated!");
            Console.ReadKey();
        }

        private static void GenerateMainMenu()
        {
            var type = typeof(IMenuCommand);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                                 .SelectMany(s => s.GetTypes())
                                 .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            foreach (var option in types)
            {
                var instance = Activator.CreateInstance(option);

                Console.WriteLine((instance as IMenuCommand).Description);
            }
        }
    }
}
