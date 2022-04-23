using System;

public class NearestSmallerNumber
{
    public static void ClassMain()
    {
        var numberElements = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var sValues = s.Split(' ');
        var elementOfArray = new int[numberElements];
        var arrayOfAnswer = new int[numberElements];
        for (int g = 0; g < numberElements; g++)
        {
            elementOfArray[g] = int.Parse(sValues[g]);
        }

        int index = numberElements - 1;
        while (index >= 0)
        {
            while (Stack.Empty() == false && elementOfArray[Stack.Back()] >= elementOfArray[index])
            {
                Stack.Pop();
            }

            if (Stack.Empty() == true)
            {
                arrayOfAnswer[index] = -1;
            }
            else
            {
                arrayOfAnswer[index] = Stack.Back();
            }

            Stack.Push(index);

            index--;
        }

        for (int g = 0; g < numberElements; g++)
        {
            Console.Write(arrayOfAnswer[g] + " ");
        }
    }

    private class Stack
    {
        private static int[] buff = new int[100000001];
        private static int top = -1;

        public static void Push(int a)
        {
            top++;
            buff[top] = a;
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
            return buff[top];
        }
    }
}
