using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class Cyclic_string
    {
        public static int Cyclic_String_Method(string s)
        {
            int[] z = new int[s.Length];
            z[0] = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                int mid = z[i];

                while (mid > 0 && s[i + 1] != s[mid])
                {
                    mid = z[mid - 1];
                }

                if (s[i + 1] == s[mid])
                {
                    z[i + 1] = mid + 1;
                }
                else
                {
                    z[i + 1] = 0;
                }
            }

            int res = s.Length - z[s.Length - 1];
            return res;
        }

        public static void Cyclic_Main()
        {
            string s = Console.ReadLine();

            int result = Cyclic_String_Method(s);
            Console.WriteLine(result);
        }
    }
}