using System;

namespace CourseApp.Module2
{
    public static class BubbleSort
    {
        private static bool swapped = false;

        public static void BubbleSortMethod()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
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

        private static void Swap(ref int left, ref int right)
        {
            int temp = right;
            right = left;
            left = temp;
        }
    }
}
