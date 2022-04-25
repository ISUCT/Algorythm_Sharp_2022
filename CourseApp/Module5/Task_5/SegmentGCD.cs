using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_5
{
    public class SegmentGCD
    {
        public static void FindGCD()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            int[] numbers = reader.ReadLine().Trim().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int query_count = int.Parse(reader.ReadLine());
            DynamicSegmentTree tree = new DynamicSegmentTree(size);
            tree.Build(numbers);
            List<int> res = new List<int>();
            for (int i = 0; i < query_count; i++)
            {
                string[] borders = reader.ReadLine().Trim().Split(' ').ToArray();
                if (borders[0] == "u")
                {
                    tree.Update(int.Parse(borders[1]), int.Parse(borders[2]));
                }
                else
                {
                    res.Add(tree.GetGCD(int.Parse(borders[1]), int.Parse(borders[2])));
                }
            }

            reader.Close();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(string.Join(" ", res));
            output.Close();
        }
    }
}