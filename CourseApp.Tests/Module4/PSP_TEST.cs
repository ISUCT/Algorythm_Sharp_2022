namespace CourseApp.Tests.Module4
{
    using System;
    using System.IO;
    using CourseApp.Module4;
    using Xunit;

    [Collection("Sequential")]
    public class PSP_TEST : IDisposable
    {
        private const string Inp3 = @"())(()";

        private const string Out3 = @"2";

        private const string Inp2 = @"))(((";

        private const string Out2 = @"5";

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
        [InlineData(Inp2, Out2)]
        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            PSP.Main_PSP();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}