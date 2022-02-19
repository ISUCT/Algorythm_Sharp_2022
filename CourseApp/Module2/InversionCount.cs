using System;

namespace CourseApp.Module2
{
    public class InversionCount
    {
        private static long count = 0;

        public static void CountInversion()
        {
            int[] arr = InputParse();

            int[] sortedArr = ArrSort(ref arr, 0, arr.Length);
            Console.WriteLine(count / 2);
        }

        public static int[] Merge(ref int[] left, ref int[] right)
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
                    count += left.Length - i;
                    add[k] = right[j];
                    j++;
                }
            }

            return add;
        }

        private static int[] ArrSort(ref int[] arr, int begin, int end)
        {
            if (end - begin == 1)
            {
                int[] res = new int[1];
                res[0] = arr[begin];
                return res;
            }

            int mid = (begin + end) / 2;

            int[] left = ArrSort(ref arr, begin, mid);
            int[] right = ArrSort(ref arr, mid, end);

            int[] sort = Merge(ref left, ref right);

            return Merge(ref left, ref right);
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
