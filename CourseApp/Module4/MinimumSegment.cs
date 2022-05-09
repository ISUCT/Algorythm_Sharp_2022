using System;

namespace CourseApp.Module4
{
    public class MinimumSegment
    {
        public static void MinimumSegmentMethod()
        {
            string[] inp1 = Console.ReadLine().Split(" ");
            int n = int.Parse(inp1[0]);
            ushort k = ushort.Parse(inp1[1]);

            string[] inp2 = Console.ReadLine().Split(" ");
            int[] numsArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                numsArray[i] = int.Parse(inp2[i]);
            }

            for (int i = 0; i < k; i++)
            {
                while (Deque.IsEmpty() == false && numsArray[i] < numsArray[Deque.Front()])
                {
                    Deque.PopFront();
                }

                Deque.PushFront(i);
            }

            for (int i = k; i < n; i++)
            {
                Console.WriteLine(numsArray[Deque.Back()]);

                while (Deque.IsEmpty() == false && Deque.Back() <= i - k)
                {
                    Deque.PopBack();
                }

                while (Deque.IsEmpty() == false && numsArray[i] < numsArray[Deque.Front()])
                {
                    Deque.PopFront();
                    if (Deque.Size == 0)
                    {
                        Deque.Clear();
                    }
                }

                Deque.PushFront(i);
            }

            Console.WriteLine(numsArray[Deque.Back()]);
        }

        private class Deque
        {
            private static int[] buffer = new int[100000001];
            private static int front = 0;
            private static int back = 100000001 - 1;

            public static int Size { get; set; }

            public static void PushBack(int data)
            {
                back++;
                if (back == 100000001)
                {
                    back = 0;
                }

                buffer[back] = data;
                Size++;
            }

            public static void PushFront(int data)
            {
                front--;
                if (front < 0)
                {
                    front = 100000001 - 1;
                }

                buffer[front] = data;
                Size++;
            }

            public static void PopBack()
            {
                back--;
                if (back < 0)
                {
                    back = 100000001 - 1;
                }

                Size--;
            }

            public static void PopFront()
            {
                front++;
                if (front == 100000001)
                {
                    front = 0;
                }

                Size--;
            }

            public static void Clear()
            {
                front = 0;
                back = 100000001 - 1;
                Size = 0;
            }

            public static int Front()
            {
                return buffer[front];
            }

            public static int Back()
            {
                return buffer[back];
            }

            public static bool IsEmpty()
            {
                return Size == 0;
            }
        }
    }
}
