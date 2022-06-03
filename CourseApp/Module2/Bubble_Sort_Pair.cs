using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class Bubble_Sort_Pair
    {
        public static void Bubble_Sort_Method()
        {
            int numberOfElements = int.Parse(Console.ReadLine());
            string[][] array = new string[numberOfElements][];
            string[] value = Console.ReadLine().Split(' ');
            array[0] = value;
            for (int i = 1; i < numberOfElements;  i++)
            {
                string[] temp = Console.ReadLine().Split(' ');
                array[i] = temp;

                for (int j = 0; j < i; j++)
                {
                    if (int.Parse(array[j][1]) < int.Parse(array[i][1]))
                    {
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                    else if (int.Parse(array[j][1]) == int.Parse(array[i][1]))
                    {
                        if (int.Parse(array[j][0]) > int.Parse(array[i][0]))
                        {
                            (array[j], array[i]) = (array[i], array[j]);
                        }
                    }
                }
            }

            for (int i = 0; i < numberOfElements; i++)
            {
                Console.WriteLine(array[i][0] + " " + array[i][1]);
            }
        }
    }
}
