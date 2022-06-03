using System;

namespace CourseApp.Module2
{
    public class Numb_Diff
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

        public static int Partition(int[] array, int leftIndex, int rightIndex)
        {
            int i = leftIndex;
            int j = rightIndex - 1;
            int v = array[(leftIndex + rightIndex - 1) / 2];

            while (i <= j)
            {
                while (array[i] < v)
                {
                    i++;
                }

                while (array[j] > v)
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

        public static void QuickSort(int[] array, int leftIndex, int rightIndex)
        {
            if (rightIndex - leftIndex <= 1)
            {
                return;
            }

            int q = Partition(array, leftIndex, rightIndex);

            QuickSort(array, leftIndex, q);
            QuickSort(array, q, rightIndex);
        }
    } 
}