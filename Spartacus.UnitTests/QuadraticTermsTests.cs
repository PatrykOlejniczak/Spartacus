using System.Collections.Generic;
using System.Linq;
using Spartacus.Common;
using Spartacus.Common.Types;
using Spartacus.Generator;
using Spartacus.Generator.Terms;
using Xunit;

namespace Spartacus.UnitTests
{
    //TODO Find more effective way to unit test collections!
    public class QuadraticTermsTests
    {
        [Fact]
        public void Calculate_OneVariable_ReturenCorrectResult()
        {
            var variables = new List<Variable>
            {
                new Variable(new VariableSchema("X"), 2)
            };

            var examples = new List<Example>()
            {
                new Example(variables)
            };

            var calculator = new QuadraticTerms();
            calculator.Calculate(examples);

            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic));
            Assert.Equal(2, examples[0].Variables.Single(c => c.Schema.VariableType == VariableType.Basic).Value);
            Assert.Equal("X", examples[0].Variables.Single(c => c.Schema.VariableType == VariableType.Basic).Schema.Symbol);

            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic));
            Assert.Equal(4, examples[0].Variables.Single(c => c.Schema.VariableType == VariableType.Quadratic).Value);
            Assert.Equal("X*X", examples[0].Variables.Single(c => c.Schema.VariableType == VariableType.Quadratic).Schema.Symbol);
        }

        [Fact]
        public void Calculate_MoreVariables_ReturnCorrectResult()
        {
            var variables = new List<Variable>
            {
                new Variable(new VariableSchema("X"), 2),
                new Variable(new VariableSchema("Y"), 3)
            };

            var examples = new List<Example>()
            {
                new Example(variables)
            };

            var calculator = new QuadraticTerms();
            calculator.Calculate(examples);

            Assert.Equal(2, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic && c.Value == 2));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic && c.Value == 3));

            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic && c.Schema.Symbol.Equals("X")));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic && c.Schema.Symbol.Equals("Y")));

            Assert.Equal(3, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic && c.Value == 4));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic && c.Value == 6));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic && c.Value == 9));

            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic && c.Schema.Symbol.Equals("X*X")));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic && c.Schema.Symbol.Equals("X*Y")));
            Assert.Equal(1, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Quadratic && c.Schema.Symbol.Equals("Y*Y")));

        }
    }
}
