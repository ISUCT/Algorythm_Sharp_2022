namespace CourseApp.Tests.Module5
{
    using System;
    using System.IO;
    using CourseApp.Module5;
    using Xunit;

    [Collection("Sequential")]
    public class BalancedTree_Test : IDisposable
    {
        private const string Inp3 = @"7 3 2 1 9 5 4 6 8 0";

        private const string Out3 = @"YES";

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
            BalancedTree.TreeB();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}