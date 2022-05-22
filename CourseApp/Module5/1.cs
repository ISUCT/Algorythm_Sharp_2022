using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Module5
{
    public class Branches
    {
        public static void Main()
        {
            int[] order = Console.ReadLine().Trim().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
            BinaryTree bi_tree = new BinaryTree();
            foreach (var item in order)
            {
                if (item != 0)
                {
                    bi_tree.Insert(item);
                }
            }
            List<int> conclusion = bi_tree.Elements();
            foreach (var item in conclusion)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
    public class BinaryTree
    {
        private Node score = null;
        private int size = 0;

        public bool One(int n)
        {
            return HereFind(n, score);
        }

        public List<int> Elements()
        {
            List<int> elements = new List<int>();
            HereElements(score, elements);
            return elements;
        }

        public void Insert(int n)
        {
            score = HereInsert(n, score);
        }

        private bool HereFind(int n, Node real)
        {
            if (real == null)
            {
                return false;
            }
            else if (real.Data == n)
            {
                return true;
            }
            else if (real.Data > n)
            {
                return HereFind(n, real.Left);
            }
            else
            {
                return HereFind(n, real.Right);
            }
        }

        private Node HereInsert(int n, Node real)
        {
            if (real == null)
            {
                size++;
                return new Node(n);
            }
            else if (real.Data > n)
            {
                real.Left = HereInsert(n, real.Left);
            }
            else if (real.Data < n)
            {
                real.Right = HereInsert(n, real.Right);
            }

            return real;
        }

        private void HereElements(Node real, List<int> elements)
        {
            if (real == null)
            {
                return;
            }

            HereElements(real.Left, elements);
            if (((real.Left == null) && (real.Right != null)) || ((real.Right == null) && (real.Left != null)))
            {
                elements.Add(real.Data);
            }

            HereElements(real.Right, elements);
        }
    }
    public class Node
    {
        public Node(int input)
        {
            Data = input;
            Left = null;
            Right = null;
           
        }
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
       
    }
}

