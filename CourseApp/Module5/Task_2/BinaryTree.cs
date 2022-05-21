using System;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_2
{
    public class BinaryTree
    {
        private Node root = null;

        private int size = 0;

        private bool trigger;

        public void Insert (int n)
        {
            root = InnerInsert(n, root, null, 0);
        }

        public bool IsBalanced()
        {
            trigger = true;
            InnerCheckBalanced(root);
            return trigger;
        }

        private void InnerCheckBalanced(Node current)
        {
            if (current == null || !trigger)
            {
                return;
            }

            InnerCheckBalanced(current.Left);
            if (Math.Abs(current.Height_left - current.Height_right) > 1)
            {
                trigger = false;
            }

            InnerCheckBalanced(current.Right);
        }

        private Node InnerInsert(int n, Node current, Node previous, int depth)
        {
            if (current == null)
            {
                size++;
                Node temp = new Node(n);
                temp.Previous = previous;
                temp.Height_left = 0;
                temp.Height_right = 0;
                Node buffer1 = temp;
                int i = depth - 1;
                while (buffer1 != null)
                {
                    if (buffer1.Previous != null)
                    {
                        if (buffer1.Data < buffer1.Previous.Data)
                        {
                            if (buffer1.Previous.Height_left < depth - i)
                            {
                                buffer1.Previous.Height_left = depth - i;
                            }
                        }
                        else
                        {
                            if (buffer1.Previous.Height_right < depth - i)
                            {
                                buffer1.Previous.Height_right = depth - i;
                            }
                        }
                    }

                    buffer1 = buffer1.Previous;
                    i--;
                }

                return temp;
            }
            else if (current.Data > n)
            {
                current.Left = InnerInsert(n, current.Left, current, depth + 1);
            }
            else if (current.Data < n)
            {
                current.Right = InnerInsert(n, current.Right, current, depth + 1);
            }

            return current;
        }
    }
}