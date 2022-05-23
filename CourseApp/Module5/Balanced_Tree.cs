using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class Balanced_Tree
    {
        private Node root;

        public static void BalancedTreeMethod()
        {
            string s = Console.ReadLine();

            string[] sValues = s.Split(' ');

            var tree = new Balanced_Tree();

            for (int i = 0; i < sValues.Length - 1; i++)
            {
                tree.Insert(int.Parse(sValues[i]));
            }

            tree.Check();
        }

        public void Insert(int data)
        {
            root = InnerInsert(data, root);
        }

        private Node InnerInsert(int data, Node root)
        {
            if (root == null)
            {
                return new Node(data);
            }

            if (root.Data > data)
            {
                root.Left = InnerInsert(data, root.Left);
            }
            else if (root.Data < data)
            {
                root.Right = InnerInsert(data, root.Right);
            }

            return root;
        }

        private bool CheckBalancedTree(Node node)
        {
            if (node == null)
            {
                return true;
            }

            int righttree = Level(node.Left);
            int lefttree = Level(node.Right);

            if (Math.Abs(lefttree - righttree) <= 1 && CheckBalancedTree(node.Left) && CheckBalancedTree(node.Right))
            {
                return true;
            }

            return false;
        }

        private int Level(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Level(node.Left), Level(node.Right));
        }

        private void Check()
        {
            if (CheckBalancedTree(root))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private void InnerTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            InnerTraversal(node.Left);
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