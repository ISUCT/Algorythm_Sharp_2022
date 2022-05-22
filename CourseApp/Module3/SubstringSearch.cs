using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module3
{
    public class SubstringSearch
    {
        public static void Main()
        {
            string one = Console.ReadLine();
            string two = Console.ReadLine();
            int a = 1000000000 + 7;
            int n = 26;
            SSearch(one, two, a, n);
        }
        public static long Search(string a, int c, int s, int n)
        {
            long r = 0;
            for (int i = 0; i < c; i++)
            {
                r = ((r * n) + a[i]) % s;
            }
            return r;
        }

        public static void SSearch(string a, string c, int s, int n)
        {
            long newa = Search(a, c.Length, s, n);
            long newc = Search(c, c.Length, s, n);
            long o = 1;
            for (int i = 0; i < c.Length; i++)
            {
                o = (o * n) % s;
            }
            for (int i = 0; i <= a.Length - c.Length; i++)
            {
                if (newc == newa)
                {
                    Console.Write("{0} ", i);
                }
                if (i + c.Length < a.Length)
                {
                    newa = ((newa * n) - (a[i] * o) + a[i + c.Length]) % s;
                    newa = (newa + s) % s;
                }
               // if (newc == newa)
               // {
               //     Console.Write("{0} ", i);
               // }
            }
        }
    }
}