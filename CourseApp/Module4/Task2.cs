using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4
{
    public class Task2
    {
        public static bool Task2Method(int[] valueArr)
        {
            Staack<int> stack = new Staack<int>();
            int count = 1;
            bool flag = true;

            for (int i = 0; i < valueArr.Length; i++)
            {
                int inp = valueArr[i];

                if (stack.Count > 0 && inp > stack.Peek())
                {
                    flag = false;
                    break;
                }

                stack.Push(inp);
                while (stack.Count > 0 && count == stack.Peek())
                {
                    stack.Pop();
                    count++;
                }
            }

            return flag;
        }

        public static void Task2Main()
        {
            int size = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string[] strArr = str.Split(' ');
            int[] valueArr = new int[strArr.Length];
            for (int i = 0; i < valueArr.Length; i++)
            {
                valueArr[i] = int.Parse(strArr[i]);
            }

            bool result = Task2Method(valueArr);
            if (result)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}