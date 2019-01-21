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

            if(sumA == sumB) return false;
            if((sumA - sumB) % 2 != 0) return false;

            var diff = (sumA - sumB) / 2;
            var hashSet = new HashSet<long>();
            long expectedB = 0;

            for(int i = 0; i < arrayA.Length; i++) 
            {
                expectedB = arrayA[i] - diff;
                hashSet.Add(expectedB);
            }

            for (int i = 0; i < arrayB.Length; i++)
            {
                if(hashSet.Contains(arrayB[i]))
                    return true;
            }

            return false;
        }
    }
}