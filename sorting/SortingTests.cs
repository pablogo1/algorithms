using System;
using Xunit;

namespace sorting
{
    public class SortingTests
    {
        private readonly ISorter _sorter;

        public SortingTests()
        {
            _sorter = new MergeSort();
        }

        [Fact]
        public void MergeSort_ShouldReturnSortedArray()
        {
            int[] array = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            int[] expectedSortedArray = new int[] { 3, 9, 10, 27, 38, 43, 82 };

            _sorter.Sort(array);

            Assert.Equal(expectedSortedArray, array);
        }
    }
}
