using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class MinOnSegm
    {
        private static void MinOnSegmMetod(int n, int k, int[] arr)
        {
            for (int i = 0; i < k; i++)
            {
                while (Deque.Empty() == false && arr[i] < arr[Deque.Front()])
                {
                    Deque.Pop_front();
                }
                Deque.Push_front(i);
            }

            for (int i = k; i < n; i++)
            {
                Console.WriteLine(arr[Deque.Back()]);

                while (Deque.Empty() == false && Deque.Back() <= i - k)
                {
                    Deque.Pop_back();
                }

                while (Deque.Empty() == false && arr[i] < arr[Deque.Front()])
                {
                    Deque.Pop_front();
                    if (Deque.Size() == 0)
                    {
                        Deque.Clear();
                    }
                }
                Deque.Push_front(i);
            }
            Console.WriteLine(arr[Deque.Back()]);
        }
        public static void MinOnSegm_Main()
        {
            int[] arrNK = Convert(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            int[] arr = Convert(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            MinOnSegmMetod(arrNK[0], arrNK[1], arr);
        }
        private static int[] Convert(string[] arrStr)
        {
            int[] arr = new int[arrStr.Length];
            for (int i = 0; i < arrStr.Length; i++)
            {
                arr[i] = int.Parse(arrStr[i]);
            }
            return arr;
        }
    }

    public class Deque
    {
        private static int[] Buffer = new int[100000];
        private static int front = 0;
        private static int back = Buffer.Length - 1;
        private static int length = 0;
        public static void Push_front(int n)
        {
            front--;
            if (front < 0)
            {
                front = Buffer.Length - 1;
            }
            Buffer[front] = n;
            length++;
        }
        public static void Push_back(int n)
        {
            back++;
            if (back == Buffer.Length)
            {
                back = 0;
            }
            Buffer[back] = n;
            length++;
        }
        public static void Pop_front()
        {
            front++;
            if (front == Buffer.Length)
            {
                front = 0;
            }
            length--;
        }

        public static void Pop_back()
        {
            back--;
            if (back < 0)
            {
                back = Buffer.Length - 1;
            }
            length--;
        }

        public static void Clear()
        {
            front = 0;
            back = Buffer.Length - 1;
            length = 0;
        }

        public static int Front()
        {
            return Buffer[front];
        }

        public static int Back()
        {
            return Buffer[back];
        }

        public static int Size()
        {
            return length;
        }

        public static bool Empty()
        {
            return length == 0;
        }
    }
}
