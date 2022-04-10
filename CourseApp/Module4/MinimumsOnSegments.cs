using System;

public class MinimumsOnSegments
{
    public static void MinimumsOnSegmentsMethod()
    {
        string[] options = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int lenArr = int.Parse(options[0]);
        int lenWin = int.Parse(options[1]);
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < lenWin; i++)
        {
            while (Deque.Empty() == false && int.Parse(values[i]) < int.Parse(values[Deque.Front()]))
            {
                Deque.PopFront();
            }

            Deque.PushFront(i);
        }

        for (int i = lenWin; i < lenArr; i++)
        {
            Console.WriteLine(values[Deque.Back()]);

            while (Deque.Empty() == false && Deque.Back() <= i - lenWin)
            {
                Deque.PopBack();
            }

            while (Deque.Empty() == false && int.Parse(values[i]) < int.Parse(values[Deque.Front()]))
            {
                Deque.PopFront();
                if (Deque.Size() == 0)
                {
                    Deque.Clear();
                }
            }

            Deque.PushFront(i);
        }

        Console.WriteLine(values[Deque.Back()]);

        Deque.Clear();
    }

    private class Deque
    {
        private static int[] buffer = new int[150010];
        private static int front = 0;
        private static int back = 0;
        private static int size = 0;

        public static void PushBack(int t)
        {
            back++;
            if (back == buffer.Length - 1)
            {
                back = 0;
            }

            buffer[back] = t;
            size++;
        }

        public static void PushFront(int t)
        {
            front--;
            if (front < 0)
            {
                front = buffer.Length - 1;
            }

            buffer[front] = t;
            size++;
        }

        public static void PopBack()
        {
            back--;
            if (back < 0)
            {
                back = buffer.Length - 1;
            }

            size--;
        }

        public static void PopFront()
        {
            front++;
            if (front == buffer.Length - 1)
            {
                front = 0;
            }

            size--;
        }

        public static void Clear()
        {
            front = 0;
            back = buffer.Length - 1;
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
