using System;

public class NearSmal
{
    public static void GetNearSmall()
    {
        var numElem = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var sVal = s.Split(' ');
        var arrElem = new int[numElem];
        var ansArr = new int[numElem];
        for (int i = 0; i < numElem; i++)
        {
            arrElem[i] = int.Parse(sVal[i]);
        }

        int ind = numElem - 1;
        while (ind >= 0)
        {
            while (Stack.Empty() == false && arrElem[Stack.Back()] >= arrElem[ind])
            {
                Stack.Pop();
            }

            if (Stack.Empty() == true)
            {
                ansArr[ind] = -1;
            }
            else
            {
                ansArr[ind] = Stack.Back();
            }

            Stack.Push(ind);

            ind--;
        }

        for (int i = 0; i < numElem; i++)
        {
            Console.Write(ansArr[i] + " ");
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