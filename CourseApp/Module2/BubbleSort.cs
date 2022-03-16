using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class Bubble_Sort
    {
        public static void Bubble_Sort_Method()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(sValues[i]);
            }

            bool swap = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        string result = string.Join(" ", array);
                        Console.WriteLine(result);
                        swap = true;
                    }
                }
            }

            if (swap == false)
            {
                Console.WriteLine(0);
            }
        }
        public static void Main()
        {
            Bubble_Sort_Method();
        }
    }
}