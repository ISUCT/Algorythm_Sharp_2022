using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static void MergeSortMethod()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] s_mas = s.Split(" ");
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = int.Parse(s_mas[i]);
            }

            MergeSortS(mas, 0, n);
            DisplayArray(mas);
        }

        private static void MergeSortS(int[] array, int left_bord, int right_bord)
        {
            if (array.Length == 1)
            {
                return;
            }

            int middle = array.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[array.Length - middle];

            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
            }

            for (int i = middle; i < array.Length; i++)
            {
                right[i - middle] = array[i];
            }

            int middle_s = (left_bord + right_bord) / 2;

            MergeSortS(left, left_bord, middle_s);
            MergeSortS(right, middle_s, right_bord);

            Console.Write($"{left_bord + 1} {right_bord}");

            Merge(array, left, right);
        }

        private static void Merge(int[] targetArray, int[] mas1, int[] mas2)
        {
            int mas1MinIndex = 0;
            int mas2MinIndex = 0;
            int targerArrayMinIndex = 0;

            while (mas1MinIndex < mas1.Length && mas2MinIndex < mas2.Length)
            {
                if (mas1[mas1MinIndex] <= mas2[mas2MinIndex])
                {
                    targetArray[targerArrayMinIndex] = mas1[mas1MinIndex];
                    mas1MinIndex++;
                }
                else
                {
                    targetArray[targerArrayMinIndex] = mas2[mas2MinIndex];
                    mas2MinIndex++;
                }

                targerArrayMinIndex++;
            }

            while (mas1MinIndex < mas1.Length)
            {
                targetArray[targerArrayMinIndex] = mas1[mas1MinIndex];
                mas1MinIndex++;
                targerArrayMinIndex++;
            }

            while (mas2MinIndex < mas2.Length)
            {
                targetArray[targerArrayMinIndex] = mas2[mas2MinIndex];
                mas2MinIndex++;
                targerArrayMinIndex++;
            }

            Console.WriteLine($" {targetArray[0]} {targetArray[targetArray.Length - 1]}");
        }

        private static void DisplayArray(int[] array)
        {
            Console.WriteLine("{0}", string.Join(" ", array));
        }
    }
}
