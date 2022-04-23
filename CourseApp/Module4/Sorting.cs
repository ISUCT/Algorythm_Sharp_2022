using System;

namespace CourseApp.Module4
{
    public class Sorting
    {
        public static void Receive_Sort()
        {
            var wagons_num = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            var sValues = s.Split(' ');
            var wagons_mas = new int[wagons_num];
            var answer_mas = new int[wagons_num];
            for (int i = 0; i < wagons_num; i++)
            {
                wagons_mas[i] = int.Parse(sValues[i]);
            }

            int a = 0;
            int b = 0;

            while (a != wagons_num)
            {
                if (Stack.Empty() == true || (b < wagons_num && wagons_mas[b] < Stack.Back()))
                {
                    Stack.Push(wagons_mas[b]);
                    b++;
                }
                else
                {
                    answer_mas[a] += Stack.Back();
                    Stack.Pop();
                    a++;
                }
            }

            bool answer = true;

            for (int i = 0; i < answer_mas.Length - 1; i++)
            {
                if (answer_mas[i] > answer_mas[i + 1])
                {
                    answer = false;
                }
            }

            if (answer == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private class Stack
        {
            private static int[] buf = new int[100000000 + 100000];
            private static int top = -1;

            public static void Push(int a)
            {
                top++;
                buf[top] = a;
            }

            public static void Pop()
            {
                top--;
            }

            public static int Size()
            {
                return top + 1;
            }

            public static bool Empty()
            {
                return top == -1;
            }

            public static void Clear()
            {
                top = -1;
            }

            public static int Back()
            {
                return buf[top];
            }
        }
    }
}