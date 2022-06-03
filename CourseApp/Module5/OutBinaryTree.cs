using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class OutBinaryTree
    {
        private Node root = null;
        private List<int> elements;
        private static OutBinaryTree tree = new OutBinaryTree();

        private void Insert(int n)
        {
            root = Inserting(n, root);
        }
        private bool Finding(int n, Node root)
        {
            if (root == null)
            {
                return false;
            }

            if (n == root.data)
            {
                return true;
            }
            else if (n < root.data)
            {
                return Finding(n, root.left);
            }
            else
            {
                return Finding(n, root.right);
            }
        }

        private void FindLastElements()
        {
            LastElements(root);
        }

        private void LastElements(Node arr)
        {
            if (arr == null)
            {
                return;
            }

            LastElements(arr.left);

            if ((arr.left != null && arr.right == null) || (arr.right != null && arr.left == null))
            {
                Console.WriteLine(arr.data);
            }

            LastElements(arr.right);
        }

        private Node Inserting(int n, Node root)
        {
            if (root == null)
            {
                return new Node(n);
            }

            if (root.data > n)
            {
                root.left = Inserting(n, root.left);
            }
            else if (root.data < n)
            {
                root.right = Inserting(n, root.right);
            }

            return root;
        }

        private void Bypass(Node node)
        {
            if (node == null)
            {
                return;
            }

            Bypass(node.left);
            elements.Add(node.data);
            Bypass(node.right);
        }

        public static void OutBinaryTree_Main()
        {
            int[] n = Convert(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
        private static int[] Convert(string[] arrStr)
        {
            int[] arr = new int[arrStr.Length - 1];
            for (int i = 0; i < arrStr.Length - 1; i++)
            {
                tree.Insert(int.Parse(arrStr[i]));
            }
            tree.FindLastElements();
            return arr;
        }
    }

    public class Node
    {
        public Node(int n)
        {
            left = null;
            right = null;
            data = n;
        }
        public Node left { get; set; }
        public Node right { get; set; }
        public int data { get; set; }
    }
}
