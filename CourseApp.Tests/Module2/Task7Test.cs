using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class Task7Test : IDisposable
    {
        private const string Inp1 = @"9
12
32
45
67
98
29
61
35
09";

    private const string Out1 = @"Initial array:
12, 32, 45, 67, 98, 29, 61, 35, 09
**********
Phase 1
Bucket 0: empty
Bucket 1: 61
Bucket 2: 12, 32
Bucket 3: empty
Bucket 4: empty
Bucket 5: 45, 35
Bucket 6: empty
Bucket 7: 67
Bucket 8: 98
Bucket 9: 29, 09
**********
Phase 2
Bucket 0: 09
Bucket 1: 12
Bucket 2: 29
Bucket 3: 32, 35
Bucket 4: 45
Bucket 5: empty
Bucket 6: 61, 67
Bucket 7: empty
Bucket 8: empty
Bucket 9: 98
**********
Sorted array:
09, 12, 29, 32, 35, 45, 61, 67, 98";

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
            Task7.Task7_Main();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
    }
}
