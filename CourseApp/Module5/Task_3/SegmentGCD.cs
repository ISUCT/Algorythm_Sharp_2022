using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_3
{
    public class SegmentGCD
    {
        public static void FindGCD()
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
                int[] borders = reader.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
                res.Add(tree.GetGCD(borders[0], borders[1]));
            }

            reader.Close();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(string.Join(' ', res));
            output.Close();
        }
    }
}