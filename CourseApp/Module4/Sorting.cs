using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Module4
{
    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] AB = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] result = new int[AB.Length];
        int i = 0;
        int j = 0;

        while (i != AB.Length)
        {
            if (Stack.Empty() == true || (j < AB.Length && int.Parse(AB[j]) < Stack.Show()))
            {
                Stack.Click(int.Parse(AB[j]));
                j++;
            }
            else
            {
                result[i] += Stack.Show();
                Stack.Delete();
                i++;
            }
        }
        Console.WriteLine(Vg(result));
    }
    public static string Vg(int[] result)
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

        public static void Click(int x)
        {
            top++;
            buffer[top] = x;
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