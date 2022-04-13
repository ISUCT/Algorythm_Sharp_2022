using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static void DoSort()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            string[] array = new string[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = reader.ReadLine();
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine("Initial array:" + Environment.NewLine + string.Join(", ", array));
            RadixSortMethod(array, size, output);
            output.WriteLine("**********" + Environment.NewLine + "Sorted array:" + Environment.NewLine + string.Join(", ", array));
            output.Close();
        }

        public static void RadixSortMethod(string[] array, int size, StreamWriter output)
        {
            int max_radix = array[0].Length;
            for (int i = max_radix - 1; i >= 0; i--)
            {
                var steps = Enumerable.Range(0, 10).Select((item) => new List<string>()).ToArray();
                output.WriteLine("**********" + Environment.NewLine + $"Phase {max_radix - i}");
                for (int j = 0; j < size; j++)
                {
                    steps[array[j][i] - '0'].Add(array[j]);
                }

                int index = 0;
                for (int j = 0; j < 10; j++)
                {
                    output.WriteLine($"Bucket {j}: " + ((steps[j].Count == 0) ? "empty" : string.Join(", ", steps[j])));
                    for (int k = 0; k < steps[j].Count; k++)
                    {
                    array[index] = steps[j].ElementAt(k);
                    index++;
                    }
                }
            }
        }
    }
}