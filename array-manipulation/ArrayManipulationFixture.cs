using System;
using System.Collections.Generic;
using System.IO;

namespace array_manipulation
{
    public class ArrayManipulationFixture
    {
        public ArrayManipulationFixture()
        {
            TestCases = new Dictionary<string, TestData>();

            LoadTestCase("testCase1");
            LoadTestCase("testCase4");
            LoadTestCase("testCase7");
        }

        internal IDictionary<string, TestData> TestCases { get; }

        void LoadTestCase(string testCaseName)
        {
            if (TestCases.ContainsKey(testCaseName)) return;

            var testCaseData = new TestData();
            var filename = $"{testCaseName}.txt";

            using (var file = File.OpenText(filename))
            {
                string[] nm = file.ReadLine().Split(' ');
                int n = Convert.ToInt32(nm[0]);
                int m = Convert.ToInt32(nm[1]);

                int[][] queries = new int[m][];

                for (int i = 0; i < m; i++)
                {
                    queries[i] = Array.ConvertAll(file.ReadLine().Split(' '), queriesTemp => Convert.ToInt32(queriesTemp));
                }

                testCaseData.ArraySize = n;
                testCaseData.Queries = queries;
            }

            TestCases.Add(testCaseName, testCaseData);
        }

    }
}