using System;
using Xunit;

namespace sorting
{
    public class ArrayExtensionsTests
    {
        public class CopyTests
        {

            [Fact]
            public void ShouldCopyArrayFromStartToFinish()
            {
                int[] array = new int[] { 1, 2, 3, 4, 5 };

                var copy = ArrayExtensions.Copy(array);

                // Assert.
                Assert.NotSame(copy, array);
                Assert.Equal(array, copy);
            }

            [Fact]
            public void ShouldCopyArrayFromSpecifiedStartAndEnd()
            {
                int[] array = new int[] { 1, 2, 3, 4, 5 };
                int[] expected = new int[] { 1, 2, 3 };

                var copy = ArrayExtensions.Copy(array, 0, 2);

                // Assert.
                Assert.Equal(expected, copy);
            }
        }

        public class CopyToTests
        {
            [Theory]
            [InlineData(new int[] { 1, 3, 2 }, new int[] { 0, 0, 0, 5, 8, 7, 9 }, 0, new int[] { 1, 3, 2, 5, 8, 7, 9 })]
            [InlineData(new int[] { 3, 2 }, new int[] { 1, 0, 0, 5, 8, 7, 9}, 1, new int[] { 1, 3, 2, 5, 8, 7, 9 })]
            [InlineData(new int[] { 1, 3, 2, 5, 8, 7, 9 }, new int[] { 0, 0, 0, 0, 0, 0, 0}, 0, new int[] { 1, 3, 2, 5, 8, 7, 9 })]
            [InlineData(new int[] { 8, 7, 9 }, new int[] { 1, 3, 2, 5, 0, 0, 0 }, 4, new int[] { 1, 3, 2, 5, 8, 7, 9 })]
            public void ShouldCopySourceIntoDestinationArrayFromSpecifiedStartAndEndIndexes(int[] sourceArray, int[] destArray, int start, int[] expectedArray)
            {
                //Arrange
                //Act
                ArrayExtensions.CopyTo(sourceArray, destArray, start);

                //Assert
                Assert.Equal(destArray, expectedArray);
            }
        }

        public class SwapTests
        {
            [Fact]
            public void ShouldSwapValuesInArray()
            {
                //Arrange
                int[] array = new int[] { 1, 2, 3, 4 };
                int left = 1, right = 3;
                int originalLeft = array[left];
                int originalRight = array[right];

                //Act
                ArrayExtensions.Swap(array, left, right);

                //Assert
                Assert.Equal(originalLeft, array[right]);
                Assert.Equal(originalRight, array[left]);
            }
        }
    }
}
