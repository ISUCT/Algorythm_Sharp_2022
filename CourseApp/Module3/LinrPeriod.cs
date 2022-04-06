using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module3
{
    public class LinrPeriod
    {
        public static void LinePeriodSearch()
        {
            string s = Console.ReadLine();
            string simbol = s;
            for (int i = 0; i < s.Length / 2; i++)
            {
                if (s.Substring(0, i + 1) == s.Substring(i + 1, i + 1))
                {
                    simbol = s.Substring(0, i + 1);
                    break;
                }
            }

            int count = s.Length / simbol.Length;
            Console.WriteLine(count);
        }
    }
}
