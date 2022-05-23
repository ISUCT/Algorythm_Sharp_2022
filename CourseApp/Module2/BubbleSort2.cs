using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort2
    {
        public static void BubbleSort_2()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string[] sValues = s.Split(' ');
                arr[i, 0] = int.Parse(sValues[0]);
                arr[i, 1] = int.Parse(sValues[1]);
            }

            for (int i = 0; i < (arr.Length / 2) - 1; i++)
            {
                for (int j = 0; j < (arr.Length / 2) - i - 1; j++)
                {
                    if (arr[j, 1] < arr[j + 1, 1])
                    {
                        (arr[j, 1], arr[j + 1, 1]) = (arr[j + 1, 1], arr[j, 1]);
                        (arr[j, 0], arr[j + 1, 0]) = (arr[j + 1, 0], arr[j, 0]);
                    }
                    else if (arr[j, 1] == arr[j + 1, 1])
                    {
                        if (arr[j, 0] > arr[j + 1, 0])
                        {
                            (arr[j, 0], arr[j + 1, 0]) = (arr[j + 1, 0], arr[j, 0]);
                            (arr[j, 1], arr[j + 1, 1]) = (arr[j + 1, 1], arr[j, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", arr[i, 0], arr[i, 1]);
            }
        }
    }
}