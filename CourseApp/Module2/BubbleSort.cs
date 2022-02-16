using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod()
        {
            int numbers = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string[] arrayStr = str.Split(' ');
            int[] array = new int[numbers];
            bool sTrue = false;
            for (int i = 0; i < numbers; i++)
            {
                array[i] = int.Parse(arrayStr[i]);
            }

            for (int i = 0; i < numbers - 1; i++)
            {
                for (int j = 0; j < numbers - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        Console.WriteLine(string.Join(" ", array));
                        sTrue = true;
                    }
                }
            }

            if (sTrue == false)
            {
                Console.WriteLine(0);
            }
        }
    }
}
