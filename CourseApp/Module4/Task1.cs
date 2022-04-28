using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4
{
    public class Task1
    {
        public static void Method(string str)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);
            }

            int open = 0;
            int close = 0;
            while (stack.Count > 0)
            {
                if (close == 0 && stack.Peek() == '(')
                {
                    open++;
                    stack.Pop();
                }
                else if (close > 0 && stack.Peek() == '(')
                {
                    close--;
                    stack.Pop();
                }
                else if (stack.Peek() == ')')
                {
                    close++;
                    stack.Pop();
                }
                else if (close <= 0 && stack.Peek() == ')')
                {
                    close++;
                    stack.Pop();
                }
            }

            Console.WriteLine(open + close);
        }

        public static void Task1Main()
        {
            string str = Console.ReadLine();
            Method(str);
        }
    }
}
