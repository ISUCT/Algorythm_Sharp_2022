using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Warehouse
    {
        public static void Count_Sort(int[] orders_arr, int[] products_arr, int n)
        {
            int[] arr = new int[n + 1];
            for (int i = 0; i < orders_arr.Length; i++)
            {
                arr[orders_arr[i]]++;
            }

            int pos = 0;
            int index = 0;
            int[] ord = new int[n];
            string[] answer = new string[n];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    ord[pos++] = arr[i];
                    if (products_arr[index] >= ord[index])
                    {
                        Console.WriteLine("no");
                    }
                    else
                    {
                        Console.WriteLine("yes");
                    }

                    index++;
                }
            }
        }

        public static void Input_Values()
        {
            int products_len = int.Parse(Console.ReadLine());
            string products_string = Console.ReadLine();
            string[] parseValues = products_string.Split(' ');
            int[] products_arr = new int[products_len];
            for (int i = 0; i < products_len; i++)
            {
                products_arr[i] = int.Parse(parseValues[i]);
            }

            int orders_len = int.Parse(Console.ReadLine());
            string orders_string = Console.ReadLine();
            parseValues = orders_string.Split(' ');
            int[] orders_arr = new int[orders_len];
            for (int i = 0; i < orders_len; i++)
            {
                orders_arr[i] = int.Parse(parseValues[i]);
            }

            Count_Sort(orders_arr, products_arr, products_len);
        }
    }
}
