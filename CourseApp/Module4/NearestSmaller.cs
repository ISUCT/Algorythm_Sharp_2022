using System;

public class NearestSmaller
{
    public static void NearestSmallerMethod()
    {
        int size = int.Parse(Console.ReadLine());
        string[] values = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int j = 0;
        int[] result = new int[size];

        for (int i = size - 1; i >= 0; i--)
        {
            j = i + 1;
            while (j <= size - 1 && int.Parse(values[i]) <= int.Parse(values[j]))
            {
                j++;
            }

            if (j > size - 1)
            {
                result[i] = -1;
            }
            else
            {
                result[i] = j;
            }
        }
    }
}
