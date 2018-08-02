using System;

namespace sorting
{
    class QuickSort : ISorter
    {
        public void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int start, int end) 
        {
            if(start < end) {
                int pivotIndex = Partition(array, start, end);
                // Sort(array, start, pivotIndex - 1);
                // Sort(array, pivotIndex + 1, end);
                Sort(array, start, pivotIndex - 1);
                Sort(array, pivotIndex, end);
            }
        }

        private int Partition(int[] array, int left, int right)
        {
            int mid = (left + right) / 2;
            int pivot = array[mid];

            while(left <= right)
            {
                while(array[left] < pivot) left++;
                while(array[right] > pivot) right++;

                if(left < right) {
                    Swap(array, left, right);
                    left++; right--;
                }
            }

            return left;
        }

        ///
        /// This partition algorithm takes the last item on the array as pivot
        /// Then it starts traversing the array until an item less than the pivot appears
        /// swapping the values. It then returns the pivot index.
        private int Partition3(int[] array, int start, int end) 
        {
            int pivot = array[end];
            int pivotIndex = start;

            for(int i = start; i < end; i++) 
            {
                if(array[i] <= pivot)
                {
                    Swap(array, pivotIndex, i);
                    pivotIndex++;
                }
            }
            Swap(array, pivotIndex, end);

            return pivotIndex;
        }

        private void Swap(int[] array, int index1, int index2)
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