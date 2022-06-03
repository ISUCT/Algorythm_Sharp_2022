using System;


namespace CourseApp.Module2
{
    public class Merge_Sort
    {
        public static int[] Merge(int[] a, int[] b)
        {
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
                }
            }

            return c;
        }

        public static int[] MergeSort(int[] v, int left, int right)
        {
            if (right - left == 1)
            {
                int[] res = new int[1];
                res[0] = v[left];
                return res;
            }

            int m = (left + right) / 2;

            int[] left_half = MergeSort(v, left, m);
            int[] right_half = MergeSort(v, m, right);

            int[] sorting = Merge(left_half, right_half);

            Console.WriteLine("{0} {1} {2} {3}", left + 1, right, sorting[0], sorting[^1]);

            return Merge(left_half, right_half);
        }

        public static void Enter()
        {
            int numbers = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();
            string[] sValues = str.Split(' ');
            int[] arr = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            int[] sorted_arr = MergeSort(arr, 0, numbers);

            Console.WriteLine("{0}", string.Join(" ", sorted_arr));
        }
    }
}
