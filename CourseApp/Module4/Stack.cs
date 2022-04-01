namespace CourseApp.Module4
{
    public class Stack
    {
        private string[] buffer = new string[100000];
        private int top = -1;

        public void Push()
        {
            top++;
            buffer[top] = "(";
        }

        public void Pop()
        {
            top--;
        }

        public bool Empty()
        {
            return top == -1;
        }

        public int Size()
        {
            return top + 1;
        }
    }
}