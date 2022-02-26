namespace CourseApp.Tests.Module2
{
    using System;
    using System.IO;
    using Xunit;

    [Collection("Sequential")]
public class CountDiffTest : IDisposable
{
    private const string Inp1 = @"5
1 0 1 2 0";

        private const string Inp2 = @"10
1 0 1 2 0 4 4 4 9 1";

        private const string Out1 = @"3";

        private const string Out2 = @"5";

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
        CountDiff.CountDiffMethod();

        // assert
        var output = stringWriter.ToString();
        var result = string.Join(Environment.NewLine, output);

        Assert.Equal($"{expected}", result);
    }
}
}