using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class PairSortTest : IDisposable
    {
        private const string Inp1 = @"101 80
305 90
200 14";

        private const string Inp2 = @"20 90
30 90
25 90";

        private const string Out1 = @"305 90
101 80
200 14
";

        private const string Out2 = @"20 90
25 90
30 90
";

        public void Dispose()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            var standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
        }

        [Theory]
        [InlineData(Inp1, Out1)]
        [InlineData(Inp2, Out2)]
        public void Checking_PairSort_Works_Correctly(string input, string expected)
        {
            // act
            string[] buffer = input.Split("\r\n").ToArray();

            PairSort.PairBubbleSortMethod(buffer);

            // assert
            var output = File.ReadAllText("output.txt");
            Assert.Equal($"{expected}", output);
            File.Delete("output.txt");
        }
    }
}