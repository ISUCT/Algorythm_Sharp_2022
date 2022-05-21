using System.Collections.Generic;

namespace CourseApp.Module5.Task_1
{
    public class BinaryTree
    {
        private Node root = null;
        private int size = 0;

        public bool Find (int n)
        {
            return InnerFind(n, root);
        }

        public List<int> GetElements()
        {
            List<int> elements = new List<int>();
            InnerGetElements(root, elements);
            return elements;
        }

        public void Insert (int n)
        {
            root = InnerInsert(n, root);
        }

        private bool InnerFind (int n, Node current)
        {
            if (current == null)
            {
            return false;
            }
            else if (current.Data == n)
            {
                return true;
            }
            else if (current.Data > n)
            {
                return InnerFind(n, current.Left);
            }
            else
            {
                return InnerFind(n, current.Right);
            }
        }

        private Node InnerInsert(int n, Node current)
        {
            if (current == null)
            {
                size++;
                return new Node(n);
            }
            else if (current.Data > n)
            {
                current.Left = InnerInsert(n, current.Left);
            }
            else if (current.Data < n)
            {
                current.Right = InnerInsert(n, current.Right);
            }

            return current;
        }

        private void InnerGetElements(Node current, List<int> elements)
        {
            if (current == null)
            {
                return;
            }

            InnerGetElements(current.Left, elements);
            if ((current.Left == null && current.Right != null) || (current.Right == null && current.Left != null))
            {
                elements.Add(current.Data);
            }

            InnerGetElements(current.Right, elements);
        }
    }
}