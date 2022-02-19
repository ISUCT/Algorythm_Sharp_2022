using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class InversionSort
    {
        public static (int[], int) Merge(int[] a, int[] b)
        {
            int inversion = 0;
            int i = 0;
            int j = 0;
            int[] c = new int[a.Length + b.Length];
            for (int k = 0; k < c.Length; k++)
            {
                if (i == a.Length)
                {
                    c[k] = b[j];
                    j++;
                }
                else if (j == b.Length)
                {
                    c[k] = a[i];
                    i++;
                }
                else if (a[i] <= b[j])
                {
                    c[k] = a[i];
                    i++;
                }
                else
                {
                    c[k] = b[j];
                    j++;
                    inversion += a.Length - i;
                }
            }

            return (c, inversion);
        }

        public static (int[], int) Merge_sort(int[] v, int l, int r)
        {
            if (r - l == 1)
            {
                int[] res = new int[1];
                res[0] = v[l];
                return (res, 0);
            }

            int inversion = 0;
            int left_inversion = 0;
            int right_inversion = 0;
            int m = (l + r) / 2;

            (int[] left, left_inversion) = Merge_sort(v, l, m);
            (int[] right, right_inversion) = Merge_sort(v, m, r);

            (int[] sort, inversion) = Merge(left, right);

            return (sort, left_inversion + inversion + right_inversion);
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

            int inversion = 0;

            (int[] v_sorted, inversion) = Merge_sort(arr, 0, n);

            Console.WriteLine(inversion);
        }
    }
}
