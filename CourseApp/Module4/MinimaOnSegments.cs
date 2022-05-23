using System;

public class MinimaOnSegments
{
    public static void ClassMain()
    {
        string s1 = Console.ReadLine();
        string[] s1Values = s1.Split(' ');
        int[] array1 = new int[2];
        for (int g = 0; g < 2; g++)
        {
            array1[g] = int.Parse(s1Values[g]);
        }

        string s2 = Console.ReadLine();
        string[] s2Values = s2.Split(' ');
        int[] array2 = new int[array1[0]];
        for (int g = 0; g < array1[0]; g++)
        {
            array2[g] = int.Parse(s2Values[g]);
        }

        for (int g = 0; g < array1[1]; g++)
        {
            while (Deque.Empty() == false && array2[g] < array2[Deque.Front()])
            {
                Deque.Pop_Front();
            }

            Deque.Push_Front(g);
        }

        for (int g = array1[1]; g < array1[0]; g++)
        {
            Console.WriteLine(array2[Deque.Back()]);

            while (Deque.Empty() == false && Deque.Back() <= g - array1[1])
            {
                Deque.Pop_Back();
            }

            while (Deque.Empty() == false && array2[g] < array2[Deque.Front()])
            {
                Deque.Pop_Front();
                if (Deque.Size() == 0)
                {
                    Deque.Clear();
                }
            }

            Deque.Push_Front(g);
        }

        Console.WriteLine(array2[Deque.Back()]);
    }

    private class Deque
    {
        private static int[] buff = new int[100000001];
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

            buff[back] = t;
            size++;
        }

        public static void Push_Front(int t)
        {
            front--;
            if (front < 0)
            {
                front = 100000001 - 1;
            }

            buff[front] = t;
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
            return buff[front];
        }

        public static int Back()
        {
            return buff[back];
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