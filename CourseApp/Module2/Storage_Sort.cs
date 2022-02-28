using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Storage_Sort
    {
        public static void Num_sort(int[] order_arr, int[] products_arr, int k)
        {
            int[] c = new int[k + 1];
            for (int i = 0; i < order_arr.Length; i++)
            {
                c[order_arr[i]]++;
            }

            int pos = 0;
            int kekw = 0;
            int[] order = new int[k];
            string[] answer = new string[k];
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 0)
                {
                    order[pos++] = c[i];
                    if (products_arr[kekw] >= order[kekw])
                    {
                        Console.WriteLine("no");
                    }
                    else
                    {
                        Console.WriteLine("yes");
                    }

                    kekw++;
                }
            }
        }

        public static void Try()
        {
            int products = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] products_arr = new int[products];
            for (int i = 0; i < products; i++)
            {
                products_arr[i] = int.Parse(sValues[i]);
            }

            int n = int.Parse(Console.ReadLine());
            s = Console.ReadLine();
            sValues = s.Split(' ');
            int[] order_arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                order_arr[i] = int.Parse(sValues[i]);
            }

            Num_sort(order_arr, products_arr, products);
        }
    }
}
