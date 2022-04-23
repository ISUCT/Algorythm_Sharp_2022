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

        var result = tree.GetValues();

        for (int i = 0; i < result.Count; i++)
        {
            Console.WriteLine(result[i]);
        }
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
        }

        public Node Left { get; set; }

        public Node Right { get; set; }

        public int Data { get; set; }
    }
}