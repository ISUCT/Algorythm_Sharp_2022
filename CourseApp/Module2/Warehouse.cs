using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Warehouse
    {
        public static void Warehoust_Sort(int[] assignment_mas, int[] mas_of_products, int k)
        {
            int[] w = new int[k + 1];
            for (int i = 0; i < assignment_mas.Length; i++)
            {
                w[assignment_mas[i]]++;
            }

            int a = 0;
            int b = 0;
            int[] mas_of_orders = new int[k];
            string[] answer = new string[k];
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i] != 0)
                {
                    mas_of_orders[a++] = w[i];
                    if (mas_of_products[b] >= mas_of_orders[b])
                    {
                        Console.WriteLine("no");
                    }
                    else
                    {
                        Console.WriteLine("yes");
                    }

                    b++;
                }
            }
        }

        public static void Enter()
        {
            int products = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] mas_of_products = new int[products];
            for (int i = 0; i < products; i++)
            {
                mas_of_products[i] = int.Parse(sValues[i]);
            }

            int n = int.Parse(Console.ReadLine());
            s = Console.ReadLine();
            sValues = s.Split(' ');
            int[] assignment_mas = new int[n];
            for (int i = 0; i < n; i++)
            {
                assignment_mas[i] = int.Parse(sValues[i]);
            }

            Warehoust_Sort(assignment_mas, mas_of_products, products);
        }
    }
}