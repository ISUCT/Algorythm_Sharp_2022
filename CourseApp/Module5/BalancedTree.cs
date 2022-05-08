using System;
using System.Collections.Generic;

public class BalancedTree
{
    private Node root;
    private List<int> values;
    private int leftSize = 0;
    private int rightSize = 0;
    private bool checker;

    public int Size { get; }

    public static void BalancedTreeMethod()
    {
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var tree = new BalancedTree();

        for (int i = 0; i < values.Length - 1; i++)
        {
            tree.Insert(int.Parse(values[i]));
        }

        tree.CheckBalanced();
    }

    public void Insert(int data)
    {
        root = InnerInsert(data, root);
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

    private void CheckBalanced()
    {
        Check(root, 0, 0);
    }

    private void Check(Node value, int left, int right)
    {
        Node previos = value;

        if (value == null)
        {
            return;
        }

        if ()

        Check(root.Left);
        Check(root.Right);
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

    private void CheckLeftSize(Node value)
    {
        if (value != null)
        {
            leftSize += 1;
        }

        if (value.Left != null)
        {
            CheckLeftSize(value.Left);
        }

        if (value.Right != null)
        {
            CheckLeftSize(value.Right);
        }
    }

    private void CheckRightSize(Node value)
    {
        if (value != null)
        {
            rightSize += 1;
        }

        if (value.Left != null)
        {
            CheckRightSize(value.Left);
        }

        if (value.Right != null)
        {
            CheckRightSize(value.Right);
        }
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
