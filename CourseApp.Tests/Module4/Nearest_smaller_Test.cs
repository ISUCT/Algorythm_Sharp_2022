namespace CourseApp.Tests.Module4
{
    using System;
    using System.IO;
    using CourseApp.Module4;
    using Xunit;

    [Collection("Sequential")]
    public class Nearest_smaller_Test : IDisposable
    {
        private const string Inp3 = @"10
1 2 3 2 1 4 2 5 3 1";

        private const string Out3 = @"-1 4 3 4 -1 6 9 8 9 -1 ";

        public void Dispose()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            var standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
        }

        [Theory]
        [InlineData(Inp3, Out3)]
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            Nearest_smaller.Nearest_smaller_Main();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}