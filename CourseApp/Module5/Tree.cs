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

        public void Add(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
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
    }
}