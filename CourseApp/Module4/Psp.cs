﻿using System;

namespace CourseApp.Module4
{
    public class Psp
    {
        public static void GetPsp()
        {
            string parenthes = Console.ReadLine();
            int count = 0;

            for (int i = 0; i < parenthes.Length; i++)
            {
                if (parenthes[i] == '(')
                {
                    Stack.Push(parenthes[i]);
                }
                else if (Stack.Empty() == false && parenthes[i] == ')')
                {
                    Stack.Pop();
                }
                else
                {
                    count += 1;
                }
            }

            Console.WriteLine(count + Stack.Size());
        }

        private class Stack
        {
            private static int[] buf = new int[100000001];
            private static int tp = -1;

            public static void Push(int a)
            {
                tp++;
                buf[tp] = a;
            }

            public static void Pop()
            {
                tp--;
            }

            public static int Size()
            {
                return tp + 1;
            }

            public static bool Empty()
            {
                return tp == -1;
            }

            public static void Clr()
            {
                tp = -1;
            }

            public static int Bak()
            {
                return buf[tp];
            }
        }
    }
}