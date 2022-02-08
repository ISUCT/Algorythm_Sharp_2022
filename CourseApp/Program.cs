using System;

namespace CourseApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            string[] substr = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(substr[i]);
            }

            BubbleSort.SortArr(arr);
        }
    }
}
