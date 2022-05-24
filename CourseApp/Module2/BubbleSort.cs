using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortM()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(sValues[i]);
            }

            bool swaping = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        swaping = true;
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        string resultate = string.Join(" ", array);
                        Console.WriteLine(resultate);
                    }
                }
            }

            if (swaping == false)
            {
                Console.WriteLine(0);
            }
        }
    }
}
