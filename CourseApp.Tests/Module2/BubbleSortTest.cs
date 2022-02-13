using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class BubbleSortTest : IDisposable
    {
        private const string Inp1 = @"7
5 1 7 3 9 4 1";

        private const string Out1 = @"1 5 7 3 9 4 1
1 5 3 7 9 4 1
1 5 3 7 4 9 1
1 5 3 7 4 1 9
1 3 5 7 4 1 9
1 3 5 4 7 1 9
1 3 5 4 1 7 9
1 3 4 5 1 7 9
1 3 4 1 5 7 9
1 3 1 4 5 7 9
1 1 3 4 5 7 9";

        private const string Inp2 = @"3
-10 2 7";

        private const string Out2 = @"0";

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
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            BubbleSort.BubbleSortMethod();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
