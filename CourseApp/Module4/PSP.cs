using System;

namespace CourseApp.Module4
{
    public class PSP
    {
        public static void GETPSP()
        {
            string parentheses = Console.ReadLine();
            int counter = 0;

            for (int g = 0; g < parentheses.Length; g++)
            {
                if (parentheses[g] == '(')
                {
                    Stack.Push(parentheses[g]);
                }
                else if (Stack.Empty() == false && parentheses[g] == ')')
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
