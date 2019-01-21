using System;
using System.Collections;
using System.Linq;

namespace Arrays.Search
{
    public static class BinarySearch
    {
        public static bool Search(long[] array, long lookupValue)
        {
            Array.Sort(array);
            // int index =  SearchInternal(array, lookupValue, 0, array.Length - 1);
            int index = BinarySearchLoop(array, lookupValue);
            
            return index >= 0;
        }

        private static int SearchInternal(long[] array, long lookupValue, int startIndex, int endIndex)
        {
            if(startIndex > endIndex)
            {
                return -1; //Value not found.
            }

            int midIndex = (endIndex + startIndex) / 2;
            if(lookupValue > array[midIndex]) 
            {
                return SearchInternal(array, lookupValue, midIndex + 1, endIndex);
            } 
            else if(lookupValue < array[midIndex])
            {
                return SearchInternal(array, lookupValue, startIndex, midIndex - 1);
            }

            return midIndex;
        }

        private static int BinarySearchLoop(long[] array, long lookupValue)
        {
            int startIndex = 0;
            int endIndex = array.Length - 1;
            int midIndex = 0;

            while(startIndex <= endIndex) 
            {
                midIndex = (endIndex + startIndex) / 2;

                if(lookupValue > array[midIndex])
                {
                    startIndex = midIndex + 1;
                } 
                else if(lookupValue < array[midIndex])
                {
                    endIndex = midIndex - 1;
                }
                else if(lookupValue == array[midIndex])
                {
                    return midIndex;
                }
            }

            return -1;
        }
    }
}