using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module2
{
    public class CountUnique
    {
        public static void DoCount()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            string[] bufferData = reader.ReadLine().Trim().Split(" ");
            reader.Close();
            Item[] data = new Item[size];
            int i = 0;
            foreach (var input in bufferData)
            {
                data[i] = new Item { Number = int.Parse(input) };
                i++;
            }

            IEnumerable<Item> noduplicates = data.Distinct();
            StreamWriter output = new StreamWriter("output.txt");
            int count = 0;
            foreach (var nmb in noduplicates)
            {
                count++;
            }

            output.WriteLine(count);
            output.Close();
        }
    }
}