using System;
using System.Linq;

namespace CourseApp.Module3
{
    public class CyclicShift
    {
        public static int Rabin_Karp(string s, string t)
        {
            if (s == t)
            {
                return 0;
            }

            t = string.Concat(Enumerable.Repeat(t, 2));

            long q = 13;
            long m = 1;
            long p = 10000000 - 7;

            long first_hash = 0;
            long second_hash = 0;
            long xt = 1;

            foreach (char i in s.Reverse())
            {
                first_hash = (first_hash + (i * m)) % p;
                m = (m * q) % p;
            }

            m = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                second_hash = (second_hash + (t[i] * m)) % p;
                m = (m * q) % p;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                xt = (xt * q) % p;
            }

            for (int i = 1; i < t.Length - s.Length + 1; i++)
            {
                if (first_hash == second_hash)
                {
                    return i - 1;
                }

                second_hash = q * (second_hash - (t[i - 1] * xt));
                second_hash += t[i + s.Length - 1];
                second_hash = second_hash % p;

                if ((second_hash < 0 && p > 0) || (second_hash > 0 && p < 0))
                {
                    second_hash += p;
                }
            }

            return -1;
        }

        public static void EnterValues()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            int result = Rabin_Karp(s, t);

            Console.WriteLine(result);
        }
    }
}