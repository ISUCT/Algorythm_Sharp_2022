using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSortP
    {
        public static void BubbleSortM()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] mass = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string[] sValues = s.Split(' ');
                mass[i, 0] = int.Parse(sValues[0]);
                mass[i, 1] = int.Parse(sValues[1]);
            }

            for (int i = 0; i < (mass.Length / 2) - 1; i++)
            {
                for (int j = 0; j < (mass.Length / 2) - i - 1; j++)
                {
                    if (mass[j, 1] < mass[j + 1, 1])
                    {
                        (mass[j, 1], mass[j + 1, 1]) = (mass[j + 1, 1], mass[j, 1]);
                        (mass[j, 0], mass[j + 1, 0]) = (mass[j + 1, 0], mass[j, 0]);
                    }
                    else if (mass[j, 1] == mass[j + 1, 1])
                    {
                        if (mass[j, 0] > mass[j + 1, 0])
                        {
                            (mass[j, 0], mass[j + 1, 0]) = (mass[j + 1, 0], mass[j, 0]);
                            (mass[j, 1], mass[j + 1, 1]) = (mass[j + 1, 1], mass[j, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", mass[i, 0], mass[i, 1]);
            }
        }
    }
}