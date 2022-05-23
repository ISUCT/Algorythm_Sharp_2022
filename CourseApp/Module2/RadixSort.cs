using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static string[] Sort(string[] mas_string, int phase, int length)
        {
            ulong x;
            List<string>[] mas = new List<string>[10];
            for (int i = 0; i < 10; i++)
            {
                mas[i] = new List<string>();
            }

            for (int j = 0; j < mas_string.Length; j++)
            {
                int s = int.Parse(mas_string[j].Substring(length - phase, 1));
                mas[s].Add(mas_string[j]);
            }

            for (x = 0; x < 10; x++)
            {
                if (mas[x].Count == 0)
                {
                    Console.WriteLine("Bucket " + x + ": empty");
                }
                else
                {
                    Console.WriteLine("Bucket " + x + ": {0}", string.Join(", ", mas[x]));
                }
            }

            int a = 0;

            for (x = 0; x < 10; x++)
            {
                for (int j = 0; j < mas[x].Count; j++)
                {
                    mas_string[a] = mas[x][j];
                    a++;
                }
            }

            return mas_string;
        }

        public static void RadixSortMethod(string[] mas_string, ulong value)
        {
            int phase = 1;
            int rank = mas_string[0].Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", mas_string));

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(g => rank - 1 + (g * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", phase);
                mas_string = Sort(mas_string, phase, rank);
                phase++;
            }

            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.Write("{0}", string.Join(", ", mas_string));
        }

        public static void Enter()
        {
            ulong y = ulong.Parse(Console.ReadLine());
            string[] arr_string = new string[y];
            for (ulong i = 0; i < y; i++)
            {
                arr_string[i] = Console.ReadLine();
            }

            RadixSortMethod(arr_string, y);
        }
    }
}