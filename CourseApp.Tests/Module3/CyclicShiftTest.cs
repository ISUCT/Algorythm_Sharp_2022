namespace CourseApp.Tests.Module3
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CourseApp.Module3;
    using Xunit;

    [Collection("Sequential")]
    public class CyclicShiftTest : IDisposable
    {
        private const string Inp1 = @"a
b";

        private const string Out1 = @"-1";
        private const string Inp2 = @"zabcd
abcdz";

        private const string Out2 = @"4";

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
            CyclicShift.CyclicShift_Main();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
