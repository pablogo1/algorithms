namespace arrays.sorting
{
    class QuickSortA : QuickSortBase
    {
        protected override void Sort(int[] array, int start, int end)
        {
            if(start < end) {
                int pivotIndex = Partition(array, start, end);
                Sort(array, start, pivotIndex - 1);
                Sort(array, pivotIndex, end);
            }
        }

        // This partition algorithm takes a pivot as parameter (usually the mid point in the array)
        // Then it takes two pointers, left and right. Left pointer will traverse the array from left to right.
        // Whereas right pointer will do so from right to left. 
        // It will swap the left and right items once: left item is greater or equal to pivot and right item is
        // less or equal to pivot.
        protected override int Partition(int[] array, int start, int end)
        {
            int mid = (start + end) / 2;
            int pivot = array[mid];

            int left = start;
            int right = end;
            while(left <= right)
            {
                while(array[left] < pivot) left++;
                while(array[right] > pivot) right--;

                if(left <= right) {
                    array.Swap(left, right);
                    left++; right--;
                }
            }

            return left;
        }
    }
}