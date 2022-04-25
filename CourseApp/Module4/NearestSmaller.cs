using System;
using System.Collections.Generic;

namespace CourseApp.Module4
{
    public class NearestSmaller
    {
        public static void NearestSmallerMethod()
        {
            int n = int.Parse(Console.ReadLine());
            string[] inputStr = Console.ReadLine().Split(' ');

            int[] inputNums = new int[n];
            for (int i = 0; i < n; i++)
            {
                inputNums[i] = int.Parse(inputStr[i]);
            }

            int[] answerArr = new int[n];

            Stack<int> numsStack = new Stack<int>(n);
            for (int i = n - 1; i >= 0; i--)
            {
                while (numsStack.Count > 0 && inputNums[numsStack.Peek()] >= inputNums[i])
                {
                    numsStack.Pop();
                }

                if (numsStack.Count == 0)
                {
                    answerArr[i] = -1;
                }
                else
                {
                    answerArr[i] = numsStack.Peek();
                }

                numsStack.Push(i);
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(answerArr[i] + " ");
            }
        }
    }
}
