using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class SortingPairs
    {
        public static void BubbleSortMeth()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] pair = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                string a = Console.ReadLine();
                string[] sValues = a.Split(' ');
                pair[i, 0] = int.Parse(sValues[0]);
                pair[i, 1] = int.Parse(sValues[1]);
            }

            for (int i = 0; i < (pair.Length / 2) - 1; i++)
            {
                for (int j = 0; j < (pair.Length / 2) - i - 1; j++)
                {
                    if (pair[j, 1] < pair[j + 1, 1])
                    {
                        (pair[j, 1], pair[j + 1, 1]) = (pair[j + 1, 1], pair[j, 1]);
                        (pair[j, 0], pair[j + 1, 0]) = (pair[j + 1, 0], pair[j, 0]);
                    }
                    else if (pair[j, 1] == pair[j + 1, 1])
                    {
                        if (pair[j, 0] > pair[j + 1, 0])
                        {
                            (pair[j, 0], pair[j + 1, 0]) = (pair[j + 1, 0], pair[j, 0]);
                            (pair[j, 1], pair[j + 1, 1]) = (pair[j + 1, 1], pair[j, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", pair[i, 0], pair[i, 1]);
            }
        }
    }
}
