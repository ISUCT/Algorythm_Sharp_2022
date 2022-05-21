using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_4
{
    public class IndexOfNulls
    {
        public static void CheckIndexs()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            int[] numbers = reader.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int query_count = int.Parse(reader.ReadLine());
            SegmentTree tree = new SegmentTree(size);
            tree.Build(numbers);
            List<int> res = new List<int>();
            for (int i = 0; i < query_count; i++)
            {
                int[] comands = reader.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                res.Add(tree.GetIndex(comands[0], comands[1], comands[2]));
            }

            reader.Close();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(string.Join(" ", res));
            output.Close();
        }
    }
}