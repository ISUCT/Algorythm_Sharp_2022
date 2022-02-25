using System;

public class MergeSort
{
    public static void MergeSortMethod()
    {
        int number = int.Parse(Console.ReadLine());
        string temp = Console.ReadLine();
        string[] values = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] array = new int[number];
        for (int i = 0; i < values.Length; i++)
        {
            array[i] = int.Parse(values[i]);
        }

        int[] result = Sort(array, 0, number);
        for (int i = 0; i < result.Length; i++)
        {
            Console.Write(result[i] + " ");
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
        int[] result = Merge(left, right);

        Console.WriteLine(firstIndex + 1 + " " + lastIndex + " " + result[0] + " " + result[^1]);

        return Merge(left, right);
    }
}
