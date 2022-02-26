using CourseApp.Module2;
using Module2;

namespace CourseApp.Tests.Module2;

using System;
using System.IO;
using Xunit;

[Collection("Sequential")]
public class CountDiffTest : IDisposable
{
    private const string Inp1 = @"5
1 0 1 2 0
";

    private const string Out1 = @"3
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
    public void Test1(string input, string expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);

        var stringReader = new StringReader(input);
        Console.SetIn(stringReader);

        // act
        CountDiff.Count();

        // assert
        var output = stringWriter.ToString();
        Assert.Equal($"{expected}", output);
    }
}