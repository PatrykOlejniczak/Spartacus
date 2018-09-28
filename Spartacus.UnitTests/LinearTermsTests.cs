using System.Collections.Generic;
using System.Linq;
using Spartacus.Common;
using Spartacus.Common.Types;
using Spartacus.Generator.Terms;
using Xunit;

namespace Spartacus.UnitTests
{
    public class LinearTermsTests
    {
        [Fact]
        public void Calculate_MoreVariables_ReturnCorrectResult()
        {
            var variables = new List<Variable>
            {
                new Variable(new VariableSchema("X"), 2),
                new Variable(new VariableSchema("Y"), 3)
            };

            var examples = new List<Example>
            {
                new Example(variables)
            };

            var calculator = new LinearTerms();
            calculator.Calculate(examples);

            Assert.Equal(2, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic));
            Assert.Equal(1,
                examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic && c.Value == 2));
            Assert.Equal(1,
                examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Basic && c.Value == 3));

            Assert.Equal(1,
                examples[0].Variables.Count(c =>
                    c.Schema.VariableType == VariableType.Basic && c.Schema.Symbol.Equals("X")));
            Assert.Equal(1,
                examples[0].Variables.Count(c =>
                    c.Schema.VariableType == VariableType.Basic && c.Schema.Symbol.Equals("Y")));

            Assert.Equal(3, examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Linear));
            Assert.Equal(1,
                examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Linear && c.Value == 5));
            Assert.Equal(1,
                examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Linear && c.Value == -1));
            Assert.Equal(1,
                examples[0].Variables.Count(c => c.Schema.VariableType == VariableType.Linear && c.Value == 1));

            Assert.Equal(1,
                examples[0].Variables.Count(c =>
                    c.Schema.VariableType == VariableType.Linear && c.Schema.Symbol.Equals("X+Y")));
            Assert.Equal(1,
                examples[0].Variables.Count(c =>
                    c.Schema.VariableType == VariableType.Linear && c.Schema.Symbol.Equals("X-Y")));
            Assert.Equal(1,
                examples[0].Variables.Count(c =>
                    c.Schema.VariableType == VariableType.Linear && c.Schema.Symbol.Equals("Y-X")));
        }

        [Fact]
        public void Calculate_OneVariable_ReturenCorrectResult()
        {
            var variables = new List<Variable>
            {
                new Variable(new VariableSchema("X"), 2)
            };

            var examples = new List<Example>
            {
                new Example(variables)
            };

            var calculator = new LinearTerms();
            calculator.Calculate(examples);

            Assert.Single(examples[0].Variables);
            Assert.Equal(2, examples[0].Variables.Single(c => c.Schema.VariableType == VariableType.Basic).Value);
            Assert.Equal("X",
                examples[0].Variables.Single(c => c.Schema.VariableType == VariableType.Basic).Schema.Symbol);
        }
    }
}