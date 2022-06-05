using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module4
{
    public class Queue
    {
        private int[] array;
        private int head;
        private int tail;
        private int size = 0;

        public Queue(int in_size)
        {
            array = new int[in_size];
            head = in_size / 2;
            tail = head - 1;
        }

        public void PushF(int input)
        {
            size++;
            head--;
            if (head == -1)
            {
                head = array.Length - 1;
            }

            array[head] = input;
        }

        public void PushB(int input)
        {
            size++;
            tail++;
            if (tail == array.Length)
            {
                tail = 0;
            }

            array[tail] = input;
        }

        public void PopF()
        {
            size--;
            head++;
            if (head == array.Length)
            {
                head = 0;
            }
        }

        public void PopB()
        {
            size--;
            tail--;
            if (tail == -1)
            {
                tail = array.Length - 1;
            }
        }

        public int Front()
        {
            return array[head];
        }

        public int Back()
        {
            return array[tail];
        }

        public bool Empty()
        {
            return size == 0;
        }

        public int Size()
        {
            return size;
        }

        public void Clear()
        {
            head = array.Length / 2;
            tail = head - 1;
        }
    }
}
