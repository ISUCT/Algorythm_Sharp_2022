using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module4
{
    public class NearestMin
    {
        public static void NearestMinMethod()
        {
            int size = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
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
                if (buf1 <= n_mins.Peek())
                {
                    while ((!n_mins.Empty()) ? buf1 <= n_mins.Peek() : false)
                    {
                        temp += del.Peek() + 1;
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

            Console.WriteLine(string.Join(" ", res));
        }
    }
}
