using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Module5
{
    public class Balance
    {
        public static void Main()
        {
            int[] orber = Console.ReadLine().Trim().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
            BinaryTree bi_tree = new BinaryTree();
            foreach (var item in orber)
            {
                if (item != 0)
                {
                    bi_tree.Insert(item);
                }
            }
            Console.WriteLine(bi_tree.IsBalanced() ? "YES" : "NO");
        }
    }
    public class BinaryTree
    {
        private Node score = null;

        private int size = 0;

        private bool cause;

        public void Insert(int n)
        {
            score = HereInsert(n, score, null, 0);
        }

        public bool IsBalanced()
        {
            cause = true;
            HereCheck(score);
            return cause;
        }

        private void HereCheck(Node real)
        {
            if (real == null || !cause)
            {
                return;
            }

            HereCheck(real.Left);
            if (Math.Abs(real.Top_Left - real.Top_Right) > 1)
            {
                cause = false;
            }

            HereCheck(real.Right);
        }

        private Node HereInsert(int a, Node real, Node previous, int k)
        {
            if (real == null)
            {
                size++;

                Node temp = new Node(a);
                temp.Previous = previous;
                temp.Top_Left = 0;
                temp.Top_Right = 0;
                Node buffer = temp;
                int i = k - 1;
                while (buffer != null)
                {
                    if (buffer.Previous != null)
                    {
                        if (buffer.Data < buffer.Previous.Data)
                        {
                            if (buffer.Previous.Top_Left < k - i)
                            {
                                buffer.Previous.Top_Left = k - i;
                            }
                        }
                        else
                        {
                            if (buffer.Previous.Top_Right < k - i)
                            {
                                buffer.Previous.Top_Right = k - i;
                            }
                        }
                    }

                    buffer = buffer.Previous;
                    i--;
                }

                return temp;
            }
            else if (real.Data > a)
            {
                real.Left = HereInsert(a, real.Left, real, k + 1);
            }
            else if (real.Data < a)
            {
                real.Right = HereInsert(a, real.Right, real, k + 1);
            }

            return real;
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

        public Node Previous { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Top_Left { get; set; }

        public int Top_Right { get; set; }
    }
}
