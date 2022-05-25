using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static void RadSort(string[] arr_string)
        {
            int numb_phaze = 1;
            int rank = arr_string[0].Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", arr_string));

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x_1 => rank - 1 + (x_1 * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", numb_phaze);
                ulong n;
                List<string>[] arrayList = new List<string>[10];
                for (n = 0; n < 10; n++)
                {
                    arrayList[n] = new List<string>();
                }

                for (int j = 0; j < arr_string.Length; j++)
                {
                    int k = int.Parse(arr_string[j].Substring(rank - numb_phaze, 1));
                    arrayList[k].Add(arr_string[j]);
                }

                for (n = 0; n < 10; n++)
                {
                    if (arrayList[n].Count == 0)
                    {
                        Console.WriteLine("Bucket " + n + ": empty");
                    }
                    else
                    {
                        Console.WriteLine("Bucket " + n + ": {0}", string.Join(", ", arrayList[n]));
                    }
                }

                int l = 0;

                for (n = 0; n < 10; n++)
                {
                    for (int j = 0; j < arrayList[n].Count; j++)
                    {
                        arr_string[l] = arrayList[n][j];
                        l++;
                    }
                }

                numb_phaze++;
            }

            Console.WriteLine("**********");
            Console.WriteLine("Sorted array:");
            Console.Write("{0}", string.Join(", ", arr_string));
        }

        public static void Start()
        {
            ulong m = ulong.Parse(Console.ReadLine());
            string[] arr_string = new string[m];
            for (ulong i = 0; i < m; i++)
            {
                arr_string[i] = Console.ReadLine();
            }

            RadSort(arr_string);
        }
    }
}
