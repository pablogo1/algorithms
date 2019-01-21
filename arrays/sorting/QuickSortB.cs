namespace arrays.sorting
{
    class QuickSortB : QuickSortBase
    {
        protected override void Sort(int[] array, int start, int end)
        {
            if(start < end) {
                int pivotIndex = Partition(array, start, end);
                Sort(array, start, pivotIndex - 1);
                Sort(array, pivotIndex + 1, end);
            }
        }

        ///
        /// This partition algorithm takes the last item on the array as pivot
        /// Then it starts traversing the array until an item less than the pivot appears
        /// swapping the values. It then returns the pivot index.
        protected override int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pivotIndex = start;

            for(int i = start; i < end; i++) 
            {
                if(array[i] <= pivot)
                {
                    array.Swap(pivotIndex, i);
                    pivotIndex++;
                }
            }
            array.Swap(pivotIndex, end);

            return pivotIndex;
        }

    }
}