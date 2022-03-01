using System;

namespace CourseApp.Module2
{
    public class Task4
    {
        private static long inversion = 0;

        public static int[] MergSort(int[] a, int[] b)
        {
            int c = 0;
            int d = 0;
            int[] arr = new int[a.Length + b.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (c == a.Length)
                {
                    arr[i] = b[d];
                    d++;
                }
                else if (d == b.Length)
                {
                    arr[i] = a[c];
                    c++;
                }
                else if (a[c] <= b[d])
                {
                    arr[i] = a[c];
                    c++;
                }
                else
                {
                    arr[i] = b[d];
                    d++;
                    inversion += a.Length - c;
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

        public static void ClassMain()
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

            Console.WriteLine(inversion);
        }
    }
}