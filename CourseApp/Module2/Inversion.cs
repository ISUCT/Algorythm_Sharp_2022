using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module2
{
    public class Inversion
    {
        private static ulong count;

        public static void CountInversions()
        {
            count = 0;
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());

            int[] data = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();

            StreamWriter output = new StreamWriter("output.txt");
            data = MergeSortMethod(data, 0, size);

            output.WriteLine(count);
            output.Close();
        }

        public static int[] MergeSortMethod(int[] array, int lowIndex, int highIndex)
        {
            if (highIndex - lowIndex == 1)
            {
                int[] result = new int[1];
                result[0] = array[lowIndex];
                return result;
            }

            int middleIndex = (highIndex + lowIndex) / 2;
            int[] first_half = MergeSortMethod(array, lowIndex, middleIndex);
            int[] second_half = MergeSortMethod(array, middleIndex, highIndex);
            int[] sorted = Merge(first_half, second_half);

            return sorted;
        }

        public static int[] Merge(int[] first, int[] second)
        {
            int left = 0;
            int right = 0;
            int[] result_array = new int[first.Length + second.Length];

            for (int index = 0; index < result_array.Length; index++)
            {
                if (left == first.Length)
                {
                    result_array[index] = second[right];
                    right++;
                }
                else if (right == second.Length)
                {
                    result_array[index] = first[left];
                    left++;
                }
                else if (first[left] <= second[right])
                {
                    result_array[index] = first[left];
                    left++;
                }
                else
                {
                    result_array[index] = second[right];
                    right++;
                    count += Convert.ToUInt32(first.Length - left);
                }
            }

            return result_array;
        }
    }
}