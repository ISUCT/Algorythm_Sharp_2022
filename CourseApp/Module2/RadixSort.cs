using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static ulong GetMax(string[] arr_string, ulong n)
        {
            ulong max = ulong.Parse(arr_string[0]);
            for (ulong i = 1; i < n; i++)
            {
                if (ulong.Parse(arr_string[i]) > max)
                {
                    max = ulong.Parse(arr_string[i]);
                }
            }

            return max;
        }

        public static string[] CountSort(string[] arr_string, ulong n, ulong exp)
        {
            ulong i;
            List<string>[] arrayList = new List<string>[10];
            for (i = 0; i < 10; i++)
            {
                arrayList[i] = new List<string>();
            }

            for (i = 0; i < n; i++)
            {
                arrayList[(ulong.Parse(arr_string[i]) / exp) % 10].Add(arr_string[i]);
            }

            for (i = 0; i < 10; i++)
            {
                if (arrayList[i].Count == 0)
                {
                    Console.WriteLine("Bucket " + i + ": empty");
                }
                else
                {
                    Console.WriteLine("Bucket " + i + ": {0}", string.Join(", ", arrayList[i]));
                }
            }

            int l = 0;

            for (i = 0; i < 10; i++)
            {
                for (int j = 0; j < arrayList[i].Count; j++)
                {
                    arr_string[l] = arrayList[i][j];
                    l++;
                }
            }

            return arr_string;
        }

        public static void Radixsort(string[] arr_string, ulong n)
        {
            ulong m = GetMax(arr_string, n);
            ulong numb_phaze = 1;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", arr_string));

            for (ulong exp = 1; m / exp > 0 && numb_phaze < 21; exp *= 10)
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", numb_phaze);
                arr_string = CountSort(arr_string, n, exp);
                numb_phaze++;
            }

            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.Write("{0}", string.Join(", ", arr_string));
        }

        public static void Try()
        {
            ulong n = ulong.Parse(Console.ReadLine());
            string[] arr_string = new string[n];
            for (ulong i = 0; i < n; i++)
            {
                arr_string[i] = Console.ReadLine();
            }

            Radixsort(arr_string, n);
        }
    }
}
