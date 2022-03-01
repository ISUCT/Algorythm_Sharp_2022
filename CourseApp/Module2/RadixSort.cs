using System;
using System.Collections.Generic;
using System.Linq;

public static class RadixSort
{
    public static void RadixSortMethod()
    {
        int number = int.Parse(Console.ReadLine());
        List<string> array = new List<string>();
        for (int i = 0; i < number; i++)
        {
            array.Add(Console.ReadLine());
        }

        Console.WriteLine("Initial array:");
        for (int i = 0; i < number; i++)
        {
            if (i < number - 1)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.WriteLine(array[i]);
            }
        }

        int rank = array[0].Length;
        array = Sort(array, rank);
        Console.WriteLine("**********");
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < number; i++)
        {
            if (i < number - 1)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.WriteLine(array[i]);
            }
        }
    }

    public static List<string> Sort(List<string> array, int rank)
    {
        int phase = 1;
        int len = array[0].Length;

        foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x_1 => rank - 1 + (x_1 * -1)))
        {
            Console.WriteLine("**********");
            Console.WriteLine("Phase {0}", phase);

            List<string>[] bins = new List<string>[10];
            for (int g = 0; g < 10; g++)
            {
                bins[g] = new List<string>();
            }

            for (int j = 0; j < array.Count; j++)
            {
                int k = int.Parse(array[j].Substring(len - phase, 1));
                bins[k].Add(array[j]);
            }

            for (int j = 0; j < 10; j++)
            {
                if (bins[j].Count == 0)
                {
                    Console.WriteLine("Bucket {0}: empty", j);
                }
                else
                {
                    string outStr = null;

                    for (int y = 0; y < bins[j].Count; y++)
                    {
                        if (y < bins[j].Count - 1)
                        {
                            outStr += bins[j][y] + ", ";
                        }
                        else
                        {
                            outStr += bins[j][y];
                        }
                    }

                    Console.WriteLine("Bucket {0}: {1}", j, outStr);
                }
            }

            int p = 0;
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < bins[j].Count; k++)
                {
                    array[p] = bins[j][k];
                    p += 1;
                }
            }

            phase += 1;
        }

        return array;
    }
}
