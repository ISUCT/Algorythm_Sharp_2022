using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class NumbeкOfInversions
    {
        private static long count = 0;
        public static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] v = line.Split(' ');
            int[] arr = new int[x];
            for (int i = 0; i < x; i++)
            {
                arr[i] = int.Parse(v[i]);
            }
            int[] sortt = Mergee(arr, 0, x);
            Console.WriteLine(count);
        }
        public static int[] Merge(int[] a, int[] b)
        {
            int idxA = 0;
            int idxB = 0;
            int c;
            int[] k = new int[a.Length + b.Length];
            for (c = 0; c < k.Length; c++)
            {
                if (idxA == a.Length)
                {
                    k[c] = b[idxB];
                    idxB++;
                }
                else if (idxB == b.Length || a[idxA] <= b[idxB])
                {
                    k[c] = a[idxA];
                    idxA++;
                }
                else
                {
                    k[c] = b[idxB];
                    idxB++;
                    count += a.Length - idxA;
                }
            }

            return k;
        }

        public static int[] Mergee(int[] v, int l, int p)
        {
            if (p - l == 1)
            {
                int[] res = new int[1];
                res[0] = v[l];
                return res;
            }

            int ser = (l + p) / 2;
            int[] left = Mergee(v, l, ser);
            int[] right = Mergee(v, ser, p);
            int[] sort = Merge(left, right);

            return sort;
        }
    }
}

