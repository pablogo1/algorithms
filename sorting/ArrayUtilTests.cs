using System;
using Xunit;

namespace sorting
{
    public class ArrayUtilTests
    {
        public class CopyArrayTests
        {

            [Fact]
            public void ShouldCopyArrayFromStartToFinish()
            {
                int[] array = new int[] { 1, 2, 3, 4, 5 };

                var copy = ArrayUtil.CopyArray(array);

                // Assert.
                Assert.NotSame(copy, array);
                Assert.Equal(array, copy);
            }

            [Fact]
            public void ShouldCopyArrayFromSpecifiedStartAndEnd()
            {
                int[] array = new int[] { 1, 2, 3, 4, 5 };
                int[] expected = new int[] { 1, 2, 3 };

                var copy = ArrayUtil.CopyArray(array, 0, 2);

                // Assert.
                Assert.Equal(expected, copy);
            }
        }
    }
}
