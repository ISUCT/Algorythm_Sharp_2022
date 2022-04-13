using System;
using System.IO;
using System.Linq;

namespace CourseApp.Module4
{
    public class TrainSort
    {
        public static void Sort()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            int[] train = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();

            int[] sorted_train = new int[size];
            int buffer = 0;
            int search = 1;
            Stack sort_vein = new Stack(size);
            for (int i = 0; i < size; i++)
            {
                sort_vein.Push(train[i]);
                if (train[i] == search)
                {
                    sorted_train[buffer] = sort_vein.Back();
                    sort_vein.Pop();
                    buffer++;
                    search++;
                    while (sort_vein.Empty() ? false : sort_vein.Back() == search)
                    {
                        sorted_train[buffer] = sort_vein.Back();
                        sort_vein.Pop();
                        buffer++;
                        search++;
                    }
                }
            }

            bool trigger = true;
            for (int i = 0; i < size - 1; i++)
            {
                if (sorted_train[i] > sorted_train[i + 1])
                {
                    trigger = false;
                    break;
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(trigger ? "YES" : "NO");
            output.Close();
        }
    }
}