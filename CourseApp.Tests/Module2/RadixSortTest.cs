using System;
using System.IO;
using Xunit;
using CourseApp.Module2;

namespace CourseApp.Tests.Module2
{
    [Collection("Sequential")]
    public class RadixSortTest : IDisposable
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

       /* private const string Inp2 = @"9
12
32
15
77
12
11
97
98
29
61
35
09";*/

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
09, 12, 29, 32, 35, 45, 61, 67, 98
";

      /*  private const string Out2 = @"Initial array:
12, 32, 15, 77, 12, 11, 97, 98, 29
**********
Phase 1
Bucket 0: empty
Bucket 1: 11
Bucket 2: 12, 32, 12
Bucket 3: empty
Bucket 4: empty
Bucket 5: 15
Bucket 6: empty
Bucket 7: 77, 97
Bucket 8: 98
Bucket 9: 29
**********
Phase 2
Bucket 0: empty
Bucket 1: 11, 12, 12, 15
Bucket 2: 29
Bucket 3: 32
Bucket 4: empty
Bucket 5: empty
Bucket 6: empty
Bucket 7: 77
Bucket 8: empty
Bucket 9: 97, 98
**********
Sorted array:
11, 12, 12, 15, 29, 32, 77, 97, 98
";
*/
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

        // [InlineData(Inp2, Out2)]
        public void Checking_RadixSort_Works_Correctly(string input, string expected)
        {
            // act
            StreamWriter write = new StreamWriter("input.txt");
            write.WriteLine(input);
            write.Close();

            RadixSort.DoSort();

            // assert
            var output = File.ReadAllText("output.txt");
            Assert.Equal($"{expected}", output);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            File.Delete("output.txt");
            File.Delete("input.txt");
        }
    }
}