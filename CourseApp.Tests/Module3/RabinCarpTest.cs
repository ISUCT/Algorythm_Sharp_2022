using System;
using System.IO;
using Xunit;
using CourseApp.Module3;

namespace CourseApp.Tests.Module3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Xunit;
    using CourseApp.Module3;

    [Collection("Sequential")]
    public class RabinCarpTest : IDisposable
    {
        private const string Inp1 = @"ababbababa
aba
";

        private const string Out1 = @"0 5 7";

        public void Dispose()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            var standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
        }

        [Theory]
        //[InlineData("AB", 3, 7, 1)]
        [InlineData("BBA", 3, 7, 4)]
        //[InlineData("ABBA", 3, 7, 5)]
        //[InlineData("aba", 257, 3571, 907)]

        public void TestHash1(string input, int x, int p, int exp)
        {
            var res = RabinCarp.CalculateHash(input, x, p);
            Assert.Equal(exp, res);
        }

        [Theory]
        [InlineData("ABB", 'A', 4, 3, 7, 5)]
        [InlineData("aba", 'b', 907, 257, 3571, 2422)]

        public void TestSlidingHash1(string input, char append, int hash, int x, int p, int exp)
        {
            var res = RabinCarp.SlidingHash(input, append, hash, x, p);
            Assert.Equal(exp, res);
        }

        [Theory]
        [InlineData(Inp1, Out1)]

        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            RabinCarp.RabinCarpMethod();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
