using System;

namespace CourseApp
{
    public class Merge
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            int[] aSorted = MergeSorting(arr, n, 0);

            Console.WriteLine("{0}", string.Join(" ", aSorted));
        }

        public static int[] MergeSorting(int[] arr, int n, int k)
        {
            if ((n - k) == 1)
            {
                int[] result = new int[1];
                result[0] = arr[k];
                return result;
            }

            int b = (n + k) / 2;

            int[] left = MergeSorting(arr, b, k);
            int[] right = MergeSorting(arr, n, b);
            int[] sort = Sorting(left, right);
            //                                                   ^1-последний элемент, первый с конца
            //                                                   ^2-предпоследний элемент, второй с конца
            Console.WriteLine("{0} {1} {2} {3}", k + 1, n, sort[0], sort[^1]);

            return sort;
        }

        public static int[] Sorting(int[] a, int[] b)
        {
            int idxA = 0;
            int idxB = 0;
            int k = 0;
            int[] result = new int[a.Length + b.Length];
            while (k < result.Length)
            {
                // || - или     && - и
                if (idxB == b.Length || (idxA < a.Length && a[idxA] < b[idxB]))
                {
                    result[k] = a[idxA];
                    idxA++;
                }
                else
                {
                    result[k] = b[idxB];
                    idxB++;
                }

                k++;
            }

            return result;
        }
    }
}