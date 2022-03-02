using System;

namespace CourseApp.Module2
{
    public class Warehouse
    {
        public static void Calculate(int[] arr_of_order, int[] arr_of_products, int a)
        {
            int[] c = new int[a + 1];
            for (int g = 0; g < arr_of_order.Length; g++)
            {
                c[arr_of_order[g]]++;
            }

            int pos = 0;
            int index = 0;
            int[] order = new int[a];
            string[] answer = new string[a];
            for (int g = 0; g < c.Length; g++)
            {
                if (c[g] != 0)
                {
                    order[pos++] = c[g];
                    if (arr_of_products[index] >= order[index])
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

        public static void ClassMain()
        {
            int products = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            int[] arr_of_products = new int[products];
            for (int g = 0; g < products; g++)
            {
                arr_of_products[g] = int.Parse(sValues[g]);
            }

            int n = int.Parse(Console.ReadLine());
            s = Console.ReadLine();
            sValues = s.Split(' ');
            int[] arr_of_order = new int[n];
            for (int g = 0; g < n; g++)
            {
                arr_of_order[g] = int.Parse(sValues[g]);
            }

            Calculate(arr_of_order, arr_of_products, products);
        }
    }
}