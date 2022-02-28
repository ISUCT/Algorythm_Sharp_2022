using System;

namespace CourseApp.Module2
{
    public class CountingSort
    {
        public static void CountInversion()
        {
            int[] goods = InputParse();
            int[] orders = InputParse();

            int min = int.MaxValue;
            int max = int.MinValue;

            FindBounds(ref orders, ref min, ref max);
            int[] counted = CountElements(ref orders, min, max);
            Compare(ref goods, ref counted);
        }

        private static int[] InputParse()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            return arr;
        }

        private static void FindBounds(ref int[] arr, ref int min, ref int max)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                min = Math.Min(min, arr[i]);
                max = Math.Max(max, arr[i]);
            }
        }

        private static int[] CountElements(ref int[] arr, int min, int max)
        {
            int length = (max - min) + 1;
            int[] add = new int[length];

            for (int i = 0; i < arr.Length; i++)
            {
                add[arr[i] - min]++;
            }

            return add;
        }

        private static void Compare(ref int[] arr, ref int[] add)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < add[i])
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
