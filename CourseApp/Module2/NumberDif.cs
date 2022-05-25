using System;

namespace CourseApp.Module2
{
    public class NumberDif
    {
        public static void Count_Diff_Method()
        {
            int number = int.Parse(Console.ReadLine());
            string[] value = Console.ReadLine().Split(' ');
            int[] array = new int[number];

            for (int i = 0; i < number; ++i)
            {
                array[i] = int.Parse(value[i]);
            }

            QuickSort(array, 0, number);

            int count = 0;

            for (int i = 1; i < number; i++)
            {
                if (array[i] != array[i - 1])
                {
                    count++;
                }
            }

            Console.Write(count + 1);
        }

        public static int Partition(int[] array, int leftInd, int rightInd)
        {
            int i = leftInd;
            int j = rightInd - 1;
            int w = array[(leftInd + rightInd - 1) / 2];

            while (i <= j)
            {
                while (array[i] < w)
                {
                    i++;
                }

                while (array[j] > w)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }

            return j + 1;
        }

        public static void QuickSort(int[] array, int leftInd, int rightInd)
        {
            if (rightInd - leftInd <= 1)
            {
                return;
            }

            int v = Partition(array, leftInd, rightInd);

            QuickSort(array, leftInd, v);
            QuickSort(array, v, rightInd);
        }
    }
}