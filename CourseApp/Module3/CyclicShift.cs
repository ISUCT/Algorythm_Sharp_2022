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
            long p = 4999900 - 12;

            long first_hash = 0;
            long second_hash = 0;
            long xt = 1;

            foreach (char g in s.Reverse())
            {
                first_hash = (first_hash + (g * m)) % p;
                m = (m * q) % p;
            }

            m = 1;

            for (int g = s.Length - 1; g >= 0; g--)
            {
                second_hash = (second_hash + (t[g] * m)) % p;
                m = (m * q) % p;
            }

            for (int g = 0; g < s.Length - 1; g++)
            {
                xt = (xt * q) % p;
            }

            for (int g = 1; g < t.Length - s.Length + 1; g++)
            {
                if (first_hash == second_hash)
                {
                    return g - 1;
                }

                second_hash = q * (second_hash - (t[g - 1] * xt));
                second_hash += t[g + s.Length - 1];
                second_hash = second_hash % p;

                if ((second_hash < 0 && p > 0) || (second_hash > 0 && p < 0))
                {
                    second_hash += p;
                }
            }

            return -1;
        }

        public static void ClassMain()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            int result = Rabin_Karp(s, t);

            Console.WriteLine(result);
        }
    }
}