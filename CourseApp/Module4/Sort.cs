using System;

namespace CourseApp.Module4
{
    public class Sort
    {
        public static void Sort_Method()
        {
            var numberWagons = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            var sValues = s.Split(' ');
            var arrayWagons = new int[numberWagons];
            var answerArray = new int[numberWagons];
            for (int i = 0; i < numberWagons; i++)
            {
                arrayWagons[i] = int.Parse(sValues[i]);
            }

            int a = 0;
            int b = 0;

            while (a != numberWagons)
            {
                if (Stack.Empty() == true || (b < numberWagons && arrayWagons[b] < Stack.Back()))
                {
                    Stack.Push(arrayWagons[b]);
                    b++;
                }
                else
                {
                    answerArray[a] += Stack.Back();
                    Stack.Pop();
                    a++;
                }
            }

            bool isAnswer = true;

            for (int i = 0; i < answerArray.Length - 1; i++)
            {
                if (answerArray[i] > answerArray[i + 1])
                {
                    isAnswer = false;
                }
            }

            if (isAnswer == true)
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
            private static int[] buffer = new int[1000000];
            private static int top = -1;

            public static void Push(int a)
            {
                top++;
                buffer[top] = a;
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
                return buffer[top];
            }
        }
    }
}
