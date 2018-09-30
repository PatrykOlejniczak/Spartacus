using System.Linq;
using Spartacus.Benchmarks.Defined;
using Xunit;

namespace Spartacus.UnitTests
{
    public class BenchmarkCubeTests
    {
        [Theory]
        [InlineData(3, 1, 6)]
        [InlineData(4, 1, 8)]
        [InlineData(5, 1, 10)]
        [InlineData(6, 1, 12)]
        [InlineData(7, 1, 14)]
        [InlineData(3, 2, 12)]
        [InlineData(4, 2, 16)]
        [InlineData(5, 2, 20)]
        [InlineData(6, 2, 24)]
        [InlineData(7, 2, 28)]
        public void Simplex_ConstraintsGroup(int dimension, int elements, int constraint)
        {
            var benchmark = new Cube(dimension, 2.7, elements);

            Assert.Equal(constraint, benchmark.Constraints.Count);
            Assert.DoesNotContain(benchmark.Constraints, v => v.Modificators.Count != 1);
            Assert.Equal(elements, benchmark.Constraints.GroupBy(v => v.GroupId).Count());
        }
    }
}