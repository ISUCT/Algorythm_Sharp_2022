using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace Module4
{
    [Collection("Sequential")]
    public class Task4Tests : IDisposable
    {
        private const string Inp1 = @"3
3 2 1";

        private const string Inp2 = @"4
4 1 3 2";

        private const string Out1 = @"YES";

        private const string Out2 = @"YES";

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
            Task2.Task2Main();
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
