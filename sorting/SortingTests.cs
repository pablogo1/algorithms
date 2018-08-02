using System;
using Xunit;

namespace sorting
{
    public class SortingTests
    {   
        [Fact]
        public void MergeSort_ShouldReturnSortedArray()
        {
            var sorter = new MergeSort();
            DoTest(sorter);
        }

        [Fact]
        public void QuickSort_ShouldReturnSortedArray()
        {
            var sorter = new QuickSort();
            DoTest(sorter);
        }
        
        private void DoTest(ISorter sorter) 
        {
            int[] array = new int[] { 38, 27, 43, 3, 9, 82, 10 };
            int[] expectedSortedArray = new int[] { 3, 9, 10, 27, 38, 43, 82 };

            sorter.Sort(array);

            Assert.Equal(expectedSortedArray, array);
        }
    }
}
