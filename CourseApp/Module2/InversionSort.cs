using System;

namespace CourseApp.Module2
{
    public class InversionSort
    {
        private static long inversion = 0;

        public static int[] Merge(int[] a, int[] b)
        {
            int i = 0;
            int g = 0;
            int[] c = new int[a.Length + b.Length];
            for (int k = 0; k < c.Length; k++)
            {
                if (i == a.Length)
                {
                    c[k] = b[g];
                    g++;
                }
                else if (g == b.Length)
                {
                    c[k] = a[i];
                    i++;
                }
                else if (a[i] <= b[g])
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[g];
                    g++;
                    inversion += a.Length - i;
                }
            }

            return c;
        }

        public static int[] Merge_sort(int[] v, int lft, int rght)
        {
            if (rght - lft == 1)
            {
                int[] res = new int[1];
                res[0] = v[lft];
                return res;
            }

            int m = (lft + rght) / 2;

            int[] left = Merge_sort(v, lft, m);
            int[] right = Merge_sort(v, m, rght);

            int[] sort = Merge(left, right);

            return sort;
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

            int[] v_sorted = Merge_sort(arr, 0, n);

            Console.WriteLine(inversion);
        }
    }
}
