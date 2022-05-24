using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class Bin_Tree
    {
        private Node root;
        private List<int> size;

        public static void BinTreeMeth()
        {
            string s = Console.ReadLine();

            string[] sValues = s.Split(' ');

            var tree = new Bin_Tree();

            for (int i = 0; i < sValues.Length - 1; i++)
            {
                tree.Insert(int.Parse(sValues[i]));
            }

            tree.FindLastElem();
        }

        public void Insert(int a)
        {
            root = InnerInsert(a, root);
        }

        public List<int> GetValues()
        {
            size = new List<int>();
            InnerTraversal(root);
            return size;
        }

        private bool InnerFind(int a, Node root)
        {
            if (root == null)
            {
                return false;
            }

            if (a == root.Data)
            {
                return true;
            }
            else if (a < root.Data)
            {
                return InnerFind(a, root.L);
            }
            else
            {
                return InnerFind(a, root.R);
            }
        }

        private bool Find(int a)
        {
            return InnerFind(a, root);
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

            LastElem(value.L);

            if ((value.L != null && value.R == null) || (value.R != null && value.L == null))
            {
                Console.WriteLine(value.Data);
            }

            LastElem(value.R);
        }

        private Node InnerInsert(int a, Node root)
        {
            if (root == null)
            {
                return new Node(a);
            }

            if (root.Data > a)
            {
                root.L = InnerInsert(a, root.L);
            }
            else if (root.Data < a)
            {
                root.R = InnerInsert(a, root.R);
            }

            return root;
        }

        private void InnerTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            InnerTraversal(node.L);
            size.Add(node.Data);
            InnerTraversal(node.R);
        }

        internal class Node
        {
            public Node(int a)
            {
                Data = a;
                L = null;
                R = null;
            }

            public Node L { get; set; }

            public Node R { get; set; }

            public int Data { get; set; }
        }
    }
}