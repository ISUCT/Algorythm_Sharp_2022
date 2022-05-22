using System;
using System.Collections.Generic;

public class BalancedTree
{
    private Node root;
    private List<int> values;
    private int size = 0;
    private bool checker;

    public static void CheckBalancedTreeMethod()
    {
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var tree = new BalancedTree();

        for (int i = 0; i < values.Length - 1; i++)
        {
            tree.Insert(int.Parse(values[i]));
        }

        tree.Check();
    }

    public void Insert(int data)
    {
        root = InnerInsert(data, root, null, 0);
    }

    public List<int> GetValues()
    {
        values = new List<int>();
        InnerTraversal(root);
        return values;
    }

    public bool Find(int data)
    {
        return InnerFind(data, root);
    }

    private void Check()
    {
        checker = true;
        CheckBalancedTree(root);
        if (checker == true)
        {
            Console.WriteLine("YES");
        }
        else
        {
            Console.WriteLine("NO");
        }
    }

    private void CheckBalancedTree(Node value)
    {
        if (value == null || checker == false)
        {
            return;
        }

        int a = SizeDepth(value.Right, 0);
        int b = SizeDepth(value.Left, 0);

        if (Math.Abs(SizeDepth(value.Right, 0) - SizeDepth(value.Left, 0)) > 1)
        {
            checker = false;
            return;
        }

        CheckBalancedTree(value.Left);

        CheckBalancedTree(value.Right);
    }

    private int SizeDepth(Node root, int previousDepth)
    {
        int depthRight = 0;
        int depthLeft = 0;

        if (root == null)
        {
            return 0;
        }
        else if (root.Left != null)
        {
            depthLeft = SizeDepth(root.Left, 1 + previousDepth);
        }
        else if (root.Right != null)
        {
            depthRight = SizeDepth(root.Right, 1 + previousDepth);
        }

        return Math.Max(Math.Max(depthRight, depthLeft), previousDepth + 1);
    }

    private bool InnerFind(int data, Node root)
    {
        if (root == null)
        {
            return false;
        }

        if (data == root.Data)
        {
            return true;
        }
        else if (data < root.Data)
        {
            return InnerFind(data, root.Left);
        }
        else
        {
            return InnerFind(data, root.Right);
        }
    }

    private Node InnerInsert(int data, Node root, Node previous, int depth)
    {
        if (root == null)
        {
            size++;
            return new Node(data);
        }

        if (root.Data > data)
        {
            root.Left = InnerInsert(data, root.Left, root, depth);
        }
        else if (root.Data < data)
        {
            root.Right = InnerInsert(data, root.Right, root, depth);
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
        values.Add(node.Data);
        InnerTraversal(node.Right);
    }

    internal class Node
    {
        public Node(int data)
        {
            Data = data;
            Left = null;
            Right = null;
        }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Data { get; set; }
    }
}
