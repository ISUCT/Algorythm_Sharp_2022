using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Radix_Sort
    {
        
        public static void RadixSort(string[] arr_string, ulong n)
        {
            int numb_phaze = 1;
            int rank = arr_string[0].Length;

            Console.WriteLine("Initial array:");
            Console.WriteLine("{0}", string.Join(", ", arr_string));

            foreach (var i in Enumerable.Range(0, Convert.ToInt32(Math.Ceiling(Convert.ToDouble(-1 - (rank - 1)) / -1))).Select(x_1 => rank - 1 + (x_1 * -1)))
            {
                Console.WriteLine("**********");
                Console.WriteLine("Phase {0}", numb_phaze);
                ulong m;
                List<string>[] arrayList = new List<string>[10];
                for (m = 0; m < 10; m++)
                {
                    arrayList[m] = new List<string>();
                }

                for (int j = 0; j < arr_string.Length; j++)
                {
                    int k = int.Parse(arr_string[j].Substring(rank - numb_phaze, 1));
                    arrayList[k].Add(arr_string[j]);
                }

                for (m = 0; m < 10; m++)
                {
                    if (arrayList[m].Count == 0)
                    {
                        Console.WriteLine("Bucket " + m + ": empty");
                    }
                    else
                    {
                        Console.WriteLine("Bucket " + m + ": {0}", string.Join(", ", arrayList[m]));
                    }
                }

                int l = 0;

                for (m = 0; m < 10; m++)
                {
                    for (int j = 0; j < arrayList[m].Count; j++)
                    {
                        arr_string[l] = arrayList[m][j];
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
            ulong n = ulong.Parse(Console.ReadLine());
            string[] arr_string = new string[n];
            for (ulong i = 0; i < n; i++)
            {
                arr_string[i] = Console.ReadLine();
            }

            RadixSort(arr_string, n);
        }
    }
}
