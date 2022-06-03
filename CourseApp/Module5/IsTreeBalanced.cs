using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class IsTreeBalanced
    {
        private Node2 root = null;
        private List<int> elements;
        private static IsTreeBalanced tree = new IsTreeBalanced();
        private bool CheckIsTreeBalanced(Node2 node)
        {
            if (node == null)
            {
                return true;
            }

            if (Math.Abs(Level(node.left) - Level(node.right)) <= 1 && CheckIsTreeBalanced(node.left) && CheckIsTreeBalanced(node.right))
            {
                return true;
            }

            return false;
        }

        private int Level(Node2 node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Level(node.left), Level(node.right));
        }


        private void Insert(int n)
        {
            root = Inserting(n, root);
        }

        private bool Finding(int n, Node2 root)
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

        private void LastElements(Node2 arr)
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

        private Node2 Inserting(int n, Node2 root)
        {
            if (root == null)
            {
                return new Node2(n);
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

        private void Bypass(Node2 node)
        {
            if (node == null)
            {
                return;
            }

            Bypass(node.left);
            elements.Add(node.data);
            Bypass(node.right);
        }

        public static void IsTreeBalanced_Main()
        {
            int[] n = Convert(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
            Console.WriteLine(tree.Check());
        }
        private static int[] Convert(string[] arrStr)
        {
            int[] arr = new int[arrStr.Length - 1];
            for (int i = 0; i < arrStr.Length - 1; i++)
            {
                tree.Insert(int.Parse(arrStr[i]));
            }

            return arr;
        }
        private string Check()
        {
            if (CheckIsTreeBalanced(root)) return "YES";
            else return "NO";
        }
    }

    public class Node2
    {
        public Node2(int n)
        {
            left = null;
            right = null;
            data = n;
        }
        public Node2 left { get; set; }
        public Node2 right { get; set; }
        public int data { get; set; }
    }
}
