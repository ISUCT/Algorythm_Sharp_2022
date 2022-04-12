namespace CourseApp.Module4
{
    public class Stack
    {
        private int[] buffer;
        private int top = -1;

        public Stack (int size)
        {
           buffer = new int[size];
        }

        public void Push(int input)
        {
            top++;
            buffer[top] = input;
        }

        public void Pop()
        {
            top--;
        }

        public int Back()
        {
            return buffer[top];
        }

        public bool Empty()
        {
            return top == -1;
        }

        public int Size()
        {
            return top + 1;
        }

        public void Clear()
        {
            top = -1;
        }
    }
}