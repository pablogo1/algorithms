using Xunit;

namespace Arrays.Search
{
    public class BinarySearchTests
    {
        [Theory]
        [InlineData(new long[] {1, 2, 3, 4, 5}, 3)]
        [InlineData(new long[] {1, 2, 3, 4, 5}, 1)]
        [InlineData(new long[] {1, 2, 3, 4, 5}, 5)]
        public void BinarySearch_ShouldReturnTrue_WhenLookupValueIsFound(long[] array, long lookupValue)
        {
            const bool expectedResult = true;

            DoTest(array, lookupValue, expectedResult);
        }

        [Fact]
        public void BinarySearch_ShouldReturnFalse_WhenLookupValueIsNotFound()
        {
            const long lookupValue = 0;
            const bool expectedResult = false;
            long[] array = {1, 2, 3, 4, 5};

            DoTest(array, lookupValue, expectedResult);
        }

        [Fact]
        public void BinarySearch_ShouldHandleUnsortedArrays()
        {
            const long lookupValue = 5;
            const bool expectedResult = true;
            long[] array = {9, 3, 1, 4, -5, 5};

            DoTest(array, lookupValue, expectedResult);
        }
        
        private void DoTest(long[] array, long lookupValue, bool expectedResult)
        {
            var result = BinarySearch.Search(array, lookupValue);

            Assert.Equal(expectedResult, result);
        }
    }
}