using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class Balanced_Tree
    {
        private Node root;

        public static void BalTreeMeth()
        {
            string s = Console.ReadLine();

            string[] sValues = s.Split(' ');

            var tree = new Balanced_Tree();

            for (int i = 0; i < sValues.Length - 1; i++)
            {
                tree.Insert(int.Parse(sValues[i]));
            }

            if (tree.IsBalanced(tree.root))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        public virtual bool IsBalanced(Node node)
        {
            int left_hight;

            int right_hight;

            if (node == null)
            {
                return true;
            }

            left_hight = H(node.Left);
            right_hight = H(node.Right);

            if (Math.Abs(left_hight - right_hight) <= 1 && IsBalanced(node.Left)
                && IsBalanced(node.Right))
            {
                return true;
            }

            return false;
        }

        public virtual int H(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(H(node.Left), H(node.Right));
        }

        public void Insert(int a)
        {
            root = InnerInsert(a, root);
        }

        private void PrintStart()
        {
            PrintOneChild(root);
        }

        private void PrintOneChild(Node value)
        {
            if (value == null)
            {
                return;
            }

            PrintOneChild(value.Left);

            if ((value.Left != null && value.Right == null) || (value.Right != null && value.Left == null))
            {
                Console.WriteLine(value.Data);
            }

            PrintOneChild(value.Right);
        }

        private Node InnerInsert(int a, Node root)
        {
            if (root == null)
            {
                return new Node(a);
            }

            if (root.Data > a)
            {
                root.Left = InnerInsert(a, root.Left);
            }
            else if (root.Data < a)
            {
                root.Right = InnerInsert(a, root.Right);
            }

            return root;
        }

        public class Node
        {
            public Node(int a)
            {
                Data = a;
                Left = null;
                Right = null;
            }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Data { get; set; }
        }
    }
}
