namespace CourseApp.Tests.Module5
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CourseApp.Module5;
    using Xunit;

    [Collection("Sequential")]
    public class NODSubSectionDynamicTest : IDisposable
    {
        private const string Inp1 = @"5
2 8 4 16 12
5
s 1 5
s 4 5
u 3 32
s 2 5
s 3 3";

        private const string Out1 = @"2 4 4 32 ";

        public void Dispose()
        {
            var standardIn = new StreamReader(Console.OpenStandardInput());
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
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
            NODSubSectionDynamic.NODSubSectionDynamic_Main();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
