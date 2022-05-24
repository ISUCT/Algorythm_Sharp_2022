using System;

namespace CourseApp.Module4
{
    public class Correct_bracket_sequence
    {
        public static void CBS_Method()
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
