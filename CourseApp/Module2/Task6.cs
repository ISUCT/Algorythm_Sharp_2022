using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Task6
    {
        public static void Sravn(int[] arr_data, int[] order_data)
        {
            for (int i = 0; i < arr_data.Length; i++)
            {
                if (arr_data[i] >= order_data[i])
                {
                    Console.WriteLine("no");
                }
                else
                {
                    Console.WriteLine("yes");
                }
            }
        }

        public static int[] Podschet(int[] arr_data, int siz)
        {
            int size = siz;
            int[] order_data = new int[size];
            int count = 0;
            bool flag = false;
            int k = 0;
            for (int i = 0; i < arr_data.Length; i++)
            {
                if ((i == arr_data.Length - 1) && (arr_data[i] != arr_data[i - 1]))
                {
                    order_data[k] = 1;
                }

                if (i == arr_data.Length - 1)
                {
                    break;
                }
                else if (arr_data[i] == arr_data[i + 1])
                {
                    count++;
                    if (i == arr_data.Length - 2)
                    {
                        flag = true;
                    }
                }
                else
                {
                    flag = true;
                }

                if (flag)
                {
                    order_data[k] = ++count;
                    k++;
                    count = 0;
                    flag = false;
                }
            }

            return order_data;
        }

        public static int[] MergSort(int[] a, int[] b)
        {
            int c = 0;
            int d = 0;
            int[] arr = new int[a.Length + b.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (c == a.Length)
                {
                    arr[i] = b[d];
                    d++;
                }
                else if (d == b.Length)
                {
                    arr[i] = a[c];
                    c++;
                }
                else if (a[c] <= b[d])
                {
                    arr[i] = a[c];
                    c++;
                }
                else
                {
                    arr[i] = b[d];
                    d++;
                }
            }

            return arr;
        }

        public static int[] MergeSort1(int[] x, int l, int r)
        {
            if (r - l == 1)
            {
                int[] result = new int[1];
                result[0] = x[l];
                return result;
            }

            int m = (l + r) / 2;

            int[] left = MergeSort1(x, l, m);
            int[] right = MergeSort1(x, m, r);

            int[] sort = MergSort(left, right);

            return MergSort(left, right);
        }

        public static void Task6_Main()
        {
            int size_sklad = Convert.ToInt32(Console.ReadLine());
            string str_sklad = Console.ReadLine();
            string[] string_sklad = str_sklad.Split(' ');
            int[] data = new int[size_sklad];
            for (int i = 0; i < size_sklad; i++)
            {
                data[i] = Convert.ToInt32(string_sklad[i]);
            }

            int size_zakaz = Convert.ToInt32(Console.ReadLine());
            string str_zakaz = Console.ReadLine();
            string[] string_zakaz = str_zakaz.Split(' ');
            int[] data_zakaz = new int[size_zakaz];
            for (int i = 0; i < size_zakaz; i++)
            {
                data_zakaz[i] = Convert.ToInt32(string_zakaz[i]);
            }

            int[] zakaz_sorted = MergeSort1(data_zakaz, 0, size_zakaz);
            int[] res = Podschet(zakaz_sorted, size_sklad);
            Sravn(data, res);
        }
    }
}
