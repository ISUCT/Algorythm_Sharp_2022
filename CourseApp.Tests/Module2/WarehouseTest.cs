using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class WarehouseTest : IDisposable
    {
        private const string Inp1 = @"5
1 50 3 4 3
16
1 2 3 4 5 1 3 3 4 5 5 5 5 5 4 5";

        private const string Out1 = @"yes
no
no
no
yes";

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

        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            Warehouse.WarehouseMethod();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var res = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", res);
        }
    }
}
