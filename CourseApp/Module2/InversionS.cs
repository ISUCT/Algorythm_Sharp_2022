using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class InversionS
    {
        private static long invers = 0;

        public static int[] MergInversion(int[] a, int[] b)
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
                    invers += a.Length - i;
                }
            }

            return y;
        }

        public static int[] MergeIn(int[] v, int l, int r)
        {
            if (r - l == 1)
            {
                int[] result = new int[1];
                result[0] = v[l];
                return result;
            }

            int m = (l + r) / 2;

            int[] left = MergeIn(v, l, m);
            int[] right = MergeIn(v, m, r);

            int[] sort = MergInversion(left, right);
            return sort;
        }

        public static void MergeMain()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            int[] v_sorted = MergeIn(arr, 0, n);

            Console.WriteLine(invers);
        }
    }
}