using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class Task2Test : IDisposable
    {
        private const string Inp1 = @"3
101 80
305 90
200 14";

        private const string Inp2 = @"3
20 80
30 90
25 90";

        private const string Out1 = @"305 90
101 80
200 14";

        private const string Out2 = @"25 90
30 90
20 80";

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
            Task2.Task2_Sort();
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
