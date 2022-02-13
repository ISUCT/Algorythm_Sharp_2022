using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod()
        {
            int zero_test = 0;
            int c_elems = Convert.ToInt32(Console.ReadLine());
            int[] mas_elems = new int[c_elems];
            string elem_mas = Console.ReadLine();
            string[] elems_mas = elem_mas.Split(' ');
            Console.WriteLine();

            for (int i = 0; i < mas_elems.Length; i++)
            {
                mas_elems[i] = int.Parse(elems_mas[i]);
            }

            for (int i = 1; i < mas_elems.Length; i++)
            {
                for (int j = 0; j < mas_elems.Length - i; j++)
                {
                    if (mas_elems[j] > mas_elems[j + 1])
                    {
                        (mas_elems[j], mas_elems[j + 1]) = (mas_elems[j + 1], mas_elems[j]);
                        zero_test++;
                        string result = string.Join(" ", mas_elems);
                        Console.WriteLine(result);
                    }
                }
            }

            if (zero_test == 0)
            {
                Console.WriteLine(zero_test);
            }
        }
    }
}
