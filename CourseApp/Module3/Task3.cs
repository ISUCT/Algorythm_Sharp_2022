using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class Task3
    {
        public static void Task3Main()
        {
            string str = Console.ReadLine();
            int[] value = new int[str.Length];
            value[0] = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                int j = value[i];

                while ((j > 0) && (str[i + 1] != str[j]))
                {
                    j = value[j - 1];
                }

                if (str[i + 1] == str[j])
                {
                    value[i + 1] = j + 1;
                }
                else
                {
                    value[i + 1] = 0;
                }
            }

            int result = str.Length - value[str.Length - 1];

            if (str.Length % result == 0)
            {
                Console.WriteLine(str.Length / result);
            }
            else
            {
                Console.WriteLine("1");
            }
        }
    }
}
