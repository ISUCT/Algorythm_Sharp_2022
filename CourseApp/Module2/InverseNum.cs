using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class InverseNum
    {
        private static long count = 0;

        public static int[] Merge(int[] left, int[] right)
        {
            int i = 0, j = 0;
            int[] c = new int[left.Length + right.Length];
            for (int k = 0; k < c.Length; k++)
            {
                if (j == right.Length)
                {
                    c[k] = left[i];
                    i++;
                }
                else if (i == left.Length)
                {
                    c[k] = right[j];
                    j++;
                }
                else if (left[i] <= right[j])
                {
                    c[k] = left[i];
                    i++;
                }
                else
                {
                    c[k] = right[j];
                    j++;
                    count += left.Length - i;
                }
            }

            return c;
        }

        public static int[] MergeSort(int[] num, int l, int r)
        {
            if ((r - l) == 1)
            {
                int[] res = new int[1];
                res[0] = num[l];
                return res;
            }

            int m = (l + r) / 2;

            int[] left = MergeSort(num, l, m);
            int[] right = MergeSort(num, m, r);
            int[] sort = Merge(left, right);
            return sort;
        }
        public static void InverseNumMain()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string s = Console.ReadLine();
            string[] arrStr = s.Split(' ');
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = int.Parse(arrStr[i]);
            }

            int[] v_sorted = MergeSort(v, 0, n);

            Console.WriteLine($"{count}");
        }
    }
}