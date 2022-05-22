using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module2
{
    public class Warehouse
    {
        public static void Main()
        {
            int p = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            string[] v = line.Split(' ');
            int[] products = new int[p];
            
            for (int i = 0; i < p; i++)
            {
                products[i] = int.Parse(v[i]);
            }
            int n = int.Parse(Console.ReadLine());
            line = Console.ReadLine();
            v = line.Split(' ');
            int[] booking = new int[n];
            for (int i = 0; i < n; i++)
            {
                booking[i] = int.Parse(v[i]);
            }

            Sort(booking, products, p);
        }
        public static void Sort(int[] booking, int[] products, int k)
        {
            int[] c = new int[k + 1];
            for (int i = 0; i < booking.Length; i++)
            {
                c[booking[i]]++;
            }
            int x = 0;
            int m = 0;
            int[] new_o = new int[k];
            string[] arr = new string[k];
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 0)
                {
                    new_o[x++] = c[i];

                    if (products[m] >= new_o[m])
                    {
                        Console.WriteLine("no");
                    }
                    else
                    {
                        Console.WriteLine("yes");
                    }
                    m++;
                }
            }
        }
    }
}
