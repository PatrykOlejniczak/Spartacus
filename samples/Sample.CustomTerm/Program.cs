using Sample.Common;
using Spartacus.Benchmarks.Defined;
using Spartacus.Common;
using Spartacus.Generator;
using Spartacus.Generator.Terms;
using System.Collections.Generic;
using System.Linq;
using Spartacus.Common.Types;

namespace Sample.CustomTerm
{
    /// <summary>
    /// asdas <see cref="ITerm"/>
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            var customTerm = new CustomSumTerm();

            var parameters =
                    new GenerateParameter(new Plane(), 10, terms: new List<ITerm>() { customTerm });

            var generator = new Engine(parameters);
            var examples = generator.Generate();

            examples.ConsoleDisplay();
        }
    }

    public class CustomSumTerm : ITerm
    {
        public void Calculate(List<Example> examples)
        {
            foreach (var example in examples)
            {
                var basicVariables
                        = example.Variables.Where(v => v.Schema.VariableType == VariableType.Basic);

                var schema = new VariableSchema("sum(x)", VariableType.Custom);

                example.Variables.Add(new Variable(schema, basicVariables.Sum(v => v.Value)));
            }
        }
    }
}
