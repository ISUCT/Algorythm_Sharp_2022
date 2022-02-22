using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class NumbDiff
    {
        private static long count = 1;

        public static int Partition(int[] arr, int l, int r)
        {
            int p = arr[l];
            int i = l - 1, j = r + 1;

            while (true)
            {
                do
                {
                    i++;
                }
                while (arr[i] < p);

                do
                {
                    j--;
                }
                while (arr[j] > p);

                if (i >= j)
                {
                    return j;
                }

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        public static void QuickSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int q = Partition(arr, l, r);

                QuickSort(arr, l, q);
                QuickSort(arr, q + 1, r);
            }
        }

        public static void Try()
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
