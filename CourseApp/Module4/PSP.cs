using System;

namespace CourseApp.Module4
{
    public class PSP
    {
        public static void Receive_PSP()
        {
            string bracket = Console.ReadLine();
            int c = 0;

            for (int i = 0; i < bracket.Length; i++)
            {
                if (bracket[i] == '(' || bracket[i] == '{' || bracket[i] == '[')
                {
                    Stack.Push(bracket[i]);
                }
                else if (Stack.Empty() == false && (bracket[i] == ')' || bracket[i] == '}' || bracket[i] == ']'))
                {
                    Stack.Pop();
                }
                else
                {
                    c += 1;
                }
            }

            Console.WriteLine(c + Stack.Size());
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