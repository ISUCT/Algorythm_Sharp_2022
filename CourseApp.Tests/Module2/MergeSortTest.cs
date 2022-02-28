using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class MergeSortTest : IDisposable
    {
        private const string Inp1 = @"4
4 3 2 1";

        private const string Out1 = @"3 4 2 1
3 2 4 1
3 2 1 4
2 3 1 4
2 1 3 4
1 2 3 4";
        private const string Inp2 = @"4
1 2 3 4";

        private const string Out2 = @"0";

        public void Dispose()
        {
            var standardOut = new StreamWriter(Console.OpenStandardOutput());
            standardOut.AutoFlush = true;
            var standardIn = new StreamReader(Console.OpenStandardInput());
            Console.SetOut(standardOut);
            Console.SetIn(standardIn);
        }

        [Theory]
        [InlineData(new int[] { 1 }, new int[] { 2 }, new int[] { 1 , 2 })]
        [InlineData(new int[] { 1 }, new int[] { 2, 3 }, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 5, 6 }, new int[] { 2 }, new int[] { 2, 5, 6 })]
        [InlineData(new int[] { 1, 3}, new int[] { 3, 4 }, new int[] { 1, 3, 3, 4 })]
        public void TestMerge(int[] a, int[] b, int[] exp)
        {
            var res = MergeSort.Merge(a, b);
            Assert.Equal(exp, res);
        }

        [Theory]
        [InlineData(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3 }, new int[] { 2, 1 })]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4 }, new int[] { 3, 2, 1 })]
        public void TestSplit(int[] array, int[] leftExp, int[] rightExp)
        {
            var (left, right) = MergeSort.Split(array);
            Assert.Equal(leftExp, left);
            Assert.Equal(rightExp, right);
        }

        [Theory]
        [InlineData(new int[] { 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4 })]
        [InlineData(new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 })]
        public void TestSorting(int[] array, int[] expResult)
        {
            var result = MergeSort.MergeSorting(array);
            Assert.Equal(expResult, result);
        }

        /*[Theory]
        [InlineData(Inp1, Out1)]
        [InlineData(Inp2, Out2)]

        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            BubbleSort.BubbleSortMethod();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);
            Assert.Equal($"{expected}", result);
        }
        */
    }
}