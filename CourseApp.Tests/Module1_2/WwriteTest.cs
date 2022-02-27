using System;
using System.IO;
using Xunit;
using CourseApp.Module1_2;

namespace CourseApp.Tests.Module1_2
{
    [Collection("Sequential")]
    public class WwriteTest : IDisposable
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
        [InlineData("Vasya", "Hello, Vasya!")]
        [InlineData("Petya", "Hello, Petya!")]
        [InlineData("Olya", "Hello, Olya!")]
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            Wwrite.WriteHello(input);

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            Assert.Equal($"{expected}", output[0]);
            var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        }
    }
}
