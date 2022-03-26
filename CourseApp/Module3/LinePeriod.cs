using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module3
{
    public class LinePeriod
    {
        public static void Main()
        {
            string n = Console.ReadLine();
            int[] s = Period(n);
            int conclusion = n.Length - s[n.Length - 1];
            if (n.Length % conclusion == 0)
            {
                Console.WriteLine(n.Length / conclusion);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
        public static int[] Period(string s)
        {
            int[] a = new int[s.Length];
            a[0] = 0;
            int i;
            int j;
            for (i = 0; i < s.Length - 1; i++)
            {
                j = a[i];

                while ((j > 0) && (s[i + 1] != s[j]))
                {
                    j = a[j - 1];
                }

                if (s[i + 1] == s[j])
                {
                    a[i + 1] = j + 1;
                }
                else
                {
                    a[i + 1] = 0;
                }
            }

            return a;
        }
    }
}

