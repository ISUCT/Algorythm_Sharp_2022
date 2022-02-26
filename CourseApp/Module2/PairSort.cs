using System;

namespace Module2
{
    public class PairSort
    {
        public static void Sort()
        {
            int countPair = Convert.ToInt32(Console.ReadLine());
            int[,] pairs = new int[countPair, 2];
            for (int i = 0; i < countPair; i++)
            {
                var lol = Console.ReadLine().Split(" ");
                pairs[i, 0] = Convert.ToInt32(lol[0]);
                pairs[i, 1] = Convert.ToInt32(lol[1]);
            }

            for (int i = 0; i < (pairs.Length / 2); ++i)
            {
                for (int j = 0; j < (pairs.Length / 2) - i - 1; ++j)
                {
                    if (pairs[j, 1] < pairs[j + 1, 1])
                    {
                        (pairs[j, 0], pairs[j + 1, 0]) = (pairs[j + 1, 0], pairs[j, 0]);
                        (pairs[j, 1], pairs[j + 1, 1]) = (pairs[j + 1, 1], pairs[j, 1]);
                    }
                    else if (pairs[j, 1] == pairs[j + 1, 1])
                    {
                        if (pairs[j, 0] > pairs[j + 1, 0])
                        {
                            (pairs[j, 0], pairs[j + 1, 0]) = (pairs[j + 1, 0], pairs[j, 0]);
                            (pairs[j, 1], pairs[j + 1, 1]) = (pairs[j + 1, 1], pairs[j, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < pairs.Length / 2; i++)
            {
                Console.WriteLine($"{pairs[i, 0]} {pairs[i, 1]}");
            }
        }
    }
}