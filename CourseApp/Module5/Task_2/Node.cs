namespace CourseApp.Module5.Task_2
{
    public class Node
    {
        public Node (int input)
        {
            Left = null;
            Right = null;
            Data = input;
        }

        public Node Previous { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Data { get; set; }

        public int Height_left { get; set; }

        public int Height_right { get; set; }
    }
}