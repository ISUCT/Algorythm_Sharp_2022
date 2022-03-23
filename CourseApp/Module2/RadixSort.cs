using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
   public class RadixSort
    {
        public static void RadixSortMethod()
        {
            int[] arr = InputParse();
            int max = GetMax(arr, arr.Length);
            int times = GetTimes(max);
        }

        private static int[] InputParse()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }

            return arr;
        }

        private static int GetMax(int[] arr, int n)
        {
            int max = arr[0];
            for (int i = 1; i < n; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            return max;
        }

        private static int GetTimes(int max)
        {
            int count = 0;
            while (max > 0)
            {
                max /= 10;
                count++;
            }

            return count;
        }

        private static int[] CountElements(ref int[] arr, int min, int max)
        {
            int length = (max - min) + 1;
            int[] add = new int[length];

            for (int i = 0; i < arr.Length; i++)
            {
                add[arr[i] - min]++;
            }

            return add;
        }
    }
}
