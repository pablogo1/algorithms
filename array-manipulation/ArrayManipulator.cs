using System.Linq;

namespace array_manipulation
{
    internal class ArrayManipulator
    {
        public long GetMaxInArray(TestData testData)
        {
            var array = Enumerable.Repeat((long)0, testData.ArraySize + 1)
                              .ToArray();
            DoInsert(testData.Queries, array);

            return Max(array);
        }

        void DoInsert(int[][] queries, long[] array)
        {
            int a, b, k;
            for (int queryLine = 0; queryLine < queries.Length; queryLine++)
            {
                a = queries[queryLine][0];
                b = queries[queryLine][1];
                k = queries[queryLine][2];

                array[a] += k;

                if ((b + 1) < array.Length) 
                    array[(b + 1)] -= k;
                /*
                for (int index = a; index <= b; index++)
                {
                    array[index] += k;
                }*/
            }
        }

        long Max(long[] array) {
            long max = 0, temp = 0;

            for (int i = 1; i < array.Length; i++) {
                temp += array[i];
                if (max < temp)
                    max = temp;
            }

            return max;
        }
    }
}