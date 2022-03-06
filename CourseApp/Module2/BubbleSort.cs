using System;

namespace CourseApp.Module2
{
    public static class BubbleSort
    {
        private static bool swapped = false;

        public static void SortOff()
        {
            int x = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] arr = new int[x];
            for (int d = 0; d < x; d++)
            {
                arr[d] = int.Parse(sValues[d]);
            }

            for (int r = 0; r < arr.Length; r++)
            {
                for (int j = 0; j < arr.Length - r - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        string result = string.Join(" ", arr);
                        Console.WriteLine(result);
                        swapped = true;
                    }
                }
            }

            if (swapped == false)
            {
                Console.WriteLine(0);
            }
        }

        private static void Swap(ref int left, ref int r)
        {
            int t = r;
            r = left;
            left = t;
        }
    }
}