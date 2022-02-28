using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class NumberOfDifferent
    {
        private static long count = 1;

        public static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] v = line.Split(' ');
            int[] arr = new int[x];
            int i;
            for (i = 0; i < x; i++)
            {
                arr[i] = int.Parse(v[i]);
            }
            Sort(arr, 0, x - 1);
            
            for (i = 1; i < x; i++)
            {
                if (arr[i - 1] != arr[i])
                {
                    count += 1;
                }
            }
            Console.WriteLine("{0}", count);
        }

        public static int Conditions(int[] arr, int left, int right)
        {
            int n = arr[left];
            int i = left - 1;
            int j = right + 1;

            while (true)
            {
                do
                {
                    i++;
                }
                while (arr[i] < n);

                do
                {
                    j--;
                }
                while (arr[j] > n);

                if (i >= j)
                {
                    return j;
                }

                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        public static void Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int num = Number(arr, left, right);

                Sort(arr, left, num);
                Sort(arr, num + 1, right);
            }
        }

    }
}
