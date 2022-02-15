using System;
using System.IO;
using System.Linq;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class PairSortTest
    {
        private const string Inp1 = @"101 80
305 90
200 14";

        private const string Inp2 = @"25 90
20 90
30 90";

        private const string Out1 = @"305 90
101 80
200 14";

        private const string Out2 = @"20 90
25 90
30 90";

        [Theory]
        [InlineData(Inp1, Out1)]
        [InlineData(Inp2, Out2)]
        public void Checking_PairSort_Works_Correctly(string input, string expected)
        {
            // act
            string[] testingData = input.Split("\r\n").ToArray();

            string answer = string.Join("\r\n", PairSort.PairBubbleSortMethod(testingData));

            // assert
            Assert.Equal($"{expected}", answer);
        }
    }
}
