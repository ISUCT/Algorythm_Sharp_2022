using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class Binary_Tree
    {
        private Node root;
        private List<int> size;

        public static void BinaryTreeMethod()
        {
            string s = Console.ReadLine();

            string[] sValues = s.Split(' ');

            var tree = new Binary_Tree();

            for (int i = 0; i < sValues.Length - 1; i++)
            {
                tree.Insert(int.Parse(sValues[i]));
            }

            tree.FindLastElem();
        }

        public void Insert(int v)
        {
            root = InnerInsert(v, root);
        }

        public List<int> GetValues()
        {
            size = new List<int>();
            InnerTraversal(root);
            return size;
        }

        private bool InnerFind(int v, Node root)
        {
            if (root == null)
            {
                return false;
            }

            if (v == root.Data)
            {
                return true;
            }
            else if (v < root.Data)
            {
                return InnerFind(v, root.Left);
            }
            else
            {
                return InnerFind(v, root.Right);
            }
        }

        private void FindLastElem()
        {
            LastElem(root);
        }

        private void LastElem(Node value)
        {
            if (value == null)
            {
                return;
            }

            LastElem(value.Left);

            if ((value.Left != null && value.Right == null) || (value.Right != null && value.Left == null))
            {
                Console.WriteLine(value.Data);
            }

            LastElem(value.Right);
        }

        private Node InnerInsert(int v, Node root)
        {
            if (root == null)
            {
                return new Node(v);
            }

            if (root.Data > v)
            {
                root.Left = InnerInsert(v, root.Left);
            }
            else if (root.Data < v)
            {
                root.Right = InnerInsert(v, root.Right);
            }

            return root;
        }

        private void InnerTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            InnerTraversal(node.Left);
            size.Add(node.Data);
            InnerTraversal(node.Right);
        }

        internal class Node
        {
            public Node(int v)
            {
                Data = v;
                Left = null;
                Right = null;
            }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Data { get; set; }
        }
    }
}