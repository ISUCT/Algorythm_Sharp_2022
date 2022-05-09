namespace CourseApp.Module3
{
    using System;
    using System.Linq;

    public class CyclicShift
    {
        public static int CyclicShiftMethod(string s, string t)
        {
            if (s == t)
            {
                return 0;
            }

            t = string.Concat(Enumerable.Repeat(t, 2));

            long q = 13;
            long m = 1;
            long p = 999993;

            long firstHash = 0;
            long secondHash = 0;
            long xt = 1;

            foreach (char i in s.Reverse())
            {
                firstHash = (firstHash + (i * m)) % p;
                m = (m * q) % p;
            }

            m = 1;

            for (int i = s.Length - 1; i >= 0; i--)
            {
                secondHash = (secondHash + (t[i] * m)) % p;
                m = (m * q) % p;
            }

            for (int i = 0; i < s.Length - 1; i++)
            {
                xt = (xt * q) % p;
            }

            for (int i = 1; i < t.Length - s.Length + 1; i++)
            {
                if (firstHash == secondHash)
                {
                    return i - 1;
                }

                secondHash = q * (secondHash - (t[i - 1] * xt));
                secondHash += t[i + s.Length - 1];
                secondHash = secondHash % p;

                if ((secondHash < 0 && p > 0) || (secondHash > 0 && p < 0))
                {
                    secondHash += p;
                }
            }

            return -1;
        }

        public static void EnterValues()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            int result = CyclicShiftMethod(s, t);

            Console.WriteLine(result);
        }
    }
}
