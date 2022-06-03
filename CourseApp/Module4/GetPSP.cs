using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class GetPSP
    {
        private static int getPSPMetod(string str)
        {
            int openNum = 0, closeNum = 0;
            Stack<char> stack = new Stack<char>(str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);
            }

            for (int i = 0; i < str.Length; i++)
            {
                if (closeNum == 0 && stack.Peek() == '(')
                {
                    stack.Pop();
                    openNum++;
                }
                else if (closeNum > 0 && stack.Peek() == '(')
                {
                    stack.Pop();
                    closeNum--;
                }
                else if (closeNum <= 0 && stack.Peek() == ')')
                {
                    stack.Pop();
                    closeNum++;
                }
                else
                {
                    stack.Pop();
                    closeNum++;
                }
            }
            return openNum + closeNum;
        }
        public static void GetPSP_Main()
        {
            string str = Console.ReadLine();
            Console.WriteLine(getPSPMetod(str));
        }
    }
}
