using System;
using Xunit;

namespace Arrays.TwoSortedArraysMedian 
{
    public class TwoSortedArraysMedianTests
    {
        [Theory]
        [InlineData(new int[] {1, 2}, new int[] {3}, 2.0)]
        [InlineData(new int[] {1, 2}, new int[] {3, 4}, 2.5)]
        public void FindMedianSortedArraysTests(int[] nums1, int[] nums2, double expectedMedian)
        {
            double actual = Solution.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expectedMedian, actual);
        }
    }
}