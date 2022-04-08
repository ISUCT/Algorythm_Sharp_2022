using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class NumOfDiff
    {
        private static long count = 1;

        public static int Partition(int[] arr, int l, int r)
        {
            int i = l, j = r - 1;
            int v = arr[(l + r - 1) / 2];
            while (i <= j)
            {
                while (arr[i] < v)
                {
                    i++;
                }

                while (arr[j] > v)
                {
                    j--;
                }

                if (i >= j)
                {
                    break;
                }

                (arr[i], arr[j]) = (arr[j], arr[i]);
                i++;
                j--;
            }
            return (j + 1);
        }

        public static void quickSort(int[] arr, int l, int r)
        {
            if (r - l <= 1)
            {
                return;
            }
            int q = Partition(arr, l, r);

            quickSort(arr, l, q);
            quickSort(arr, q, r);

        }

        public static void NumOfDiffMain()
        {
            int n = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string[] sValues = str.Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            quickSort(arr, 0, n);

            for (int i = 1; i < n; i++)
            {
                if (arr[i - 1] != arr[i])
                {
                    count += 1;
                }
            }

            Console.WriteLine(count);
        }
    }
}
