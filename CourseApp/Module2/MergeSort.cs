using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static int[] merge(int[] left, int[] right)
        {
            int i = 0, j = 0;
            int[] c = new int[left.Length + right.Length];
            for (int k = 0; k < c.Length; k++)
            {
                if ((j == right.Length) || (i < left.Length && left[i] < right[j]))
                {
                    c[k] = left[i];
                    i++;
                }
                else
                {
                    c[k] = right[j];
                    j++;
                }
            }

            return c;
        }
        public static int[] mergeSort(int[] num, int l, int r)
        {
            if ((r - l) == 1)
            {
                int[] res = new int[1];
                res[0] = num[l];
                return res;
            }
            int m = (l + r) / 2;

            int[] left = mergeSort(num, l, m);
            int[] right = mergeSort(num, m, r);
            int[] sort = merge(left, right);
            Console.WriteLine($"{l + 1} {r} {sort[0]} {sort[^1]}");
            return sort;
        }
        public static void MergeSortMain()
        {
            int n = int.Parse(Console.ReadLine());
            int[] v = new int[n];
            string s = Console.ReadLine();
            string[] arrStr = s.Split(' ');
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = int.Parse(arrStr[i]);
            }
            int[] v_sorted = mergeSort(v, 0, n);

            Console.WriteLine(string.Join(" ", v_sorted));
        }
    }
}
