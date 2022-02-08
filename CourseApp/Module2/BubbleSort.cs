using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
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

            bool swap = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        swap = true;
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        string result = string.Join(" ", arr);
                        Console.WriteLine(result);
                    }
                }
            }

            if (swap == false)
            {
                Console.WriteLine(0);
            }
        }
    }
}
