using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class Tree<T>
    where T : IComparable
    {
        public Node<T> Root { get; private set; }

        public int Count { get; private set; }

        public bool Add(T data)
        {
            if (data == null)
            {
                return false;
            }

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return true;
            }

            var addResult = Root.Add(data);
            if (addResult)
            {
                Count++;
            }

            return addResult;
        }

        public List<T> Preorder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return Preorder(Root);
        }

        public List<T> Children()
        {
            var list = new List<T>();
            Children(Root, list);
            return list;
        }

        public bool Balanced()
        {
            return Balanced(Root);
        }

        private List<T> Preorder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }

            return list;
        }

        private void Children(Node<T> node, List<T> list)
        {
            if (node == null)
            {
                return;
            }

            Children(node.Left, list);
            if ((node.Left == null && node.Right != null) || (node.Right == null && node.Left != null))
            {
                list.Add(node.Data);
            }

            Children(node.Right, list);
        }

        private int Height(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + Math.Max(Height(node.Left), Height(node.Right));
        }

        private bool Balanced(Node<T> node)
        {
            if (node == null)
            {
                return true;
            }

            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);

            if (Math.Abs(leftHeight - rightHeight) <= 1 && Balanced(node.Left) && Balanced(node.Right))
            {
                return true;
            }

            return false;
        }
    }
}