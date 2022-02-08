using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSortPair
    {
        public static void BubbleSortMethod()
        {
            int n = int.Parse(Console.ReadLine());
            int[] number = new int[n];
            int[] price = new int[n];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string[] sValues = s.Split(' ');
                number[i] = int.Parse(sValues[0]);
                price[i] = int.Parse(sValues[1]);
            }

            for (int i = 0; i < price.Length - 1; i++)
            {
                for (int j = 0; j < price.Length - i - 1; j++)
                {
                    if (price[j] < price[j + 1])
                    {
                        (price[j], price[j + 1]) = (price[j + 1], price[j]);
                        (number[j], number[j + 1]) = (number[j + 1], number[j]);
                    }
                    else if (price[j] == price[j + 1])
                    {
                        if (number[j] > number[j + 1])
                        {
                            (number[j], number[j + 1]) = (number[j + 1], number[j]);
                            (price[j], price[j + 1]) = (price[j + 1], price[j]);
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", number[i], price[i]);
            }
        }
    }
}
