using System;

namespace CourseApp.Module3
{
    public class Rabin_karp
    {
        public static void Rabin_karp_Method()
        {
            string s = Console.ReadLine();
            int[] res = new int[s.Length];
            res[0] = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                int j = res[i];

                while (j > 0 && s[i + 1] != s[j])
                {
                    j = res[j - 1];
                }

                if (s[i + 1] == s[j])
                {
                    res[i + 1] = j + 1;
                }
                else
                {
                    res[i + 1] = 0;
                }
            }

            int finish = s.Length - res[s.Length - 1];

            if (s.Length % finish == 0)
            {
                Console.WriteLine(s.Length / finish);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}
