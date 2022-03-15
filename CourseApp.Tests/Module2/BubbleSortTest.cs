using System;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class BubbleSortTest : IDisposable
    {
        private const string Inp1 = @"5
4 3 2 1 10";

        private const string Inp2 = @"4
4 3 2 1";

        private const string Out1 = @"3 4 2 1 10
3 2 4 1 10
3 2 1 4 10
2 3 1 4 10
2 1 3 4 10
1 2 3 4 10
";

        private const string Out2 = @"3 4 2 1
3 2 4 1
3 2 1 4
2 3 1 4
2 1 3 4
1 2 3 4
";

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
        public void Check_BubbleSort(string input, string expected)
        {
            // act
            StreamWriter write = new StreamWriter("input.txt");
            write.WriteLine(input);
            write.Close();

            BubbleSort.DoBubbleSort();

            // assert
            var output = File.ReadAllText("output.txt");
            Assert.Equal(expected, output);
            File.Delete("input.txt");
            File.Delete("output.txt");
        }
    }
}