using System;

public class NearestSmaller
{
    public static void NearestSmallerMethod()
    {
        int size = int.Parse(Console.ReadLine());
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[size];

        for (int i = size - 1; i >= 0; i--)
        {
            while (Stack.Empty() == false && int.Parse(values[Stack.Top()]) >= int.Parse(values[i]))
            {
                Stack.Pop();
            }

            if (Stack.Empty() == true)
            {
                result[i] = -1;
            }
            else
            {
                result[i] = Stack.Top();
            }

            Stack.Push(i);
        }

        for (int i = 0; i < size; i++)
        {
            Console.Write(result[i] + " ");
        }
    }

    private class Stack
    {
        private static int[] buffer = new int[100001];
        private static int top = -1;

        public static void Push(int a)
        {
            top++;
            buffer[top] = a;
        }

        public static bool Empty()
        {
            return top <= -1;
        }

        public static int Size()
        {
            return top;
        }

        public static void Pop()
        {
            top--;
        }

        public static int Top()
        {
            return buffer[top];
        }
    }
}
