﻿using System;

namespace CourseApp.Module3
{
    public class PeriodStr
    {
        public static int[] PrefixFunc(string k)
        {
            int[] res = new int[k.Length];
            res[0] = 0;

            for (int i = 0; i < k.Length - 1; i++)
            {
                int j = res[i];

                while (j > 0 && k[i + 1] != k[j])
                {
                    j = res[j - 1];
                }

                if (k[i + 1] == k[j])
                {
                    res[i + 1] = j + 1;
                }
                else
                {
                    res[i + 1] = 0;
                }
            }

            return res;
        }

        public static void EnterVal()
        {
            string k = Console.ReadLine();

            int[] prefixs = PrefixFunc(k);

            int result = k.Length - prefixs[k.Length - 1];

            if (k.Length % result == 0)
            {
                Console.WriteLine(k.Length / result);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}