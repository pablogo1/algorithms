using System.Diagnostics;
using Xunit;

namespace array_manipulation
{
	public class ArrayManipulationTests : IClassFixture<ArrayManipulationFixture>
    {
        private readonly ArrayManipulationFixture _fixture;
        private readonly ArrayManipulator _target;

        public ArrayManipulationTests(ArrayManipulationFixture fixture)
        {
            _fixture = fixture;
            _target = new ArrayManipulator();
        }

        [Fact]
        public void TestCase1()
        {
            var testData = _fixture.TestCases["testCase1"];
            const int expectedMax = 200;

            var max = _target.GetMaxInArray(testData);

            Assert.Equal(expectedMax, max);
        }

        [Fact]
        public void TestCase4()
        {
            const long expectedMax = 7542539201;
            var testData = _fixture.TestCases["testCase4"];

            var max = _target.GetMaxInArray(testData);

            Assert.Equal(expectedMax, max);
        }

        [Fact]
        public void TestCase7()
        {
            const long expectedMax = 2497169732;
            var testData = _fixture.TestCases["testCase7"];

            var stopwatch = Stopwatch.StartNew();
            var max = _target.GetMaxInArray(testData);

            stopwatch.Stop();

            Assert.Equal(expectedMax, max);

        }
    }
}
