using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static void MergeSortMethod()
        {
            int[] arr = InputParse();

            int[] vSorted = ArrSort(arr, 0, arr.Length);

            Console.WriteLine("{0}", string.Join(" ", vSorted));
        }

        public static int[] Merge(int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int[] add = new int[left.Length + right.Length];
            for (int k = 0; k < add.Length; k++)
            {
                if (i == left.Length)
                {
                    add[k] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    add[k] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    add[k] = left[i];
                    i++;
                }
                else
                {
                    add[k] = right[j];
                    j++;
                }
            }

            return add;
        }

        private static int[] ArrSort(int[] arr, int begin, int end)
        {
            if (end - begin == 1)
            {
                int[] res = new int[1];
                res[0] = arr[begin];
                return res;
            }

            int mid = (begin + end) / 2;

            int[] left = ArrSort(arr, begin, mid);
            int[] right = ArrSort(arr, mid, end);

            int[] sort = Merge(left, right);

            Console.WriteLine("{0} {1} {2} {3}", begin + 1, end, sort[0], sort[^1]);

            return Merge(left, right);
        }

        private static int[] InputParse()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            return arr;
        }
    }
}