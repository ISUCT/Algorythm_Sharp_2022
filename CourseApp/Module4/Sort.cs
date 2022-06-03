using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class Sort
    {
        private static string SortMetod(int n, string[] arr)
        {
            Stack<int> stack = new Stack<int>();
            int count = 1;
            string _output = "YES";
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(arr[i]);

                if (stack.Count() > 0 && num > stack.Peek())
                {
                    _output = "NO";
                    break;
                }

                stack.Push(num);
                while (stack.Count() > 0 && count == stack.Peek())
                {
                    stack.Pop();
                    count++;
                }
            }
            return _output;
        }

        public static void Sort_Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split(' ');
            Console.WriteLine(SortMetod(n, arr));
        }
    }
}
