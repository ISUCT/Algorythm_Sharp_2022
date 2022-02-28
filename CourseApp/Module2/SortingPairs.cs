using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class SortingPairs
    {
        public static void SortingPairsMetod()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arrayID = new int[n];
            int[] arrayPrice = new int[n];
            string[] s = new string[n];

            for (int i = 0; i < s.Length; i++)
            {
                s[i] = Console.ReadLine();
                string[] str = s[i].Split(' ');
                arrayID[i] = int.Parse(str[0]);
                arrayPrice[i] = int.Parse(str[1]);
            }

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j < s.Length - i - 1; j++)
                {
                    if (arrayPrice[j] < arrayPrice[j + 1])
                    {
                        (arrayPrice[j], arrayPrice[j + 1]) = (arrayPrice[j + 1], arrayPrice[j]);
                        (arrayID[j], arrayID[j + 1]) = (arrayID[j + 1], arrayID[j]);
                    }
                    else if (arrayPrice[j] == arrayPrice[j + 1])
                    {
                        if (arrayID[j] > arrayID[j + 1])
                        {
                            (arrayID[j], arrayID[j + 1]) = (arrayID[j + 1], arrayID[j]);
                            (arrayPrice[j], arrayPrice[j + 1]) = (arrayPrice[j + 1], arrayPrice[j]);
                        }
                    }
                }
            }

            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine($"{arrayID[i]} {arrayPrice[i]}");
            }
        }
    }
}
