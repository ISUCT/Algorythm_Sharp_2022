namespace CourseApp.Module5.Task_1
{
    public class Node
    {
        public Node (int input)
        {
            Left = null;
            Right = null;
            Data = input;
        }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Data { get; set; }
    }
}
