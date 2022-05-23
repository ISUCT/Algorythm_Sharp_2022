using System;

namespace CourseApp.Module2
{
    public class NumbDiff
    {
        private static long count = 1;

        public static int Partition(int[] arr, int left, int right)
        {
            int p = arr[left];
            int i = left - 1, g = right + 1;

            while (true)
            {
                do
                {
                    i++;
                }
                while (arr[i] < p);

                do
                {
                    g--;
                }
                while (arr[g] > p);

                if (i >= g)
                {
                    return g;
                }

                int temp = arr[i];
                arr[i] = arr[g];
                arr[g] = temp;
            }
        }

        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int q = Partition(arr, left, right);

                QuickSort(arr, left, q);
                QuickSort(arr, q + 1, right);
            }
        }

        public static void ClassMain()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            QuickSort(arr, 0, n - 1);

            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] != arr[i])
                {
                    count += 1;
                }
            }

            Console.WriteLine("{0}", count);
        }
    }
}
