using System;
using Xunit;

namespace Arrays.TwoSortedArraysMedian 
{
    public class TwoSortedArraysMedianTests
    {
        [Theory(DisplayName = "FindMedianSortedArrays")]
        [InlineData(new int[] {1, 2}, new int[] {3}, 2.0)]
        [InlineData(new int[] {1, 2}, new int[] {3, 4}, 2.5)]
        [InlineData(new int[] {4, 20, 32, 50, 55, 61}, new int[] {1, 15, 22, 30, 70}, 30.0)]
        [InlineData(new int[] {23, 26, 31, 35}, new int[] {3, 5, 7, 9, 11, 16}, 13.5)]
        [InlineData(new int[] {23, 26, 31, 35, 36}, new int[] {3, 5, 7, 11}, 23.0)]
        public void FindMedianSortedArraysTests(int[] nums1, int[] nums2, double expectedMedian)
        {
            double actual = Solution.FindMedianSortedArrays(nums1, nums2);

            Assert.Equal(expectedMedian, actual);
        }
    }
}