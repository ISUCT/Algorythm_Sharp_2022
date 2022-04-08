using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Number_of_different
    {
        private static long inversion = 0;

        public static int[] MergSort(int[] a, int[] b)
        {
            int x = 0;
            int y = 0;
            int[] arr = new int[a.Length + b.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (x == a.Length)
                {
                    arr[i] = b[y];
                    y++;
                }
                else if (y == b.Length)
                {
                    arr[i] = a[x];
                    x++;
                }
                else if (a[x] <= b[y])
                {
                    arr[i] = a[x];
                    x++;
                }
                else
                {
                    arr[i] = b[y];
                    y++;
                    inversion += a.Length - x;
                }
            }

            return arr;
        }

        public static int[] MergeSort1(int[] x, int l, int r)
        {
            if (r - l == 1)
            {
                int[] result = new int[1];
                result[0] = x[l];
                return result;
            }

            int m = (l + r) / 2;

            int[] left = MergeSort1(x, l, m);
            int[] right = MergeSort1(x, m, r);

            int[] sort = MergSort(left, right);

            return sort;
        }

        public static void ClassMainNumb()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string str = Console.ReadLine();
            string[] str_value = str.Split(' ');
            int[] arr = new int[n];
            for (int j = 0; j < n; j++)
            {
                arr[j] = Convert.ToInt32(str_value[j]);
            }

            int[] arr_sorted = MergeSort1(arr, 0, n);

            int count = 1;
            for (int i = 1; i < arr_sorted.Length; i++)
            {
                if (arr_sorted[i - 1] != arr_sorted[i])
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}