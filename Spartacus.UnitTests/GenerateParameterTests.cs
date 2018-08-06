using System;
using Spartacus.Benchmarks;
using Spartacus.Generator;
using Xunit;

namespace Spartacus.UnitTests
{
    public class BenchmarkMock : Benchmark
    { }

    public class GenerateParameterTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        public void Constructor_WrongFeasiblesConfiguration(int minimum, int maximum)
        {
            var benchmark = new BenchmarkMock();
            var points = 1;

            Assert.Throws<ArgumentException>(() => new GenerateParameter(benchmark, points, minimum, maximum));
        }

        [Fact]
        public void Constructor_NullBenchmark()
        {
            var points = 1;

            Assert.Throws<ArgumentNullException>(() => new GenerateParameter(null, points));
        }

        [Fact]
        public void Constructor_WrongPointConfiguration()
        {
            var benchmark = new BenchmarkMock();
            var points = 1;

            Assert.Throws<ArgumentException>(() => new GenerateParameter(benchmark, 0));
        }
    }
}