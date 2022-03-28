using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseApp.Module2
{
    public static class RadixSort
    {
        public static string[] CountSort(string[] arrString, int phase, int len)
        {
            ulong i;
            List<string>[] arrayList = new List<string>[10];
            for (int g = 0; g < 10; g++)
            {
                arrayList[g] = new List<string>();
            }

            for (int j = 0; j < arrString.Length; j++)
            {
                int k = int.Parse(arrString[j].Substring(len - phase, 1));
                arrayList[k].Add(arrString[j]);
            }

            for (i = 0; i < 10; i++)
            {
                if (arrayList[i].Count == 0)
                {
                    Console.WriteLine("Bucket " + i + ": empty");
                }
                else
                {
                    Console.WriteLine("Bucket " + i + ": {0}", string.Join(", ", arrayList[i]));
                }
            }

            int l = 0;

            for (i = 0; i < 10; i++)
            {
                for (int j = 0; j < arrayList[i].Count; j++)
                {
                    arrString[l] = arrayList[i][j];
                    l++;
                }
            }

            return arrString;
        }

        public static void DoRadixSort(string[] arrString)
        {
            int numbPhaze = 1;
            int rank = arrString[0].Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", arrString));

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x1 => rank - 1 + (x1 * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", numbPhaze);
                arrString = CountSort(arrString, numbPhaze, rank);
                numbPhaze++;
            }

            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.Write("{0}", string.Join(", ", arrString));
        }

        public static void RadixSortMethod()
        {
            ulong n = ulong.Parse(Console.ReadLine());
            string[] arrString = new string[n];
            for (ulong i = 0; i < n; i++)
            {
                arrString[i] = Console.ReadLine();
            }

            DoRadixSort(arrString);
        }
    }
}