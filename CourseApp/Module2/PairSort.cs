using System;

namespace CourseApp.Tests.Module2
{
    public class PairSort
    {
        public static void PairSortMethod()
        {
            int n = int.Parse(Console.ReadLine());
            // для массивов больше ранга 1 в скобках нужна [,]
            int[,] pair = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string[] sValues = s.Split(' ');
                pair[i, 0] = int.Parse(sValues[0]);
                pair[i, 1] = int.Parse(sValues[1]);
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (pair[j, 1] < pair[j + 1, 1])
                    {
                        (pair[j, 1], pair[j + 1, 1]) = (pair[j + 1, 1], pair[j, 1]);
                        (pair[j, 0], pair[j + 1, 0]) = (pair[j + 1, 0], pair[j, 0]);
                    }
                    else if (pair[j, 1] == pair[j + 1, 1])
                    {
                        if (pair[j, 0] > pair[j + 1, 0])
                        {
                            (pair[j, 1], pair[j + 1, 1]) = (pair[j + 1, 1], pair[j, 1]);
                            (pair[j, 0], pair[j + 1, 0]) = (pair[j + 1, 0], pair[j, 0]);
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("{0} {1}", pair[i, 0], pair[i, 1]);
            }
        }

        /*
        public static void Main(string[] args)
        {
            PairSortMethod();
        }
        */
    }
}
