using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Module3
{
    [Collection("Sequential")]
    public class Task3Tests : IDisposable
    {
        private const string Inp1 = @"aaaaa";

        private const string Inp2 = @"abcabcabc";

        private const string Out1 = @"5";

        private const string Out2 = @"3";

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
            Task3.Task3Main();
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
