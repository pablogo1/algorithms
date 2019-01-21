using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Arrays.SwapSum
{
    public class SwapSum
    {
        public static bool AreElegible(long[] arrayA, long[] arrayB)
        {
            var sumA = arrayA.Sum();
            var sumB = arrayB.Sum();

            // if the sum of the arrays are already equal then return true as
            // we can swap elements without altering the results.
            if(sumA == sumB) return true;
            // if the difference of the sums is odd, then no elements can be 
            // swapped to get an equal sum of both arrays.
            // The detailed explanation:
            //  The effect of swapping elements from A to B on the sum is:
            //   sumA = sumA - a + b
            //   sumB = sumB - b + a
            //  As sumA == sumB then
            //   sumA - a + b = sumB - b + a => (sumA - sumB) = 2(a - b) => (a - b) = (sumA - sumB) / 2
            //  This tells that:
            //   1. The difference between the sums of A and B must be even.
            //   2. The difference between the swapping elements is equal to the difference of the sums of A and B divided by 2.
            if((sumA - sumB) % 2 != 0) return false;

            var diff = (sumA - sumB) / 2;
            var hashSet = new HashSet<long>();
            long expectedB = 0;

            // Given that: (a - b) = (sumA - sumB) / 2
            // Solving for b: b = a - ((sumA - sumB) / 2)
            // That means we can determine the value of the element on arrayB based on the sum difference and arrayA elements.
            // Here we calculate the value of the expected B value and then store it on a hashSet (this will allow a O(1) lookup)
            for(int i = 0; i < arrayA.Length; i++) 
            {
                expectedB = arrayA[i] - diff;
                hashSet.Add(expectedB);
            }

            // For each element on arrayB, check if element exists on hashSet. If true, return true; false otherwise.
            for (int i = 0; i < arrayB.Length; i++)
            {
                if(hashSet.Contains(arrayB[i]))
                    return true;
            }

            return false;
        }
    }
}