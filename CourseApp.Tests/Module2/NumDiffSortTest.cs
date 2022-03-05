﻿using System;
using System.Collections.Generic;
using System.IO;
using CourseApp.Module2;
using Xunit;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]

    public class NumDiffSortTest : IDisposable
    {
        private const string Inp1 = @"5
1 0 1 2 0";

        private const string Out1 = @"3";

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
            NumDiff.NumDifferent();

            // assert
            var output = stringWriter.ToString().Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Join(Environment.NewLine, output);

            Assert.Equal($"{expected}", result);
        }
    }
}