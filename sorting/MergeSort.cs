using System;
using System.Diagnostics;

namespace sorting
{
    class MergeSort : ISorter
    {
        public void Sort(int[] array)
        {
            int n = array.Length;

            if(n < 2) {
                return;
            }

            int mid = n / 2;
            int[] left = ArrayUtil.CopyArray(array, 0, mid - 1);
            int[] right = ArrayUtil.CopyArray(array, mid, n - 1);
            Sort(left);
            Sort(right);
            Merge(left, right, array);
            left = right = null;
        }

        void Merge(int[] left, int[] right, int[] array)
        {
            if((left.Length + right.Length) > array.Length)
                throw new ArgumentOutOfRangeException();

            int k = 0, i = 0, j = 0;
            while(i < left.Length && j < right.Length) {
                if(left[i] <= right[j]) {
                    array[k++] = left[i++];
                } else {
                    array[k++] = right[j++];
                }
            }
            while(i < left.Length) {
                array[k++] = left[i++];
            }
            while(j < right.Length) {
                array[k++] = right[j++];
            }
        }

        void PrintArray(int[] array) 
        {
            
        }
    }
}