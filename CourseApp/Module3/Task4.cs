using System;

namespace CourseApp.Module3
{
    public class Task4
    {
        public static int MainMethod(string str)
        {
            int[] z = new int[str.Length];
            z[0] = 0;

            for (int i = 0; i < str.Length - 1; i++)
            {
                int j = z[i];

                while ((j > 0) && (str[i + 1] != str[j]))
                {
                    j = z[j - 1];
                }

                if (str[i + 1] == str[j])
                {
                    z[i + 1] = j + 1;
                }
                else
                {
                    z[i + 1] = 0;
                }
            }

            int result = str.Length - z[str.Length - 1];
            return result;
        }

        public static void Task4Main()
        {
            Console.WriteLine(MainMethod(Console.ReadLine()));
        }
    }
}