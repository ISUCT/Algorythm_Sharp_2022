using System;

public class Paths
{
    public static void PathsMethod()
    {
        int numbersOfWagons = int.Parse(Console.ReadLine());
        string[] wagons = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[wagons.Length];
        int k = 0;
        int j = 0;

        while ( k != wagons.Length)
        {
            if (Stack.Empty() == true || (j < wagons.Length && int.Parse(wagons[j]) < Stack.Show()))
            {
                Stack.Push(int.Parse(wagons[j]));
                j++;
            }
            else
            {
                result[k] += Stack.Show();
                Stack.Delete();
                k++;
            }
        }

        Console.WriteLine(Checker(result));
    }

    public static string Checker(int[] result)
    {
        for (int i = 0; i < result.Length - 1; i++)
        {
            if (result[i] > result[i + 1])
            {
                return "NO";
            }
        }

        return "YES";
    }

    private static class Stack
    {
        private static int[] buffer = new int[100000001];
        private static int top = -1;

        public static void Push(int a)
        {
            top++;
            buffer[top] = a;
        }

        public static bool Empty()
        {
            return top == -1;
        }

        public static void Delete()
        {
            top--;
        }

        public static int Size()
        {
            return top + 1;
        }

        public static void Clear()
        {
            top = -1;
        }

        public static int Show()
        {
            return buffer[top];
        }
    }
}