namespace CourseApp.Module3
{
    using System;

    public static class RabinCarp
    {
        public static void RabinCarpMethod()
        {
            const int x = 26;
            const int p = 1000000007;

            string original = Console.ReadLine();
            string pattern = Console.ReadLine();

            long originalHash = CalculateHash(original, pattern.Length, x, p);
            long patternHash = CalculateHash(pattern, pattern.Length, x, p);

            long xt = 1;
            for (int i = 0; i < pattern.Length; i++)
            {
                xt = (xt * x) % p;
            }

            for (int i = 0; i <= original.Length - pattern.Length; i++)
            {
                if (patternHash == originalHash)
                {
                    Console.Write(i + " ");
                }

                if (i + pattern.Length < original.Length)
                {
                    originalHash = ((originalHash * x) - (original[i] * xt) + original[i + pattern.Length]) % p;
                    originalHash = (originalHash + p) % p;
                }
            }
        }

        private static long CalculateHash(string inp, int stringLength, int x, int p)
        {
            long res = 0;
            for (int i = 0; i < stringLength; i++)
            {
                res = ((res * x) + inp[i]) % p;
            }

            return res;
        }
    }
}
