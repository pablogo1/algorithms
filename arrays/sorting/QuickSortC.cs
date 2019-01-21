using System;

namespace arrays.sorting
{
    class QuickSortC : QuickSortBase
    {
        protected override void Sort(int[] array, int start, int end)
        {
            Console.WriteLine($"Sort: start = {start}; end = {end}");

            if(start < end) {
                int pivotIndex = Partition(array, start, end);
                Sort(array, start, pivotIndex - 1);
                Sort(array, pivotIndex + 1, end);
            }
        }

        protected override int Partition(int[] array, int start, int end)
        {
            int pivot = array[start];
            int pivotIndex = start;
            int current = 0;
            int[] helper = new int[(end - start + 1)];

            for(int i = start + 1; i <= end; i++) {
                if(array[i] < pivot) {
                    helper[current++] = array[i];
                }
            }
            pivotIndex = current + start;
            helper[current++] = pivot;
            for(int i = start + 1; i <= end; i++) {
                if(array[i] >= pivot) {
                    helper[current++] = array[i];
                }
            }

            helper.CopyTo(array, start);
            return pivotIndex;
        }
    }
}