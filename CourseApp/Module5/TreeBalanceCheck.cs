using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module5
{
    public class TreeBalanceCheck
    {
        public class Binary_Tree
        {
            private Node root;

            public static void TreeBalanceCheckMethod()
            {
                string s = Console.ReadLine();

                string[] sValues = s.Split(' ');

                var tree = new Binary_Tree();

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

            public virtual int Height(Node node)
            {
                if (node == null)
                {
                    return 0;
                }

                return 1 + Math.Max(Height(node.Left), Height(node.Right));
            }

            public virtual bool IsBalanced(Node node)
            {
                int lh;

                int rh;

                if (node == null)
                {
                    return true;
                }

                lh = Height(node.Left);
                rh = Height(node.Right);

                if (Math.Abs(lh - rh) <= 1 && IsBalanced(node.Left)
                    && IsBalanced(node.Right))
                {
                    return true;
                }

                return false;
            }

            public void Insert(int v)
            {
                root = InnerInsert(v, root);
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

            public class Node
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
}
