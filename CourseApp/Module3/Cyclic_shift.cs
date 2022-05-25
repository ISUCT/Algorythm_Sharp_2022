using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class Cyclic_shift
    {
        public static int Cyclic_shift_Method(string s, string t, long p, long x)
        {
            long m = 1;
            long xt = 1;
            long firstHash = 0;
            long secondHash = 0;

            if (t == s)
            {
                return 0;
            }

            t = string.Concat(Enumerable.Repeat(t, 2));

            foreach (char i in s.Reverse())
            {
                firstHash = (firstHash + (i * m)) % p;
                m = (m * x) % p;
            }

            m = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                secondHash = (secondHash + (t[i] * m)) % p;
                m = (m * x) % p;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                xt = (xt * x) % p;
            }

            for (int i = 1; i < t.Length - s.Length + 1; i++)
            {
                if (firstHash == secondHash)
                {
                    return i - 1;
                }

                secondHash = ((x * (secondHash - (t[i - 1] * xt))) + t[i + s.Length - 1]) % p;

                if ((secondHash < 0 && p > 0) || (secondHash > 0 && p < 0))
                {
                    secondHash += p;
                }
            }

            return -1;
        }

        public static void Cyclic_shift_Main()
        {
            string ht = Console.ReadLine();
            string hs = Console.ReadLine();

            long p = 1000000000;
            long x = 13;

            int res = Cyclic_shift_Method(ht, hs, p, x);
            Console.WriteLine(res);
        }
    }
}
