namespace CourseApp.Tests.Module2
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CourseApp.Module2;
    using Xunit;

    [Collection("Sequential")]
    public class InversionCountTest : IDisposable
    {
        private const string Inp1 = @"1
1";

        private const string Out1 = @"0";

        private const string Inp2 = @"2
3 1";

        private const string Out2 = @"1";

        private const string Inp3 = @"5
5 4 3 2 1";

        private const string Out3 = @"10";

        public void Dispose()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            var standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
        }

        [Theory]
        [InlineData(Inp2, Out2)]
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            InversionCount.CountInversion();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}