using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module3
{
    public class RabinCarp
    {
        public static int CalculateHash(string s, int x, int p)
        {
            ulong hash = 0;
            for (int i = 0; i < s.Length; i++)
            {
                hash += (ulong)(s[i] - 'A') * (ulong)Math.Pow(x, s.Length - 1 - i);
            }

            return (int)(hash % (ulong)p);
        }

        public static int SlidingHash(string s, char appended, int hash, int x, int p)
        {
            var newHash = (ulong)(hash * x) - ((s[0] - 'A') * Math.Pow(x, s.Length));
            newHash += appended - 'A';
            newHash %= p;
            newHash = (newHash + p) % p;
            return (int)newHash;
        }

        public static void RabinCarpMethod()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            int x = 257;
            int p = 3571;
            var hash_t = CalculateHash(t, x, p);
            var hash_s = CalculateHash(s.Substring(0, t.Length), x, p);
            var res = new List<int>();
            for (int i = 0; i <= s.Length - t.Length; i++)
            {
                if (hash_t == hash_s)
                {
                    var found = true;
                    for (int j = 0; j < t.Length; j++)
                    {
                        if (t[j] != s[i + j])
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
                    {
                        res.Add(i);
                    }
                }

                if ((i + t.Length) < s.Length)
                {
                    hash_s = SlidingHash(s.Substring(i, t.Length), s[i + t.Length], hash_s, x, p);
                }
            }

            string result = string.Join(" ", res);
            Console.WriteLine(result);
        }
    }
}
