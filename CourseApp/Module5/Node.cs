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
            Right = right;
            Left = left;
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

/*        public void SchildrenTree()
        {

        }*/

        public int CompeareTo(object obj)
        {
            if (obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new Exception("Не совпад типов");
            }
        }

        public int CompareTo(T other)
        {
            return Data.CompareTo(other);
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}