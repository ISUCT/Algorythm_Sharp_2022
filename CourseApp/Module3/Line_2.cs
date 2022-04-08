using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    using System;

    public static class Line_2
    {
        public static void RabinCarpMethod()
        {
            const int k = 31;
            const int mod = 1000000007;

            string original = Console.ReadLine();
            string pattern = Console.ReadLine();

            long originalHash = HashFunction(original, pattern.Length, k, mod);
            long patternHash = HashFunction(pattern, pattern.Length, k, mod);

            long m = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                m = (m * k) % mod;
            }

            for (int i = 0; i <= original.Length - pattern.Length; i++)
            {
                if (patternHash == originalHash)
                {
                    Console.Write(i + " ");
                }

                if (i + pattern.Length < original.Length)
                {
                    originalHash = ((originalHash * k) - (original[i] * m) + original[i + pattern.Length]) % mod;
                    originalHash = (originalHash + mod) % mod;
                }
            }
        }

        private static long HashFunction(string inp, int stringLength, int x, int p)
        {
            long h = 0;
            for (int i = 0; i < stringLength; i++)
            {
                h = ((h * x) + inp[i]) % p;
            }

            return h;
        }
    }
}