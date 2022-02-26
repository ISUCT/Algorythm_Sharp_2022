using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static void DoMergeSort()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());

            int[] data = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();

            List<string> steps = new List<string>();
            StreamWriter output = new StreamWriter("output.txt");
            data = MergeSortMethod(data, 0, size, steps);
            foreach (var item in steps)
            {
                output.WriteLine(item);
            }

            output.WriteLine(string.Join(" ", data));
            output.Close();
        }

        public static int[] MergeSortMethod(int[] array, int lowIndex, int highIndex, List<string> steps)
        {
            if (highIndex - lowIndex == 1)
            {
                int[] result = new int[1];
                result[0] = array[lowIndex];
                return result;
            }

            int middleIndex = (highIndex + lowIndex) / 2;
            int[] first_half = MergeSortMethod(array, lowIndex, middleIndex, steps);
            int[] second_half = MergeSortMethod(array, middleIndex, highIndex, steps);
            int[] sorted = Merge(first_half, second_half);

            steps.Add($"{lowIndex + 1} {highIndex} {sorted[0]} {sorted[sorted.Length - 1]}");
            return sorted;
        }

        public static int[] Merge(int[] first, int[] second)
        {
            int left = 0;
            int right = 0;
            int[] result_array = new int[first.Length + second.Length];

            for (int index = 0; index < result_array.Length; index++)
            {
                if (right == second.Length || (left < first.Length && first[left] < second[right]))
                {
                    result_array[index] = first[left];
                    left++;
                }
                else
                {
                    result_array[index] = second[right];
                    right++;
                }
            }

            return result_array;
        }
    }
}