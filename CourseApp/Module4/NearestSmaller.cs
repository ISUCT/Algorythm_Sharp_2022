using System;

public class NearestSmaller
{
    public static void GetNearestSmaller()
    {
        var numberElements = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var sValues = s.Split(' ');
        var arrayElements = new int[numberElements];
        var answerArray = new int[numberElements];
        for (int i = 0; i < numberElements; i++)
        {
            arrayElements[i] = int.Parse(sValues[i]);
        }

        int index = numberElements - 1;
        while (index >= 0)
        {
            while (Stack.Empty() == false && arrayElements[Stack.Back()] >= arrayElements[index])
            {
                Stack.Pop();
            }

            if (Stack.Empty() == true)
            {
                answerArray[index] = -1;
            }
            else
            {
                answerArray[index] = Stack.Back();
            }

            Stack.Push(index);

            index--;
        }

        for (int i = 0; i < numberElements; i++)
        {
            Console.Write(answerArray[i] + " ");
        }
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