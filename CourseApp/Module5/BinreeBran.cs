using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class BinreeBran
    {
        private Node root;

        public static void BinaryTreeMethod()
        {
            string b = Console.ReadLine();

            string[] val = b.Split(' ');

            var tr = new BinreeBran();

            for (int j = 0; j < val.Length - 1; j++)
            {
                tr.Insert(int.Parse(val[j]));
            }

            tr.LaunchPrintLastNodes();
        }

        public void Insert(int dat)
        {
            root = InnerInsert(dat, root);
        }

        private void LaunchPrintLastNodes()
        {
            PrintLastNodes(root);
        }

        private void PrintLastNodes(Node val)
        {
            if (val == null)
            {
                return;
            }

            PrintLastNodes(val.Left);

            if ((val.Left != null && val.Right == null) || (val.Right != null && val.Left == null))
            {
                Console.WriteLine(val.Data);
            }

            PrintLastNodes(val.Right);
        }

        private Node InnerInsert(int dat, Node root)
        {
            if (root == null)
            {
                return new Node(dat);
            }

            if (root.Data > dat)
            {
                root.Left = InnerInsert(dat, root.Left);
            }
            else if (root.Data < dat)
            {
                root.Right = InnerInsert(dat, root.Right);
            }

            return root;
        }

        public class Node
        {
            public Node(int dat)
            {
                Data = dat;
                Left = null;
                Right = null;
            }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Data { get; set; }
        }
    }
}