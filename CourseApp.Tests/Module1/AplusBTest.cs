namespace CourseApp.Tests.Module1
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CourseApp.Module1;
    using Xunit;

    [Collection("Sequential")]
    public class AplusBTest : IDisposable
    {
        public void Dispose()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            var standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
        }

        [Theory]
        [InlineData("10 12", "22")]
        [InlineData("1 1", "2")]
        [InlineData("10000 10000", "20000")]
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            AplusB.Calculate();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal($"{expected}", output[0]);
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        }
    }
}
