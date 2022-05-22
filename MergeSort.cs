using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static int[] Merge(int[] a, int[] b)
        {
            int idxA = 0;
            int idxB = 0;
            int k = 0;
            int[] c = new int[a.Length + b.Length];
            while (k < c.Length)
            {
                if (idxB == b.Length || (idxA < a.Length && a[idxA] < b[idxB]))
                {
                    c[k] = a[idxA];
                    idxA++;
                }
                else
                {
                    c[k] = b[idxB];
                    idxB++;
                }
                k++;
            }
            return c;
        }
        public static int[] Mergee(int[] v, int d, int s)
        {
            if (s - d == 1)
            {
                int[] res = new int[1];
                res[0] = v[d];
                return res;
            }

            int a = (d + s) / 2;

            int[] left = Mergee(v, d, a);
            int[] right = Mergee(v, a, s);

            int[] sort = Merge(left, right);

            Console.WriteLine("{0} {1} {2} {3}", d + 1, s, sort[0], sort[^1]);

            return Merge(left, right);
        }

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] v = line.Split(' ');
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(v[i]);
            }
            
            int[] sortM = Mergee(arr, 0, n);

            Console.WriteLine("{0}", string.Join(" ", sortM));
        }
    }
}


//int[] Merge(int[] a, int[] b)

