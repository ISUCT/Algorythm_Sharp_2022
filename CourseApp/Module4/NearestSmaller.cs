using System;

public class NearestSmaller
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var s = Console.ReadLine();
        var v = s.Split(' ');
        var mass = new int[n];
        var conclusion = new int[n];
        for (int i = 0; i < n; i++)
        {
            mass[i] = int.Parse(v[i]);
        }
        int index = n - 1;
        while (index >= 0)
        {
            while ((Smaller.Empty() == false) && (mass[Smaller.Back()] >= mass[index]))
            {
                Smaller.Pop();
            }

            if (Smaller.Empty() == true)
            {
                conclusion[index] = -1;
            }
            else
            {
                conclusion[index] = Smaller.Back();
            }

            Smaller.Push(index);

            index--;
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write(conclusion[i] + " ");
        }
    }

    private class Smaller
    {
        private static int[] buffer = new int[1000000001];
        private static int top = -1;

        public static void Push(int x)
        {
            top++;
            buffer[top] = x;
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
