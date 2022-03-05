using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static string[] CountSort(string[] arr_string, int phase, int len)
        {
            ulong i;
            List<string>[] arrayList = new List<string>[10];
            for (int g = 0; g < 10; g++)
            {
                arrayList[g] = new List<string>();
            }

            for (int j = 0; j < arr_string.Length; j++)
            {
                int k = int.Parse(arr_string[j].Substring(len - phase, 1));
                arrayList[k].Add(arr_string[j]);
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
            int numb_phaze = 1;
            int rank = arr_string[0].Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", arr_string));

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x_1 => rank - 1 + (x_1 * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", numb_phaze);
                arr_string = CountSort(arr_string, numb_phaze, rank);
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
