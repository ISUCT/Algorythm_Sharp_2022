using System;
using System.Collections.Generic;

namespace CourseApp.Module5
{
    public class BinaryTreeBranches
    {
        private Node root;

        public static void BinaryTreeMethod()
        {
            string s = Console.ReadLine();

            string[] values = s.Split(' ');

            var tree = new BinaryTreeBranches();

            for (int i = 0; i < values.Length - 1; i++)
            {
                tree.Insert(int.Parse(values[i]));
            }

            tree.LaunchPrintLastNodes();
        }

        public void Insert(int data)
        {
            root = InnerInsert(data, root);
        }

        private void LaunchPrintLastNodes()
        {
            PrintLastNodes(root);
        }

        private void PrintLastNodes(Node value)
        {
            if (value == null)
            {
                return;
            }

            PrintLastNodes(value.Left);

            if ((value.Left != null && value.Right == null) || (value.Right != null && value.Left == null))
            {
                Console.WriteLine(value.Data);
            }

            PrintLastNodes(value.Right);
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
    }
}
