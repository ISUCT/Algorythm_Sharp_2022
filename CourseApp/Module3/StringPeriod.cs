using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class StringPeriod
    {
        private static int StringPeriodMetod(string str)
        {
            int count = 0;
            int[] arrStr = new int[str.Length];
            for (int i = 0; i < str.Length - 1; i++)
            {
                int j = arrStr[i];
                while (j > 0 && str[i + 1] != str[j])
                {
                    j = arrStr[j - 1];
                }
                if (str[i + 1] == str[j]) arrStr[i + 1] = j + 1;
                else arrStr[i + 1] = 0;
            }
            count = str.Length - arrStr[str.Length - 1];

            if (str.Length % count == 0)
            {
                return str.Length / count;
            }
            else
            {
                return 1;
            }
        }
        public static void StringPeriod_Main()
        {
            string str = Console.ReadLine();
            Console.WriteLine(StringPeriodMetod(str));
        }
    }
}
