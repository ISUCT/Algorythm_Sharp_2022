using System;

namespace CourseApp.Module4
{
    public class PSP
    {
        public static void GetPSP()
        {
            string parentheses = Console.ReadLine();
            int counter = 0;

            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '(')
                {
                    Stack.Push(parentheses[i]);
                }
                else if (Stack.Empty() == false && parentheses[i] == ')')
                {
                    Stack.Pop();
                }
                else
                {
                    counter += 1;
                }
            }

            Console.WriteLine(counter + Stack.Size());
        }

        private class Stack
        {
            private static int[] buffer = new int[100000001];
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