using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*RabinCarp*/
namespace CourseApp.Module3
{
    public class SubstringSearch
    {
        public static ulong CalculateHash(string inp, ulong x, ulong p)
        {
            ulong hash = 0;
            for (int i = 0; i < inp.Length; i++)
            {
                hash = ((hash * x) + (ulong)(inp[i] - 'A')) % p;
            }

            return hash;
        }

        public static ulong SlidingHash(string inp, char appended, ulong hash, ulong x, ulong p, ulong multiplier)
        {
            ulong newHash = hash + p;
            newHash -= (multiplier * (ulong)(inp[0] - 'A')) % p;
            newHash *= x;
            newHash += (ulong)(appended - 'A');
            newHash %= p;

            return newHash;
        }

        public static void SubstringSearch_Main()
        {
            string s = Console.ReadLine();
            string t = Console.ReadLine();
            ulong x = 257;
            ulong p = 3571;

            ulong multiplier = 1;
            for (int i = 1; i < t.Length; i++)
            {
                multiplier *= x;
                multiplier %= p;
            }

            ulong hash_t = 0;
            ulong hash_s = 0;
            for (int i = 0; i < t.Length; i++)
            {
                hash_t = ((hash_t * x) + (ulong)(t[i] - 'A')) % p;
                hash_s = ((hash_s * x) + (ulong)(s[i] - 'A')) % p;
            }

            var res = new List<int>();
            for (int i = 0; i <= (s.Length - t.Length); i++)
            {
                if (hash_s == hash_t && t == s.Substring(i, t.Length))
                {
                    res.Add(i);
                }

                if ((i + t.Length) < s.Length)
                {
                    hash_s += p;
                    hash_s -= (multiplier * (ulong)(s[i] - 'A')) % p;
                    hash_s *= x;
                    hash_s += (ulong)(s[i + t.Length] - 'A');
                    hash_s %= p;
                }
            }

            string result = string.Join(" ", res);
            Console.WriteLine(result);
        }
    }
}
