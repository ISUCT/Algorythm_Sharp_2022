﻿using System;

namespace CourseApp.Module3
{
    public class CircularStr
    {
        public static int[] Prefix_function(string b)
        {
            int[] res = new int[b.Length];
            res[0] = 0;

            for (int i = 0; i < b.Length - 1; i++)
            {
                int j = res[i];

                while (j > 0 && b[i + 1] != b[j])
                {
                    j = res[j - 1];
                }

                if (b[i + 1] == b[j])
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
            string b = Console.ReadLine();

            int[] prefixs = Prefix_function(b);

            int result = b.Length - prefixs[b.Length - 1];

            Console.WriteLine(result);
        }
    }
}