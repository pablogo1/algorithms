using System;
using Xunit;

namespace Problems.Atoi
{
    public class AtoiTests
    {
        [Theory]
        [InlineData("42", 42)]
        [InlineData("-42", -42)]
        [InlineData("+42", 42)]
        [InlineData("    42", 42)]
        [InlineData("    42 word", 42)]
        [InlineData("  00042", 42)]
        [InlineData("xx 23", 0)]
        [InlineData("00042", 42)]
        [InlineData("-00042", -42)]
        [InlineData("12345689912", Int32.MaxValue)]
        [InlineData("-12345689912", Int32.MinValue)]
        [InlineData("", 0)]
        [InlineData("  ", 0)]
        [InlineData("2147483646", 2147483646)]
        [InlineData("-2147483646", -2147483646)]
        public void MyAtoiTests(string input, int expected)
        {
            var solution = new Solution();

            int actual = solution.MyAtoi(input);

            Assert.Equal(expected, actual);
        }
    }
}