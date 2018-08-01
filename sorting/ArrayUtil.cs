using System;

namespace sorting
{
    public static class ArrayUtil
    {
        public static int[] CopyArray(int[] source) 
        {
            return CopyArray(source, 0, source.Length - 1);
        }

        public static int[] CopyArray(int[] source, int start, int end) 
        {
            int n = end - start + 1;

            if(n < 1)
                throw new ArgumentOutOfRangeException();

            var temp = new int[n];

            for(int i = 0, j = start; i < n; i++, j++) 
            {
                temp[i] = source[j];
            }

            return temp;
        }
    }
}