using System;
using System.IO;
using System.Text;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class PurchaseTest : IDisposable
    {
        private const string Inp1 = @"5
1 50 3 4 3
16
1 2 3 4 5 1 3 3 4 5 5 5 5 5 4 5";

        private const string Out1 = @"yes
no
no
no
yes
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
        public void Checking_Counting_Works_Correctly(string input, string expected)
        {
            // act
            StreamWriter write = new StreamWriter("input.txt");
            write.WriteLine(input);
            write.Close();

            Purchase.CountPurcase();

            // assert
            var output = File.ReadAllText("output.txt");
            Assert.Equal($"{expected}", output);
            File.Delete("input.txt");
            File.Delete("output.txt");
        }
    }
}