using System;
using System.IO;
using System.Linq;
using Xunit;

namespace MigratoryBirds
{
    public class MigratoryBirdsTests
    {
        private readonly MigratoryBirds _migratoryBirds;

        public MigratoryBirdsTests() 
        {
            _migratoryBirds = new MigratoryBirds();
        }

        [Fact]
        public void TestCase4()
        {
            //Arrange
            const int expectedBirdId = 3;
            var inputArray = LoadTestCaseData("testcase4.txt");

            //Act
            var birdId = _migratoryBirds.Solve(inputArray);

            //Assert
            Assert.Equal(expectedBirdId, birdId);
        }

        private static int[] LoadTestCaseData(string filename) 
        {
            // throw new NotImplementedException();
            
            using(var file = File.OpenText(filename)) 
            {
                int arrayCount = Convert.ToInt32(file.ReadLine().Trim());

                var array = file.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToArray();

                return array;
            }
        }
    }
}
