using System;
using Xunit;

namespace Arrays.SwapSum
{
    public class SwapSumTests
    {
        public class AreElegibleTests
        {
            [Fact]
            public void ShouldReturnTrue_WhenSumOfBothArraysCanBeEqualBySwappingElements()
            {
                long[] arrayA = {0, 1, 3, 5, 7, 9};
                long[] arrayB = {1, 4, 5, 9};

                Assert.True(SwapSum.AreElegible(arrayA, arrayB));
            }

            [Fact]
            public void ShouldReturnFalse_WhenS()
            {
            //Given
            
            //When
            
            //Then
            }
        }
    }
}