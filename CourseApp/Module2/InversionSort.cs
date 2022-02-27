using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class InversionSort
    {
        private static int count = 0;

        public static int[] Merge(int[] a, int[] b)
        {
            int i = 0;
            int j = 0;
            int[] res = new int[a.Length + b.Length];
            for (int k = 0; k < res.Length; k++)
            {
                if (i == a.Length)
                {
                    res[k] = b[j];
                    j++;
                }
                else if (j == b.Length)
                {
                    res[k] = a[i];
                    i++;
                }
                else if (a[i] <= b[j])
                {
                    res[k] = a[i];
                    i++;
                }
                else
                {
                    res[k] = b[j];
                    j++;
                    count += a.Length - i;
                }
            }

            return res;
        }

        public static int[] Merge_sort(int[] v, int l, int r)
        {
            if (r - l == 1)
            {
                int[] res = new int[1];
                res[0] = v[l];
                return res;
            }

            int m = (l + r) / 2;

            int[] left = Merge_sort(v, l, m);
            int[] right = Merge_sort(v, m, r);

            int[] sort = Merge(left, right);

            return sort;
        }

        public static void Enter()
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

            Console.WriteLine("{0}", count);
        }
    }
}