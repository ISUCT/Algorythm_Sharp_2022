using System;

namespace CourseApp.Module2
{
    public class InversionCount
    {
        private static long inversionCount = 0;

        public static void Start()
        {
            int v = int.Parse(Console.ReadLine());
            if (v > 1)
            {
                string temp = Console.ReadLine();
                string[] values = temp.Split(' ');
                int[] array = new int[v];
                for (int i = 0; i < values.Length; i++)
                {
                    array[i] = int.Parse(values[i]);
                }

                int[] result = Sort(array, 0, v);
                Console.WriteLine(inversionCount);
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        public static int[] Sort(int[] array, int firstInd, int lastInd)
        {
            if (lastInd - firstInd == 1)
            {
                int[] res = new int[1];
                res[0] = array[firstInd];
                return res;
            }

            int w = (firstInd + lastInd) / 2;

            int[] left = Sort(array, firstInd, w);
            int[] right = Sort(array, w, lastInd);

            return Merge(left, right);
        }

        public static int[] Merge(int[] left, int[] right)
        {
            int i = 0;
            int j = 0;
            int[] result = new int[left.Length + right.Length];

            for (int n = 0; n < result.Length; n++)
            {
                if (i == left.Length)
                {
                    result[n] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    result[n] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    result[n] = left[i];
                    i++;
                }
                else
                {
                    result[n] = right[j];
                    j++;
                    inversionCount += left.Length - i;
                }
            }

            return result;
        }
    }
}