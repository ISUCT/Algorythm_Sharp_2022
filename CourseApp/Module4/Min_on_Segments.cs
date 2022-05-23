using System;

public class Min_on_Segments
{
    public static void Receive_Min_Segments()
    {
        string first = Console.ReadLine();
        string[] first_values = first.Split(' ');
        int[] first_mas = new int[2];
        for (int i = 0; i < 2; i++)
        {
            first_mas[i] = int.Parse(first_values[i]);
        }

        string second = Console.ReadLine();
        string[] second_values = second.Split(' ');
        int[] second_mas = new int[first_mas[0]];
        for (int i = 0; i < first_mas[0]; i++)
        {
            second_mas[i] = int.Parse(second_values[i]);
        }

        for (int i = 0; i < first_mas[1]; i++)
        {
            while (Deque.Empty() == false && second_mas[i] < second_mas[Deque.Front()])
            {
                Deque.Pop_Front();
            }

            Deque.Push_Front(i);
        }

        for (int i = first_mas[1]; i < first_mas[0]; i++)
        {
            Console.WriteLine(second_mas[Deque.Back()]);

            while (Deque.Empty() == false && Deque.Back() <= i - first_mas[1])
            {
                Deque.Pop_Back();
            }

            while (Deque.Empty() == false && second_mas[i] < second_mas[Deque.Front()])
            {
                Deque.Pop_Front();
                if (Deque.Size() == 0)
                {
                    Deque.Clear();
                }
            }

            Deque.Push_Front(i);
        }

        Console.WriteLine(second_mas[Deque.Back()]);
    }

    private class Deque
    {
        private static int w = 777777777;
        private static int[] buffer = new int[w];
        private static int front = 0;
        private static int back = w - 1;
        private static int size = 0;

        public static void Push_Back(int t)
        {
            back++;
            if (back == w)
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
                front = w - 1;
            }

            buffer[front] = t;
            size++;
        }

        public static void Pop_Back()
        {
            back--;
            if (back < 0)
            {
                back = w - 1;
            }

            size--;
        }

        public static void Pop_Front()
        {
            front++;
            if (front == w)
            {
                front = 0;
            }

            size--;
        }

        public static void Clear()
        {
            front = 0;
            back = w - 1;
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