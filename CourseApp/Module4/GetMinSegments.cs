using System;

public class MinimumSegments
{
    public static void GetMinSegments()
    {
        string sFirst = Console.ReadLine();
        string[] sFirstValues = sFirst.Split(' ');
        int[] arrFirst = new int[2];
        for (int i = 0; i < 2; i++)
        {
            arrFirst[i] = int.Parse(sFirstValues[i]);
        }

        string sSecond = Console.ReadLine();
        string[] sSecondValues = sSecond.Split(' ');
        int[] arrSecond = new int[arrFirst[0]];
        for (int i = 0; i < arrFirst[0]; i++)
        {
            arrSecond[i] = int.Parse(sSecondValues[i]);
        }

        for (int i = 0; i < arrFirst[1]; i++)
        {
            while (Deque.Empty() == false && arrSecond[i] < arrSecond[Deque.Front()])
            {
                Deque.Pop_Front();
            }

            Deque.Push_Front(i);
        }

        for (int i = arrFirst[1]; i < arrFirst[0]; i++)
        {
            Console.WriteLine(arrSecond[Deque.Back()]);

            while (Deque.Empty() == false && Deque.Back() <= i - arrFirst[1])
            {
                Deque.Pop_Back();
            }

            while (Deque.Empty() == false && arrSecond[i] < arrSecond[Deque.Front()])
            {
                Deque.Pop_Front();
                if (Deque.Size() == 0)
                {
                    Deque.Clear();
                }
            }

            Deque.Push_Front(i);
        }

        Console.WriteLine(arrSecond[Deque.Back()]);
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