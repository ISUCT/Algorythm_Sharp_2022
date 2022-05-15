using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testik
{
    public class ArrDeque
    {
        private static int[] buff = new int[100000001];
        private static int front = 0;
        private static int back = 100000001 - 1;
        private static int size = 0;

        public static void PushBack(int t)
        {
            back++;
            if (back == 100000001)
            {
                back = 0;
            }

            buff[back] = t;
            size++;
        }

        public static void PushFront(int t)
        {
            front--;
            if (front < 0)
            {
                front = 100000001 - 1;
            }

            buff[front] = t;
            size++;
        }

        public static void PopBack()
        {
            back--;
            if (back < 0)
            {
                back = 100000001 - 1;
            }

            size--;
        }

        public static void PopFront()
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