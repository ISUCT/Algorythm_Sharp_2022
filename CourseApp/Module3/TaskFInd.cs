using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class TaskFInd
    {
        public static long Get_hash(string w, int b, int q, int t)
        {
            long res = 0;
            for (int i = 0; i < b; i++)
            {
                res = ((res * t) + w[i]) % q;
            }

            return res;
        }

        public static void Rabin_karp(string e, string k, int o, int v)
        {
            long ht = Get_hash(k, k.Length, o, v);

            long hs = Get_hash(e, k.Length, o, v);

            long xt = 1;

            for (int i = 0; i < k.Length; i++)
            {
                xt = (xt * v) % o;
            }

            for (int i = 0; i <= e.Length - k.Length; i++)
            {
                if (ht == hs)
                {
                    Console.Write("{0} ", i);
                }

                if (i + k.Length < e.Length)
                {
                    hs = ((hs * v) - (e[i] * xt) + e[i + k.Length]) % o;
                    hs = (hs + o) % o;
                }
            }
        }

        public static void EnterValues()
        {
            string e = Console.ReadLine();
            string k = Console.ReadLine();

            int o = 67953405;
            int v = 26;

            Rabin_karp(e, k, o, v);
        }
    }
}