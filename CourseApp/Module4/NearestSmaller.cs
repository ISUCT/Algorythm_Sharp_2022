using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class NearestSmaller
    {
        private static void NearestSmallerMetod(int n, int[] arr)
        {
            Stack<int> stack = new Stack<int>();
            int[] outputArr = new int[arr.Length];
            for (int i = outputArr.Length - 1; i >= 0; i--)
            {
                while (stack.Count() > 0 && arr[stack.Peek()] >= arr[i])
                {
                    stack.Pop();
                }
                if (stack.Count() == 0)
                {
                    outputArr[i] = -1;
                }
                else
                {
                    outputArr[i] = stack.Peek();
                }
                stack.Push(i);
            }
            for (int i = 0; i < outputArr.Length; i++)
            {
                Console.Write($"{outputArr[i]} ");
            }
        }

        public static void NearestSmaller_Main()
        {
            int n = int.Parse(Console.ReadLine());
            string[] arrStr = Console.ReadLine().Split(' ');
            NearestSmallerMetod(n, Convert(arrStr));
        }
        private static int[] Convert(string[] arrStr)
        {
            int[] arr = new int[arrStr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(arrStr[i]);
            }
            return arr;
        }
    }
}
