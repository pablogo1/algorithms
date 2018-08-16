using System;

namespace sorting
{
    abstract class QuickSortBase : ISorter
    {
        public void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        protected abstract void Sort(int[] array, int start, int end);

        protected abstract int Partition(int[] array, int start, int end);
    }
}