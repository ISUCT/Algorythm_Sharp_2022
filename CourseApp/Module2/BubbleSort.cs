using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMeth()
        {
            int a = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] array = new int[a];
            for (int i = 0; i < a; i++)
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
    }
}