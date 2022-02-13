using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod()
        {
            string[] inputData = File.ReadAllLines("input.txt");

            int[] array = new int[int.Parse(inputData[0])];
            foreach (var pair in inputData[1].Split(" ").Select((x, i) => new { Index = i, Value=x }))
            {
                array[pair.Index] = int.Parse(pair.Value);
            }

            StreamWriter output = new StreamWriter("output.txt");
            bool trigger = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        output.WriteLine(string.Join(" ", array));
                        trigger = true;
                    }
                }
            }

            if (!trigger)
            {
                output.WriteLine("0");
            }

            output.Close();
        }
    }
}
