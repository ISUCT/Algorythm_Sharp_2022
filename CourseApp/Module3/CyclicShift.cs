using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module3
{
    public class CyclicShift
    {
        public static void Main()
        {
            string S = Console.ReadLine();
            string T = Console.ReadLine();
            int result = Shift(S, T);
            Console.WriteLine(result);
        }
        public static int Shift(string S, string T)
        {
            T = string.Concat(Enumerable.Repeat(T, 2));
            long a = 13;
            long b = 1;
            long p = 10000000 - 7;
            long one = 0;
            long two = 0;
            long newt = 1;
            if (S == T)
            {
                return 0;
            }
            foreach (char i in S.Reverse())
            {
                one = (one + (i * b)) % p;
               b = (b * a) % p;
            }
            b = 1;
            for (int i = S.Length - 1; i >= 0; i--)
            {
                two = (two + (T[i] * b)) % p;
                b = (b * a) % p;
            }
            for (int i = 0; i < S.Length - 1; i++)
            {
                newt = (newt * a) % p;
            }
            for (int i = 1; i < T.Length - S.Length + 1; i++)
            {
                if (one == two)
                {
                    return i - 1;
                }
                two = a * (two - (T[i - 1] * newt));
                two += T[i + S.Length - 1];
                two = two % p;
                if (((two < 0) && (p > 0)) || ((two > 0) && (p < 0)))
                {
                    two += p;
                }
            }
            return -1;
        }
    }
}