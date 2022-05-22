﻿namespace CourseApp.Tests.Module3
{
    using System;
    using System.IO;
    using Xunit;

    [Collection("Sequential")]
    public class CyclicShiftTest : IDisposable
    {
        private const string Inp1 = @"zabcd
abcdz
";

        private const string Out1 = @"4";

        private const string Inp2 = @"qwerty
wertyq
";

        private const string Out2 = @"5";

        private const string Inp4 = @"qwertyui
qwertyui
";

        private const string Out4 = @"0";

        private const string Inp5 = @"qw
wq
";

        private const string Out5 = @"1";

        private const string Inp6 = @"a
b
";

        private const string Out6 = @"-1";

        private const string Inp10 = @"aaaaaaaaaaaaaaaaaaaaaaaaaab
aaaaaaaaaaaaaaaaaaaaaaaaaba
";

        private const string Out10 = @"26";

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
        [InlineData(Inp4, Out4)]
        [InlineData(Inp5, Out5)]
        [InlineData(Inp6, Out6)]
        [InlineData(Inp10, Out10)]
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            CyclicShift.CyclicShiftMethod();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}