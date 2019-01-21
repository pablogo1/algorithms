using Xunit;

namespace Arrays.SwapSum
{
    public class SwapSumTests
    {
        
            [Theory]
            [InlineData(new long[] {0, 1, 2, 3, 4, 5}, new long[] {5, 4, 6, 0, 0}, true)]
            [InlineData(new long[] {0, 3, 5, 7, 9, 1}, new long[] {5, 4, 1, 9}, true)]
            [InlineData(new long[] {0, 3, 5, 7, 9, 1}, new long[] {2, 4, 8, 9, 1}, false)]
            public void AreElegibleTests(long[] arrayA, long[] arrayB, bool expectedResult)
            {
                var areElegible = SwapSum.AreElegible(arrayA, arrayB);

                Assert.Equal(expectedResult, areElegible);
            }
        
    }
}