using System;

namespace CourseApp.Module2;

public class MergeSort
{
    public static void Sort()
    {
        var array = InputHandler.ArrayHandler();
        Sort(array);
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
                Console.Write(array[0] + " " + array[^1]);
            }

            if (rightArray.Length > 1)
            {
                rightArray = Sort(rightArray);
            }

            array = Merge(leftArray, rightArray);
        }

        Console.WriteLine(array[0] + " " + array[^1]);
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