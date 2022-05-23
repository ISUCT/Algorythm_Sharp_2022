using System;
using System.Collections.Generic;
using System.Linq;

public static class RadixSort
{
    public static void RadixSortMethod()
    {
        int size = int.Parse(Console.ReadLine());
        List<string> array = new List<string>();
        for (int i = 0; i < size; i++)
        {
            array.Add(Console.ReadLine());
        }

        Console.WriteLine("Initial array:");
        for (int i = 0; i < size; i++)
        {
            if (i < size - 1)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.WriteLine(array[i]);
            }
        }

        int grade = array[0].Length;
        array = Sort(array, grade);
        Console.WriteLine("**********");
        Console.WriteLine("Sorted array:");
        for (int i = 0; i < size; i++)
        {
            if (i < size - 1)
            {
                Console.Write(array[i] + ", ");
            }
            else
            {
                Console.WriteLine(array[i]);
            }
        }
    }

    public static List<string> Sort(List<string> array, int grade)
    {
        int phase = 1;
        int length = array[0].Length;

        foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (grade - 1)) / -1))).Select(x_1 => grade - 1 + (x_1 * -1)))
        {
            Console.WriteLine("**********");
            Console.WriteLine("Phase {0}", phase);

            List<string>[] bin = new List<string>[10];
            for (int t = 0; t < 10; t++)
            {
                bin[t] = new List<string>();
            }

            for (int j = 0; j < array.Count; j++)
            {
                int k = int.Parse(array[j].Substring(length - phase, 1));
                bin[k].Add(array[j]);
            }

            for (int j = 0; j < 10; j++)
            {
                if (bin[j].Count == 0)
                {
                    Console.WriteLine("Bucket {0}: empty", j);
                }
                else
                {
                    string outString = null;

                    for (int c = 0; c < bin[j].Count; c++)
                    {
                        if (c < bin[j].Count - 1)
                        {
                            outString += bin[j][c] + ", ";
                        }
                        else
                        {
                            outString += bin[j][c];
                        }
                    }

                    Console.WriteLine("Bucket {0}: {1}", j, outString);
                }
            }

            int p = 0;
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < bin[j].Count; k++)
                {
                    array[p] = bin[j][k];
                    p += 1;
                }
            }

            phase += 1;
        }

        return array;
    }
}