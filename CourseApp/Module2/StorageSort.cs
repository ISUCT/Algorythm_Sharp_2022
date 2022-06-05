using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class StorageSort
    {
        public static void CountOrders()
        {
            int count_position = int.Parse(Console.ReadLine());
            string tmp_arr = Console.ReadLine();
            string[] sValues = tmp_arr.Split(' ');
            int[] storage = new int[count_position];
            for (int i = 0; i < count_position; i++)
            {
                storage[i] = int.Parse(sValues[i]);
            }

            int count_orders = int.Parse(Console.ReadLine());
            tmp_arr = Console.ReadLine();
            sValues = tmp_arr.Split(' ');
            int[] order = new int[count_orders];
            for (int i = 0; i < count_orders; i++)
            {
                order[i] = int.Parse(sValues[i]);
            }

            int[] counting = new int[count_position];
            CheckOrder(order, counting, count_orders);

            for (int i = 0; i < count_position; i++)
            {
                if (counting[i] <= storage[i])
                {
                    Console.WriteLine("no");
                }
                else
                {
                    Console.WriteLine("yes");
                }
            }
        }

        public static void CheckOrder(int[] order, int[] count, int count_order)
        {
            for (int i = 0; i < count_order; i++)
            {
                count[order[i] - 1]++;
            }
        }
    }
}
