﻿using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class MergeSortTest : IDisposable
    {
        private const string Inp1 = @"2
3 1";

        private const string Out1 = @"1 2 1 3
1 3 ";

        private const string Inp2 = @"5
5 4 3 2 1";

        private const string Out2 = @"1 2 4 5
4 5 1 2
3 5 1 3
1 5 1 5
1 2 3 4 5 ";

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

        public void Test1(string input, string expected)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            var stringReader = new StringReader(input);
            Console.SetIn(stringReader);

            // act
            MergeSort.MergeSortMethod();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var res = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", res);
        }
    }
}
