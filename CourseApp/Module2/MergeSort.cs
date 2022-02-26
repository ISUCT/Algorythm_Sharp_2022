using System;
using System.Linq;

namespace CourseApp.Module2;

public class MergeSort
{
    public static void Sort()
    {
        var array = InputHandler.ArrayHandler();
        var sortedArray = Sort(array);
        Console.WriteLine(string.Join(" ", sortedArray));
    }

    private static int[] Sort(int[] array)
    {
        if (array.Length > 1)
        {
            int mid = array.Length / 2;
            var leftArray = array[new Range(Index.Start, mid)];
            var rightArray = array[new Range(mid, Index.End)];
            if (leftArray.Length > 1)
            {
                leftArray = Sort(leftArray);
            }

            if (rightArray.Length > 1)
            {
                rightArray = Sort(rightArray);
            }

            array = Merge(leftArray, rightArray);
        }

        return array;
    }

    private static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[right.Length + left.Length];

        int indexLeft = 0,
            indexRight = 0,
            indexResult = 0;

        while (indexLeft < left.Length || indexRight < right.Length)
        {
            if (indexLeft < left.Length && indexRight < right.Length)
            {
                if (left[indexLeft] <= right[indexRight])
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                else
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            else if (indexLeft < left.Length)
            {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            else if (indexRight < right.Length)
            {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }

        return result;
    }
}