using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Module4
{
    [Collection("Sequential")]
    public class Task3Tests : IDisposable
    {
        private const string Inp1 = @"10
1 2 3 2 1 4 2 5 3 1";

        private const string Inp2 = @"3
1 2 3";

        private const string Out1 = @"-1 4 3 4 -1 6 9 8 9 -1";

        private const string Out2 = @"-1 -1 -1";

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
            Task3.Program.Task3Main();
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
