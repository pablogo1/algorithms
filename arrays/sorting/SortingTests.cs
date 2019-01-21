using System;
using Xunit;

namespace arrays.sorting
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
        public void QuickSortA_ShouldReturnSortedArray()
        {
            var sorter = new QuickSortA();
            DoTest(sorter);
        }
        
        [Fact]
        public void QuickSortB_ShouldReturnSortedArray()
        {
            var sorter = new QuickSortB();
            DoTest(sorter);
        }

        [Fact]
        public void QuickSortC_ShouldReturnSortedArray()
        {
            var sorter = new QuickSortC();
            DoTest(sorter);
        }

        private void DoTest(ISorter sorter) 
        {
            int[] array = { 38, 27, 43, 3, 9, 82, 10 };
            int[] expectedSortedArray = { 3, 9, 10, 27, 38, 43, 82 };

            sorter.Sort(array);

            Assert.Equal(expectedSortedArray, array);
        }
    }
}
