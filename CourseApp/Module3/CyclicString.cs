using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class CyclicString
    {
        private static int CyclicStringMetod(string str)
        {
            int[] res = new int[str.Length];
            res[0] = 0;
            for (int i = 0; i < str.Length - 1; i++)
            {
                int j = res[i];
                while (j > 0 && str[i + 1] != str[j])
                {
                    j = res[j - 1];
                }
                if (str[i + 1] == str[j]) res[i + 1] = j + 1;
                else res[i + 1] = 0;
            }
            return str.Length - res[str.Length - 1];
        }
        public static void CyclicString_Main()
        {
            string str = Console.ReadLine();

            Console.WriteLine(CyclicStringMetod(str));
        }
    }
}
