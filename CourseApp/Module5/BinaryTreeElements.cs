using System;
using System.Collections.Generic;

public class BinaryTreeElements
{
    private Node root;
    private List<int> values;

    public int Size { get; }

    public static void BinaryTreeElementsMethod()
    {
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var tree = new BinaryTreeElements();

        for (int i = 0; i < values.Length - 1; i++)
        {
            tree.Insert(int.Parse(values[i]));
        }

        tree.FindLastElements();
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

    private void FindLastElements()
    {
        LastElements(root);
    }

    private void LastElements(Node value)
    {
        if (value == null)
        {
            return;
        }

        LastElements(value.Left);

        if ((value.Left != null && value.Right == null) || (value.Right != null && value.Left == null))
        {
            Console.WriteLine(value.Data);
        }

        LastElements(value.Right);
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