using System;

namespace CourseApp.Module5
{
    public class BranchesOfaBinaryTree
    {
        private Node root;

        public static void ClassMain()
        {
            string k = Console.ReadLine();

            string[] values = k.Split(' ');

            var tree = new BranchesOfaBinaryTree();

            for (int g = 0; g < values.Length - 1; g++)
            {
                tree.Insert(int.Parse(values[g]));
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