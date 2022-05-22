using System;

public class InversionCounter
{
    private static long inversionCount = 0;

    public static void InversionCounterMethod()
    {
        MergeSort2();
    }

    public static void MergeSort2()
    {
        int number = int.Parse(Console.ReadLine());
        if (number > 1)
        {
            string temp = Console.ReadLine();
            string[] values = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] array = new int[number];
            for (int i = 0; i < values.Length; i++)
            {
                array[i] = int.Parse(values[i]);
            }

            int[] result = Sort(array, 0, number);
            Console.WriteLine(inversionCount);
        }
        else
        {
            Console.WriteLine(0);
        }
    }

    public static int[] Merge(int[] left, int[] right)
    {
        int i = 0;
        int j = 0;
        int[] result = new int[left.Length + right.Length];

        for (int k = 0; k < result.Length; k++)
        {
            if (i == left.Length)
            {
                result[k] = right[j];
                j++;
            }
            else if (j == right.Length)
            {
                result[k] = left[i];
                i++;
            }
            else if (left[i] <= right[j])
            {
                result[k] = left[i];
                i++;
            }
            else
            {
                result[k] = right[j];
                j++;
                inversionCount += left.Length - i;
            }
        }

        return result;
    }

    public static int[] Sort(int[] array, int firstIndex, int lastIndex)
    {
        if (lastIndex - firstIndex == 1)
        {
            int[] res = new int[1];
            res[0] = array[firstIndex];
            return res;
        }

        int m = (firstIndex + lastIndex) / 2;

        int[] left = Sort(array, firstIndex, m);
        int[] right = Sort(array, m, lastIndex);

        return Merge(left, right);
    }
}