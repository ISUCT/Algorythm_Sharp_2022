﻿using System;

public class GetPSP
{
    public static void GetPSPMethod()
    {
        string input = Console.ReadLine();
        char[] str = input.ToCharArray();
        int counter = 0;

        for (int i = 0; i < str.Length; i++)
        {
            if (Stack.Empty() == false && str[i] == ')')
            {
                Stack.Delete();
            }
            else if (str[i] == '(')
            {
                Stack.Push(str[i]);
            }
            else
            {
                counter++;
            }
        }

        Stack.Clear();
        Console.WriteLine(counter + Stack.Size());
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
    }
}
