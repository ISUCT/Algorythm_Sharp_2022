using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_1
{
    public class OneChildNode
    {
        public static void FindNode()
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

            List<int> ans = tree.GetElements();
            StreamWriter output = new StreamWriter("output.txt");
            foreach (var item in ans)
            {
                output.WriteLine(item);
            }

            output.Close();
        }
    }
}