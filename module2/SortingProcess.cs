using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module2
{
    public class SortingProcess
    {
        public static void Main()
        {
            int numbers = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] v = line.Split(' ');
            int[] elements = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                elements[i] = int.Parse(v[i]);
            }

            bool swap = false;
            for (int i = 0; i < elements.Length - 1; i++)
            {
                for (int j = 0; j < elements.Length - i - 1; j++)
                {
                    if (elements[j] > elements[j + 1])
                    {
                        (elements[j], elements[j + 1]) = (elements[j + 1], elements[j]);
                        string conclusion = string.Join(" ", elements);
                        Console.WriteLine(conclusion);
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
