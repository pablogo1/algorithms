using System;

namespace arrays
{
    public static class ArrayExtensions
    {
        public static int[] Copy(this int[] source) 
        {
            return Copy(source, 0, source.Length - 1);
        }

        public static int[] Copy(this int[] source, int start, int end) 
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

        public static void CopyTo(this int[] source, int[] dest, int start) 
        {
            if(source.Length + start > dest.Length)
                throw new ArgumentOutOfRangeException(nameof(start));

            int current = start;
            for(int i = 0; i < source.Length; i++) 
            {
                dest[current++] = source[i];
            }
        }

        public static void Swap(this int[] array, int index1, int index2)
        {
            if(index1 < 0 && index1 >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(index1));
            if(index2 < 0 && index2 >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(index2));

            int temp = array[index2];
            array[index2] = array[index1];
            array[index1] = temp;
        }
    }
}