using System;

namespace CourseApp.Module5
{
    public class Node<T>
        where T : IComparable
    {
        public T Data { get; private set; }

        public Node<T> Left { get; private set; }

        public Node<T> Right { get; private set; }

#pragma warning disable SA1201 // Elements must appear in the correct order
        public Node(T data)
#pragma warning restore SA1201 // Elements must appear in the correct order
        {
            Data = data;
        }

        public Node(T data, Node<T> left, Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }

        public bool Add(T data)
        {
            if (data == null)
            {
                return false;
            }

            var compareResult = data.CompareTo(Data);

            if (compareResult < 0)
            {
                if (Left == null)
                {
                    Left = new Node<T>(data);
                }
                else
                {
                    return Left.Add(data);
                }
            }
            else if (compareResult == 0)
            {
                return false;
            }
            else
            {
                if (Right == null)
                {
                    Right = new Node<T>(data);
                }
                else
                {
                    return Right.Add(data);
                }
            }

            return true;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}