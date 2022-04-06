using System;
using System.Linq;

namespace CourseApp.Module2
{
    public class RadixSort
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            long[] array = new long[n];
            for (long i = 0; i < n; i++)
            {
                array[i] = long.Parse(Console.ReadLine());
            }

            long r = array.Max<long>();
            int kol = 0;
            while (r != 0)
            {
                r = r / 10;
                kol++;
            }

            var s = string.Concat(Enumerable.Repeat("0", kol));

            string fmt = s + ".##";
            string formatString = "{0:" + fmt + "}";

            Console.WriteLine("Initial array:");
            long m = 0;
            for (long i = 0; i < n; i++)
            {
                if (m != n - 1)
                {
                    Console.Write(formatString, array[i]);
                    Console.Write(", ");
                    m++;
                }
                else
                {
                    Console.Write(formatString, array[i]);
                }
            }

            Console.WriteLine();
            for (int i = 0; i < kol; i++)
            {
                Console.WriteLine("**********\nPhase {0}", i + 1);
                long[,] bucket = Phase1(array, n, formatString, i);
                array = Form(bucket, n);
            }

            long k = 0;
            for (long i = 0; i < n; i++)
            {
                if (k != n - 1)
                {
                    Console.Write(formatString, array[i]);
                    Console.Write(", ");

                    k++;
                }
                else
                {
                    Console.Write(formatString, array[i]);
                }
            }
        }

        public static long[] Form(long[,] bucket, long n)
        {
            long[] arr = new long[n];
            long k = 0;
            for (long i = 0; i < 10; i++)
            {
                for (long j = 0; j < n; j++)
                {
                    if (bucket[i, j] != 0)
                    {
                        arr[k] = bucket[i, j];
                        k++;
                    }
                }
            }

            return arr;
        }

        public static long[,] Phase1(long[] arr, long n, string formatString, long per)
        {
            long[,] bucket = new long[10, n];
            long[] arr_c = new long[n];
            Array.Copy(arr, arr_c, n);

            for (long i = 0; i < per; i++)
            {
                for (long j = 0; j < n; j++)
                {
                    arr[j] = arr[j] / 10;
                }
            }

            for (long i = 0; i < n; i++)
            {
                bucket[arr[i] % 10, i] = arr_c[i];
            }

            long k = 0;
            for (long i = 0; i < 10; i++)
            {
                k = 0;
                Console.Write("Bucket {0}: ", i);
                for (long j = 0; j < n; j++)
                {
                    if (bucket[i, j] != 0 && k == 0)
                    {
                        Console.Write(formatString, bucket[i, j]);
                        k++;
                    }
                    else if (bucket[i, j] != 0 && k != 0)
                    {
                        Console.Write(", ");
                        Console.Write(formatString, bucket[i, j]);

                        k++;
                    }
                }

                if (k == 0)
                {
                    Console.Write("empty");
                }

                Console.WriteLine();
            }

            return bucket;
        }
    }
}