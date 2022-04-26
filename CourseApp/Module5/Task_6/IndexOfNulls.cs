using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_6
{
    public class IndexOfNulls
    {
        public static void CheckIndexs()
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
                string[] comands = reader.ReadLine().Trim().Split(' ').ToArray();
                if (comands[0] == "u")
                {
                    int first = int.Parse(comands[1]);
                    int second = int.Parse(comands[2]);
                    if ((numbers[first - 1] != 0 && second == 0) || (numbers[first - 1] == 0 && second != 0))
                    {
                        bool add_or_del = (numbers[first - 1] != 0 && second == 0) ? true : false;
                        numbers[first - 1] = second;
                        tree.Update(first, add_or_del);
                    }
                }
                else
                {
                    res.Add(tree.GetIndex(int.Parse(comands[1]), int.Parse(comands[2]), int.Parse(comands[3])));
                }
            }

            reader.Close();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(string.Join(" ", res));
            output.Close();
        }
    }
}