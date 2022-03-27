using System;
using System.Collections.Generic;

public class NearestSmaller
{
    public static void NearestSmallerMehod()
    {
        int size = int.Parse(Console.ReadLine());
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<int> linkedList = new List<int>(size);

        for (int i = 0; i < size; i++)
        {
            linkedList.Add(int.Parse(values[i]));
        }

        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size - (i + 1); j++)
            {
                if (linkedList[i] < linkedList[j])
                {
                    Console.Write(j + " ");
                }
                else
                {
                    Console.WriteLine(-1 + " ");
                }
            }
        }
    }
}
