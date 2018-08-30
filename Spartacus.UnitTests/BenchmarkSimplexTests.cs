using Spartacus.Benchmarks.Defined;
using Spartacus.Common.Types;
using Xunit;

namespace Spartacus.UnitTests
{
    public class BenchmarkSimplexTests
    {
        [Theory]
        [InlineData(2, -1, 4.7)]
        [InlineData(3, -1, 4.7)]
        [InlineData(4, -1, 4.7)]
        [InlineData(5, -1, 4.7)]
        [InlineData(6, -1, 4.7)]
        [InlineData(7, -1, 4.7)]
        public void Simplex_VariableSchema(int dimension, double min, double max)
        {
            var benchmark = new Simplex(dimension, 2.7);

            Assert.Equal(dimension, benchmark.VariableSchemas.Count);
            Assert.DoesNotContain(benchmark.VariableSchemas, v => v.VariableType != VariableType.Basic);
            Assert.DoesNotContain(benchmark.VariableSchemas, v => v.MinValue != min);
            Assert.DoesNotContain(benchmark.VariableSchemas, v => v.MaxValue != max);
        }

        [Theory]
        [InlineData(3, 7)]
        [InlineData(4, 13)]
        [InlineData(5, 21)]
        [InlineData(6, 31)]
        [InlineData(7, 43)]
        public void Simplex_ConstraintsGroup(int dimension, int constraint)
        {
            var benchmark = new Simplex(dimension, 2.7);

            var cst = benchmark.Constraints[0].ToString();

            Assert.Equal(constraint, benchmark.Constraints.Count);
        }
    }
}