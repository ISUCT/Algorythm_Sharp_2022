using System;
using System.IO;
using System.Linq;

namespace CourseApp.Module4
{
    public class SegmentionsMin
    {
        public static void FindWinMin()
        {
            StreamReader reader = new StreamReader("input.txt");
            int[] sizes = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            int n_size = sizes[0];
            int k_size = sizes[1];
            int[] numbers = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();
            Deque mins = new Deque(n_size);
            for (int i = 0; i < k_size; i++)
            {
                int current = numbers[i];
                while (!mins.Empty() && mins.Back() > current)
                {
                    mins.PopBack();
                }

                mins.PushBack(current);
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(mins.Front());
            for (int i = k_size; i < n_size; i++)
            {
                int current = numbers[i];
                int remove = numbers[i - k_size];
                while (!mins.Empty() && mins.Back() > current)
                {
                    mins.PopBack();
                }

                mins.PushBack(current);
                if (!mins.Empty() && mins.Front() == remove)
                {
                    mins.PopFront();
                }

                output.WriteLine(mins.Front());
            }

            output.Close();
        }
    }
}