using System;
using System.IO;
using System.Linq;

namespace CourseApp.Module4
{
    public class NearestMin
    {
        public static void FindNearMin()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            int[] numbers = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();

            int[] res = new int[size];
            Stack n_mins = new Stack(size);
            n_mins.Push(numbers[size - 1]);
            res[size - 1] = -1;
            Stack del = new Stack(size);
            del.Push(0);
            for (int i = size - 2; i >= 0; i--)
            {
                int temp = 0;
                int buf1 = numbers[i];
                if (buf1 <= n_mins.Back())
                {
                    while ((!n_mins.Empty()) ? buf1 <= n_mins.Back() : false)
                    {
                        temp += del.Back() + 1;
                        del.Pop();
                        n_mins.Pop();
                    }

                    if (n_mins.Empty())
                    {
                        res[i] = -1;
                        del.Push(0);
                    }
                    else
                    {
                        res[i] = i + temp + 1;
                    }
                }
                else
                {
                    res[i] = i + 1;
                }

                n_mins.Push(buf1);
                del.Push(temp);
            }

            n_mins.Clear();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(string.Join(" ", res));
            output.Close();
        }
    }
}