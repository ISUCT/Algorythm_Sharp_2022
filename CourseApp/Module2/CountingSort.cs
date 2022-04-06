using System;

namespace CourseApp.Module2
{
    public class CountingSort
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] warehouse = new int[n];
            for (int i = 0; i < n; i++)
            {
                warehouse[i] = int.Parse(sValues[i]);
            }

            int k = int.Parse(Console.ReadLine());
            string p = Console.ReadLine();
            string[] pValues = p.Split(' ');
            int[] orders = new int[k];
            for (int i = 0; i < k; i++)
            {
                orders[i] = int.Parse(pValues[i]);
            }

            int[] aSorted = CountingSorting(orders, k, n);

            // Console.WriteLine("{0}", string.Join(" ", aSorted));
            Counting(aSorted, warehouse, n);
        }

        public static int[] CountingSorting(int[] arr, int k, int n)
        {
            int[] sort = new int[n];
            for (int i = 0; i < k; i++)
            {
                sort[arr[i] - 1]++;
            }

            return sort;
        }

        public static int[] Counting(int[] sort, int[] wareh, int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (sort[i] > wareh[i])
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }
            }

            return sort;
        }
    }
}