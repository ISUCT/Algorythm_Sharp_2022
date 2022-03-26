using System;

namespace CourseApp.Module3
{
    public class Line_Period
    {
        public static int[] Prefix_Metod(string s)
        {
            int[] result = new int[s.Length];
            result[0] = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                int j = result[i];

                while (j > 0 && s[i + 1] != s[j])
                {
                    j = result[j - 1];
                }

                if (s[i + 1] == s[j])
                {
                    result[i + 1] = j + 1;
                }
                else
                {
                    result[i + 1] = 0;
                }
            }

            return result;
        }

        public static void Enter()
        {
            string s = Console.ReadLine();

            int[] pref = Prefix_Metod(s);

            int result = s.Length - pref[s.Length - 1];

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