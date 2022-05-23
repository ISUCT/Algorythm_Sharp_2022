using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class QuickSort
    {
        private static long count = 1;

        public static int Partition(int[] mas, int l, int r)
        {
            int x = mas[l];
            int i = l - 1, j = r + 1;

            while (true)
            {
                do
                {
                    i++;
                }
                while (mas[i] < x);

                do
                {
                    j--;
                }
                while (mas[j] > x);

                if (i >= j)
                {
                    return j;
                }

                int temp = mas[i];
                mas[i] = mas[j];
                mas[j] = temp;
            }
        }

        public static void QSort(int[] mas, int l, int r)
        {
            if (l < r)
            {
                int q = Partition(mas, l, r);

                QSort(mas, l, q);
                QSort(mas, q + 1, r);
            }
        }

        public static void Enter()
        {
            int n = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                mas[i] = int.Parse(sValues[i]);
            }

            QSort(mas, 0, n - 1);

            for (int i = 1; i < n; i++)
            {
                if (mas[i - 1] != mas[i])
                {
                    count += 1;
                }
            }

            Console.WriteLine("{0}", count);
        }
    }
}