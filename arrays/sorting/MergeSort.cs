using System;
using System.Diagnostics;

namespace arrays.sorting
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
            int[] left = ArrayExtensions.Copy(array, 0, mid - 1);
            int[] right = ArrayExtensions.Copy(array, mid, n - 1);
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
            // Iterate both left and right arrays
            // Using i as an index for left and j for right arrays
            while(i < left.Length && j < right.Length) {
                //Compare elements from left and right arrays, if left array is greater or equal to right array element,
                // copy left item into destination array. Otherwise, copy the right item into destination array.
                if(left[i] <= right[j]) {
                    array[k++] = left[i++];
                } else {
                    array[k++] = right[j++];
                }
            }
            //Are there any remaining items on left array, copy all of them into array
            while(i < left.Length) {
                array[k++] = left[i++];
            }
            //Do the same for righ array.
            while(j < right.Length) {
                array[k++] = right[j++];
            }
        }

        void PrintArray(int[] array) 
        {
            
        }
    }
}