using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static string[] CountSort(string[] arr_str, int phase, int lenght)
        {
            ulong i;
            List<string>[] arr_list = new List<string>[10];
            for (int g = 0; g < 10; g++)
            {
                arr_list[g] = new List<string>();
            }

            for (int j = 0; j < arr_str.Length; j++)
            {
                int k = int.Parse(arr_str[j].Substring(lenght - phase, 1));
                arr_list[k].Add(arr_str[j]);
            }

            for (i = 0; i < 10; i++)
            {
                if (arr_list[i].Count == 0)
                {
                    Console.WriteLine("Bucket " + i + ": empty");
                }
                else
                {
                    Console.WriteLine("Bucket " + i + ": {0}", string.Join(", ", arr_list[i]));
                }
            }

            int l = 0;

            for (i = 0; i < 10; i++)
            {
                for (int j = 0; j < arr_list[i].Count; j++)
                {
                    arr_str[l] = arr_list[i][j];
                    l++;
                }
            }

            return arr_str;
        }

        public static void Radixsort(string[] arr_str, ulong n)
        {
            int numb_phaze = 1;
            int rank = arr_str[0].Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", arr_str));

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x_1 => rank - 1 + (x_1 * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", numb_phaze);
                arr_str = CountSort(arr_str, numb_phaze, rank);
                numb_phaze++;
            }

            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.Write("{0}", string.Join(", ", arr_str));
        }

        public static void ClassMain()
        {
            ulong n = ulong.Parse(Console.ReadLine());
            string[] arr_str = new string[n];
            for (ulong i = 0; i < n; i++)
            {
                arr_str[i] = Console.ReadLine();
            }

            Radixsort(arr_str, n);
        }
    }
}
