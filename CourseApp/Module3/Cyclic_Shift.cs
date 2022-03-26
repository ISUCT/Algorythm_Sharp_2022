using System;
using System.Linq;

namespace CourseApp.Module3
{
    public class Cyclic_Shift
    {
        public static int Metod_RK(string s, string a)
        {
            if (s == a)
            {
                return 0;
            }

            a = string.Concat(Enumerable.Repeat(a, 2));

            long z = 13;
            long x = 1;
            long p = 7777777;

            long fir_h = 0;
            long sec_h = 0;
            long xa = 1;

            foreach (char i in s.Reverse())
            {
                fir_h = (fir_h + (i * x)) % p;
                x = (x * z) % p;
            }

            x = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                sec_h = (sec_h + (a[i] * x)) % p;
                x = (x * z) % p;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                xa = (xa * z) % p;
            }

            for (int i = 1; i < a.Length - s.Length + 1; i++)
            {
                if (fir_h == sec_h)
                {
                    return i - 1;
                }

                sec_h = z * (sec_h - (a[i - 1] * xa));
                sec_h += a[i + s.Length - 1];
                sec_h = sec_h % p;

                if ((sec_h < 0 && p > 0) || (sec_h > 0 && p < 0))
                {
                    sec_h += p;
                }
            }

            return -1;
        }

        public static void Enter()
        {
            string s = Console.ReadLine();
            string a = Console.ReadLine();

            int result = Metod_RK(s, a);

            Console.WriteLine(result);
        }
    }
}