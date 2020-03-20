using System;
using System.Diagnostics;

namespace Arrays.TwoSortedArraysMedian
{
    public class Solution
    {
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) 
        {
            // first determine the number of items each of the arrays will contribute
            // to the left half of the merged array
            int[] A = nums1;
            int[] B = nums2;

            if (nums1.Length > nums2.Length)
            {
                A = nums2;
                B = nums1;
            }

            return FindMedianSortedArrays(A, B, 0, A.Length);
        }

        private static double FindMedianSortedArrays(int[] A, int[] B, int start, int end)
        {
            Console.WriteLine($"start = {start}; end = {end}");
            
            int halfLength = (A.Length + B.Length + 1) / 2;
            int partitionA = (end + start) / 2;
            int partitionB = halfLength - partitionA;

            Debug.WriteLine($"partitionA = {partitionA}; partitionB = {partitionB}");

            int x = partitionA > 0 ? A[partitionA - 1] : int.MinValue;
            int xP = partitionA >= A.Length ? int.MaxValue : A[partitionA];
            int y = partitionB > 0 ? B[partitionB - 1] : int.MinValue;
            int yP = partitionB >= B.Length ? int.MaxValue : B[partitionB];

            Debug.WriteLine($"x = {x}; xP = {xP}");
            Debug.WriteLine($"y = {y}; yP = {yP}");

            if (x <= yP && y <= xP)
            {
                if ((A.Length + B.Length) % 2 == 0)
                {
                    return (Math.Max(x, y) + Math.Min(xP, yP)) / 2.0d;
                }

                return Math.Max(x, y);
            }
            else if (x > yP)
            {
                return FindMedianSortedArrays(A, B, start, partitionA);
            }
            else
            {
                return FindMedianSortedArrays(A, B, partitionA + 1, end);
            }
        }
    }
}