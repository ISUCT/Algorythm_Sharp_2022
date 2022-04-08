using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseApp.Module2
{
    public class BitwiseSort
    {
        public static void Radixsort(string[] arrayStrings)
        {
            Console.WriteLine("Initial array:");
            Console.WriteLine(string.Join(", ", arrayStrings));
            int poz = 1;
            int rank = arrayStrings[0].Length;

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x_1 => rank - 1 + (x_1 * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine($"Phase {poz}");
                arrayStrings = CountSort(arrayStrings, poz, rank);
                poz++;
            }

            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.Write(string.Join(", ", arrayStrings));
        }

        public static string[] CountSort(string[] arrayString, int phase, int lenght)
        {
            int i;
            List<string>[] arrayListens = new List<string>[10];
            for (int x = 0; x < 10; x++)
            {
                arrayListens[x] = new List<string>();
            }

            for (int j = 0; j < arrayString.Length; j++)
            {
                int y = int.Parse(arrayString[j].Substring(lenght - phase, 1));
                arrayListens[y].Add(arrayString[j]);
            }

            for (i = 0; i < 10; i++)
            {
                if (arrayListens[i].Count == 0)
                {
                    Console.WriteLine("Bucket " + i + ": empty");
                }
                else
                {
                    Console.WriteLine("Bucket " + i + ": {0}", string.Join(", ", arrayListens[i]));
                }
            }

            int z = 0;

            for (i = 0; i < 10; i++)
            {
                for (int j = 0; j < arrayListens[i].Count; j++)
                {
                    arrayString[z] = arrayListens[i][j];
                    z++;
                }
            }

            return arrayString;
        }

        public static void BitwiseSortMain()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr_str = new string[n];
            for (int i = 0; i < n; i++)
            {
                arr_str[i] = Console.ReadLine();
            }

            Radixsort(arr_str);
        }
    }
}