using System;
using System.Linq;

namespace CourseApp.Module3
{
    public class CyclicShift
    {
        public static int Rabin_Karp(string v, string n)
        {
            if (v == n)
            {
                return 0;
            }

            n = string.Concat(Enumerable.Repeat(n, 2));

            long w = 13;
            long b = 1;
            long t = 100000000;

            long first_hash = 0;
            long second_hash = 0;
            long xt = 1;

            foreach (char i in v.Reverse())
            {
                first_hash = (first_hash + (i * b)) % t;
                b = (b * w) % t;
            }

            b = 1;

            for (int i = v.Length - 1; i >= 0; i--)
            {
                second_hash = (second_hash + (n[i] * b)) % t;
                b = (b * w) % t;
            }

            for (int i = 0; i < v.Length - 1; i++)
            {
                xt = (xt * w) % t;
            }

            for (int i = 1; i < n.Length - v.Length + 1; i++)
            {
                if (first_hash == second_hash)
                {
                    return i - 1;
                }

                second_hash = w * (second_hash - (n[i - 1] * xt));
                second_hash += n[i + v.Length - 1];
                second_hash = second_hash % t;

                if ((second_hash < 0 && t > 0) || (second_hash > 0 && t < 0))
                {
                    second_hash += t;
                }
            }

            return -1;
        }

        public static void EnterValues()
        {
            string r = Console.ReadLine();
            string q = Console.ReadLine();

            int result = Rabin_Karp(r, q);

            Console.WriteLine(result);
        }
    }
}