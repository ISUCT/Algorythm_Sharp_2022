using System;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static int[] MergSrt(int[] a, int[] b)
        {
            int i = 0;
            int g = 0;
            int[] y = new int[a.Length + b.Length];
            for (int k = 0; k < y.Length; k++)
            {
                if (i == a.Length)
                {
                    y[k] = b[g];
                    g++;
                }
                else if (g == b.Length)
                {
                    y[k] = a[i];
                    i++;
                }
                else if (a[i] <= b[g])
                {
                    y[k] = a[i];
                    i++;
                }
                else
                {
                    y[k] = b[g];
                    g++;
                }
            }

            return y;
        }

        public static int[] MergeSrt1(int[] v, int l, int r)
        {
            if (r - l == 1)
            {
                int[] result = new int[1];
                result[0] = v[l];
                return result;
            }

            int m = (l + r) / 2;

            int[] left = MergeSrt1(v, l, m);
            int[] right = MergeSrt1(v, m, r);

            int[] sort = MergSrt(left, right);

            Console.WriteLine("{0} {1} {2} {3}", l + 1, r, sort[0], sort[^1]);

            return MergSrt(left, right);
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

            int[] v_sorted = MergeSrt1(arr, 0, n);

            Console.WriteLine("{0}", string.Join(" ", v_sorted));
        }
    }
}
