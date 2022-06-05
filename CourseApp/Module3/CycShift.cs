using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CourseApp.Module3
{
    public class CycShift
    {
        public static int Methot_hash(string s, string t)
        {
            if (s == t)
            {
                return 0;
            }

            t = string.Concat(Enumerable.Repeat(t, 2));

            long p = 13;
            long m = 1;
            long q = (long)(Math.Pow(2, 31) - 1);

            long first_hash = 0;
            long second_hash = 0;
            long xt = 1;

            foreach (char i in s.Reverse())
            {
                first_hash = (first_hash + (i * m)) % q;
                m = (m * p) % q;
            }

            m = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                second_hash = (second_hash + (t[i] * m)) % q;
                m = (m * p) % q;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                xt = (xt * p) % q;
            }

            for (int i = 1; i < t.Length - s.Length + 1; i++)
            {
                if (first_hash == second_hash)
                {
                    return i - 1;
                }

                second_hash = p * (second_hash - (t[i - 1] * xt));
                second_hash += t[i + s.Length - 1];
                second_hash = second_hash % q;

                if ((second_hash < 0 && q > 0) || (second_hash > 0 && q < 0))
                {
                    second_hash += q;
                }
            }

            return -1;
        }

        public static void Start()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            int result = Methot_hash(s, t);

            Console.WriteLine(result);
        }
    }
}
