using System;

public class MinSeg
{
    public static void GetMinSeg()
    {
        string sFirst = Console.ReadLine();
        string[] sFirstVal = sFirst.Split(' ');
        int[] arrayFirst = new int[2];
        for (int i = 0; i < 2; i++)
        {
            arrayFirst[i] = int.Parse(sFirstVal[i]);
        }

        string sSecond = Console.ReadLine();
        string[] sSecondVal = sSecond.Split(' ');
        int[] arraySecond = new int[arrayFirst[0]];
        for (int i = 0; i < arrayFirst[0]; i++)
        {
            arraySecond[i] = int.Parse(sSecondVal[i]);
        }

        for (int i = 0; i < arrayFirst[1]; i++)
        {
            while (Deque.Empty() == false && arraySecond[i] < arraySecond[Deque.Front()])
            {
                Deque.Pop_Front();
            }

            Deque.Push_Front(i);
        }

        for (int i = arrayFirst[1]; i < arrayFirst[0]; i++)
        {
            Console.WriteLine(arraySecond[Deque.Back()]);

            while (Deque.Empty() == false && Deque.Back() <= i - arrayFirst[1])
            {
                Deque.Pop_Back();
            }

            while (Deque.Empty() == false && arraySecond[i] < arraySecond[Deque.Front()])
            {
                Deque.Pop_Front();
                if (Deque.Size() == 0)
                {
                    Deque.Clear();
                }
            }

            Deque.Push_Front(i);
        }

        Console.WriteLine(arraySecond[Deque.Back()]);
    }

    private class Deque
    {
        private static int[] buffer = new int[100000001];
        private static int front = 0;
        private static int back = 100000001 - 1;
        private static int size = 0;

        public static void Push_Back(int t)
        {
            back++;
            if (back == 100000001)
            {
                back = 0;
            }

            buffer[back] = t;
            size++;
        }

        public static void Push_Front(int t)
        {
            front--;
            if (front < 0)
            {
                front = 100000001 - 1;
            }

            buffer[front] = t;
            size++;
        }

        public static void Pop_Back()
        {
            back--;
            if (back < 0)
            {
                back = 100000001 - 1;
            }

            size--;
        }

        public static void Pop_Front()
        {
            front++;
            if (front == 100000001)
            {
                front = 0;
            }

            size--;
        }

        public static void Clear()
        {
            front = 0;
            back = 100000001 - 1;
            size = 0;
        }

        public static int Front()
        {
            return buffer[front];
        }

        public static int Back()
        {
            return buffer[back];
        }

        public static int Size()
        {
            return size;
        }

        public static bool Empty()
        {
            return size == 0;
        }
    }
}