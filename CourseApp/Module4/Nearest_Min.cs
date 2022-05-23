using System;

public class Nearest_Min
{
    public static void Receive_Nearest_Min()
    {
        var elem_num = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var sValues = s.Split(' ');
        var elem_mas = new int[elem_num];
        var mas_answer = new int[elem_num];
        for (int i = 0; i < elem_num; i++)
        {
            elem_mas[i] = int.Parse(sValues[i]);
        }

        int index = elem_num - 1;
        while (index >= 0)
        {
            while (Stack.Empty() == false && elem_mas[Stack.Back()] >= elem_mas[index])
            {
                Stack.Pop();
            }

            if (Stack.Empty() == true)
            {
                mas_answer[index] = -1;
            }
            else
            {
                mas_answer[index] = Stack.Back();
            }

            Stack.Push(index);

            index--;
        }

        for (int i = 0; i < elem_num; i++)
        {
            Console.Write(mas_answer[i] + " ");
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