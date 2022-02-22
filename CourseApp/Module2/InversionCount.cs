using System;

namespace CourseApp.Module2
{
    public class InversionCount
    {
        private static long count = 0;

        public static void CountInversion()
        {
            int[] arr = InputParse();
            ArrSort(ref arr);

            Console.WriteLine(count);
        }

        private static int[] Merge(ref int[] left, ref int[] right)
        {
            int i = 0;
            int j = 0;
            int[] add = new int[left.Length + right.Length];
            for (int k = 0; k < add.Length; k++)
            {
                if (j == right.Length || (i < left.Length && left[i] <= right[j]))
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

        private static int[] ArrSort(ref int[] arr)
        {
            if (arr.Length < 2)
            {
                return arr;
            }

            int mid = arr.Length / 2;

            int[] left = new int[mid];
            int[] right = new int[arr.Length - mid];

            for (int i = 0; i < left.Length; i++)
            {
                left[i] = arr[i];
            }

            for (int i = 0; i < right.Length; i++)
            {
                right[i] = arr[mid + i];
            }

            left = ArrSort(ref left);
            right = ArrSort(ref right);
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
