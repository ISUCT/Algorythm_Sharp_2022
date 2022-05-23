using System;

namespace CourseApp.Module3
{
    public class String_Search
    {
        public static long Get(string s, int z, int y, int x)
        {
            long res = 0;
            for (int i = 0; i < z; i++)
            {
                res = ((res * x) + s[i]) % y;
            }

            return res;
        }

        public static void Metod_Rabin_Karp(string s, string a, int y, int x)
        {
            long ha = Get(a, a.Length, y, x);

            long hs = Get(s, a.Length, y, x);

            long xt = 1;

            for (int i = 0; i < a.Length; i++)
            {
                xt = (xt * x) % y;
            }

            for (int i = 0; i <= s.Length - a.Length; i++)
            {
                if (ha == hs)
                {
                    Console.Write("{0} ", i);
                }

                if (i + a.Length < s.Length)
                {
                    hs = ((hs * x) - (s[i] * xt) + s[i + a.Length]) % y;
                    hs = (hs + y) % y;
                }
            }
        }

        public static void Enter()
        {
            string s = Console.ReadLine();
            string a = Console.ReadLine();

            int y = 77777;
            int x = 26;

            Metod_Rabin_Karp(s, a, y, x);
        }
    }
}