using System;

namespace CourseApp
{
    internal static class BubbleSort
    {
        public static void SortArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        Swap(ref arr[j], ref arr[j + 1]);
                        ShowArray(arr);
                    }
                }
            }
        }

        private static void Swap(ref int left, ref int right)
        {
            int temp = right;
            right = left;
            left = temp;
        }

        private static void ShowArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
