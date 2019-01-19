using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace array_manipulation
{
    class ArrayManipulationFixture
    {
        private readonly IDictionary<string, TestData> testDrive;
        public ArrayManipulationFixture()
        {

        }
    }

    class TestData
    {
        public int N { get; set; }
        public int[][] Queries { get; set; }
    }
}
