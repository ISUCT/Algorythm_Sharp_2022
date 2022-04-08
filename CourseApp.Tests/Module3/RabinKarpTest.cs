namespace CourseApp.Tests.Module3
{
    using System;
    using System.IO;
    using CourseApp.Module3;
    using Xunit;

    [Collection("Sequential")]
    public class RabinKarpTest : IDisposable
    {
        private const string Inp3 = @"aaaaa";

        private const string Out3 = @"5";

        private const string Inp2 = @"abcabcabc";

        private const string Out2 = @"3";

        private const string Inp1 = @"abab";

        private const string Out1 = @"2";

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
            Rabin_karp.Rabin_karp_Method();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}