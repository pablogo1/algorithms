using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Problems.MergeLists
{
    public class MergeListsTests
    {
        [Theory]
        [InlineData(new int[] { }, new int[] { 2, 3, 4, 5, 6 }, new int[] { 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { 2, 3, 4, 5, 6 }, new int[] { }, new int[] { 2, 3, 4, 5, 6 })]
        [InlineData(new int[] { }, new int[] { }, new int[] { })]
        public void Merge_Should_Handle_Empty_Lists(int[] listArray1, int[] listArray2, int[] expectedArray)
        {
            DoTest(listArray1, listArray2, expectedArray);
        }

        [Theory]
        [InlineData(new int[] { 1, 3, 5, 7 }, new int[] { 2, 4, 6, 8, 10, 12 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 12 })]
        [InlineData(new int[] { 1, 3, 5, 7, 9, 11, 13 }, new int[] { 2, 4, 6 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 9, 11, 13 })]
        public void Merge_Should_Handle_Different_List_Sizes(int[] listArray1, int[] listArray2, int[] expectedArray)
        {
            DoTest(listArray1, listArray2, expectedArray);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 6, 8 }, new int[] { 5, 7, 9, 10, 11, 12 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 })]
        public void Merge_Should_Handle_Equal_List_Sizes(int[] listArray1, int[] listArray2, int[] expectedArray)
        {
            DoTest(listArray1, listArray2, expectedArray);
        }

        private static void DoTest(int[] listArray1, int[] listArray2, int[] expectedArray)
        {
            var list1 = SinglyLinkedList.FromArray(listArray1);
            var list2 = SinglyLinkedList.FromArray(listArray2);
            var expected = SinglyLinkedList.FromArray(expectedArray);

            var actual = Solution.MergeLists(list1.Head, list2.Head);

            Assert.Equal(expected, actual, new SinglyLinkedListComparer());
        }
    }
}
