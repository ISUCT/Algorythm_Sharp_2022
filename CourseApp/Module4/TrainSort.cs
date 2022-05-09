using System;
using System.Collections.Generic;

namespace CourseApp.Module4
{
    public class TrainSort
    {
        public static void TrainSortMethod()
        {
            int carsCount = int.Parse(Console.ReadLine());
            string[] inpNumbers = Console.ReadLine().Split(' ');
            Stack<int> carStack = new Stack<int>();

            int queue = 1;
            bool flag = true;

            for (int i = 0; i < carsCount; i++)
            {
                int inpNum = int.Parse(inpNumbers[i]);
                if (carStack.Count > 0 && inpNum > carStack.Peek())
                {
                    flag = false;
                    break;
                }

                carStack.Push(inpNum);
                while (carStack.Count > 0 && queue == carStack.Peek())
                {
                    carStack.Pop();
                    queue++;
                }
            }

            if (flag)
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
