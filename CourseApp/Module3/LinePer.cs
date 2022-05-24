using System;

namespace CourseApp.Module3
{
    public class LinePer
    {
        public static int[] Prefix_function(string s)
        {
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

            return res;
        }

        public static void EnterValues()
        {
            string s = Console.ReadLine();

            int[] prefixs = Prefix_function(s);

            int result = s.Length - prefixs[s.Length - 1];

            if (s.Length % result == 0)
            {
                Console.WriteLine(s.Length / result);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}