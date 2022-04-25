using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_2
{
    public class CheckBalancedTree
    {
        public static void CheckTree()
        {
            StreamReader reader = new StreamReader("input.txt");
            int[] numbers = reader.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();
            BinaryTree tree = new BinaryTree();
            foreach (var item in numbers)
            {
                if (item != 0)
                {
                    tree.Insert(item);
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(tree.IsBalanced() ? "YES" : "NO");
            output.Close();
        }
    }
}