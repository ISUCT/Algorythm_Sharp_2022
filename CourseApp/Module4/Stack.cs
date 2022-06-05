using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;

namespace CourseApp.Module4
{
    public class Stack
    {
        private readonly int size;
        private readonly int[] array;
        private int top;

        public Stack(int size)
        {
            this.size = size;
            this.top = 0;
            this.array = new int[this.size];
        }

        public int Top
        {
            get
            {
                return this.top;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }
        }

        public int Count
        {
            get
            {
                return this.top;
            }
        }

        public bool Full()
        {
            return this.top == this.size;
        }

        public bool Empty()
        {
            return this.top == 0;
        }

        public void Push(int element)
        {
            if (this.Full())
            {
                throw new Exception();
            }

            this.array[this.top++] = element;
        }

        public int Peek()
        {
            return array[this.top - 1];
        }

        public int Pop()
        {
            return this.array[--this.top];
        }
    }
}