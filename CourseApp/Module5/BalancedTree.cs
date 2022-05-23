using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class BalancedTree
    {
        private Node root;

        public static void ClassMain()
        {
            string k = Console.ReadLine();

            string[] values = k.Split(' ');

            var tree = new BalancedTree();

            for (int g = 0; g < values.Length - 1; g++)
            {
                tree.Insert(int.Parse(values[g]));
            }

            if (tree.Balanced(tree.root))
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
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

        private bool Balanced(Node node)
        {
            int leftHeight;

            int rightHeight;

            if (node == null)
            {
                return true;
            }

            leftHeight = Height(node.Left);
            rightHeight = Height(node.Right);

            if (Math.Abs(leftHeight - rightHeight) <= 1 && Balanced(node.Left)
                && Balanced(node.Right))
            {
                return true;
            }

            return false;
        }

        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }
    }
}
