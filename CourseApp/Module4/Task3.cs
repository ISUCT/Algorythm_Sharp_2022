using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class Task3
    {
        public class Program
        {
            public static void MainMethod(int[] data)
            {
                int[] resultArr = new int[data.Length];
                ListStack<int> stack = new ListStack<int>();
                for (int i = data.Length - 1; i >= 0; i--)
                {
                    while (stack.Count > 0 && data[stack.Peek()] >= data[i])
                    {
                        stack.Pop();
                    }

                    if (stack.Count == 0)
                    {
                        resultArr[i] = -1;
                    }
                    else
                    {
                        resultArr[i] = stack.Peek();
                    }

                    stack.Push(i);
                }

                foreach (var item in resultArr)
                {
                    Console.Write(item + " ");
                }
            }

            public static void Task3Main()
            {
                int size = int.Parse(Console.ReadLine());
                string[] strData = Console.ReadLine().Split(' ');
                int[] data = new int[size];
                for (int i = 0; i < size; i++)
                {
                    data[i] = int.Parse(strData[i]);
                }

                MainMethod(data);
            }
        }
    }
}
