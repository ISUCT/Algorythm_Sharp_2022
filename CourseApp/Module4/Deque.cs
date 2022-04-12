namespace CourseApp.Module4
{
    public class Deque
    {
        private int[] buffer;
        private int head;
        private int tail;
        private int size = 0;

        public Deque (int in_size)
        {
           buffer = new int[in_size];
           head = in_size / 2;
           tail = head - 1;
        }

        public void PushFront(int input)
        {
            size++;
            head--;
            if (head == -1)
            {
                head = buffer.Length - 1;
            }

            buffer[head] = input;
        }

        public void PushBack(int input)
        {
            size++;
            tail++;
            if (tail == buffer.Length)
            {
                tail = 0;
            }

            buffer[tail] = input;
        }

        public void PopFront()
        {
            size--;
            head++;
            if (head == buffer.Length)
            {
                head = 0;
            }
        }

        public void PopBack()
        {
            size--;
            tail--;
            if (tail == -1)
            {
                tail = buffer.Length - 1;
            }
        }

        public int Front()
        {
            return buffer[head];
        }

        public int Back()
        {
            return buffer[tail];
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
            head = buffer.Length / 2;
            tail = head - 1;
        }
    }
}