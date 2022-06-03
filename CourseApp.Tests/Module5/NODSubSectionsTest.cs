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
    public class NODSubSectionsTest : IDisposable
    {
        private const string Inp1 = @"5
2 2 2 1 5
2
2 3
2 5";

        private const string Out1 = @"2 1 ";

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
            NODSubSections.NODSubSections_Main();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
