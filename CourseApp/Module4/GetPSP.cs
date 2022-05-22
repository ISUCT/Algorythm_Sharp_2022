using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetPSP
{
    public static class Module4
    {
        public static void Main()
        {
            string p = Console.ReadLine();
            object result = PSP(p);
            Console.Write(result);
        }
        public static int PSP(string p)
        {
            var t = 0;
            var arr = new List<object>();
            foreach (var i in p)
            {
                if (i == '(')
                {
                    arr.Add(arr);
                }
                //if (arr != new List<object>() && arr[-1] == "(")
                //{
                //arr.Remove(-1);
                //}
                //else
                //{
                //t += 1;
                //}
                else if ((i == ')') && (arr.Count > 0))
                {
                    arr.Remove(arr);
                    //if (arr.Count > 0)
                    //{
                    //arr.Remove(arr);
                    //}
                    //else
                    // {
                    //   t += 1;
                    //}
                }
                else if ((i == ')') && (arr.Count <= 0))
                {
                    t += 1;
                }
            }
            return t + arr.Count;
        }
    }
}
