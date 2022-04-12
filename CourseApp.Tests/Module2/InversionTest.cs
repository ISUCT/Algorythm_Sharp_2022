using System;
using System.IO;
using System.Text;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class InversionTest : IDisposable
    {
        private const string Inp1 = @"2
3 1";

        private const string Inp2 = @"5
5 4 3 2 1";

        private const string Out1 = @"1
";

        private const string Out2 = @"10
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
        public void Checking_Invesrion_Count_Correctly(string input, string expected)
        {
            // act
            StreamWriter write = new StreamWriter("input.txt");
            write.WriteLine(input);
            write.Close();

            Inversion.CountInversions();

            // assert
            var output = File.ReadAllText("output.txt");
            Assert.Equal($"{expected}", output);
            File.Delete("input.txt");
            File.Delete("output.txt");
        }
    }
}