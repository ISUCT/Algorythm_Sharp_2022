using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class CyclicShift
    {
        private static int x = 26;
        private static int max = 10000000;
        public static int Cyclic(string S, string T)
        {
            int xt = 1;
            int hS = Hash(S);
            int hT = Hash(T);
            if (hT == hS) return 0;
            else if (S.Length == 1) return -1;
            else
            {
                T = S + S;
                for (int i = 0; i < S.Length; i++)
                {
                    xt = (xt * x) % max;
                }
                for (int i = 0; i < S.Length; i++)
                {
                    if (hT == hS)
                    {
                        return i;
                    }
                    hS = ((x * hS) - (S[i] * xt) + T[i + S.Length]) % max;
                    hS = (hS + max) % max;
                }
            }
            return -1;

        }
        private static int Hash(string str)
        {
            int hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hash = ((hash * x) + str[i]) % max;
            }
            return hash;
        }

        public static void CyclicShift_Main()
        {
            string S = Console.ReadLine();
            string T = Console.ReadLine();
            S = ReverseMetod(S);
            T = ReverseMetod(T);
            Console.WriteLine(Cyclic(S, T));
        }

        private static string ReverseMetod(string str)
        {
            char[] arrStr = str.ToCharArray();
            Array.Reverse(arrStr);
            return new string(arrStr);
        }
    }
}
