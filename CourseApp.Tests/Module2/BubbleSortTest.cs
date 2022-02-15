using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class BubbleSortTest : IDisposable
    {
        private const string Inp1 = @"4
6 2 3 1";

        private const string Out1 = @"2 6 3 1
2 3 6 1
2 3 1 6
2 1 3 6
1 2 3 6
";

        private const string Inp2 = @"4
1 2 5 7";

        private const string Out2 = @"0
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
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            BubbleSort.BubbleSortMethod();

            // assert
            var output = stringWriter.ToString();
            Assert.Equal($"{expected}", output);
        }
    }
}
