using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class BitwiseSorting
    {
        private static void BitwiseSortingMetod(string[] arrStr)
        {
            Console.WriteLine("Initial array:");
            Console.WriteLine(string.Join(", ", arrStr));
            int phase = 1;
            int round = arrStr[0].Length;

            for (int i = round - 1; i >= 0; i--)
            {
                Console.WriteLine("**********");
                Console.WriteLine($"Phase {phase}");
                Sort(arrStr, phase, round);
                phase++;
            }
            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.WriteLine(String.Join(", ", arrStr));

        }

        private static string[] Sort(string[] arrStr, int phase, int round)
        {
            List<string>[] arrSorted = new List<string>[10];
            for (int i = 0; i < 10; i++)
            {
                arrSorted[i] = new List<string>();
            }

            for (int j = 0; j < arrStr.Length; j++)
            {
                int x = int.Parse(arrStr[j].Substring(round - phase, 1));
                arrSorted[x].Add(arrStr[j]);
            }

            for (int i = 0; i < 10; i++)
            {
                if (arrSorted[i].Count == 0)
                {
                    Console.WriteLine($"Bucket {i}: empty");
                }
                else
                {
                    Console.WriteLine($"Bucket {i}: " + string.Join(", ", arrSorted[i]));
                }
            }
            int p = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < arrSorted[i].Count; j++)
                {
                    arrStr[p] = arrSorted[i][j];
                    p++;
                }
            }

            return arrStr;
        }
        public static void BitwiseSorting_Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrStr = new string[n];
            for (int i = 0; i < arrStr.Length; i++)
            {
                arrStr[i] = Console.ReadLine();
            }
            BitwiseSortingMetod(arrStr);
        }
    }
}
