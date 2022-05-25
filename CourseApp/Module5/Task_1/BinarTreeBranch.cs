﻿using System;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_1
{
    public class BinarTreeBranch
    {
        private Node root;
        private List<int> size;

        public static void BinaryTreeBranchMethod()
        {
            string s = Console.ReadLine();

            string[] sValues = s.Split(' ');

            var tree = new BinarTreeBranch();

            for (int i = 0; i < sValues.Length - 1; i++)
            {
                tree.Insert(int.Parse(sValues[i]));
            }

            tree.FindLastElem();
        }

        public void Insert(int n)
        {
            root = InnerInsert(n, root);
        }

        public List<int> GetValues()
        {
            size = new List<int>();
            InnerTraversal(root);
            return size;
        }

        private bool InnerFind(int n, Node root)
        {
            if (root == null)
            {
                return false;
            }

            if (n == root.Data)
            {
                return true;
            }
            else if (n < root.Data)
            {
                return InnerFind(n, root.Left);
            }
            else
            {
                return InnerFind(n, root.Right);
            }
        }

        private bool Find(int n)
        {
            return InnerFind(n, root);
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

            LastElem(value.Left);

            if ((value.Left != null && value.Right == null) || (value.Right != null && value.Left == null))
            {
                Console.WriteLine(value.Data);
            }

            LastElem(value.Right);
        }

        private Node InnerInsert(int n, Node root)
        {
            if (root == null)
            {
                return new Node(n);
            }

            if (root.Data > n)
            {
                root.Left = InnerInsert(n, root.Left);
            }
            else if (root.Data < n)
            {
                root.Right = InnerInsert(n, root.Right);
            }

            return root;
        }

        private void InnerTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            InnerTraversal(node.Left);
            size.Add(node.Data);
            InnerTraversal(node.Right);
        }

        internal class Node
        {
            public Node(int n)
            {
                Data = n;
                Left = null;
                Right = null;
            }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public int Data { get; set; }
        }
    }
}