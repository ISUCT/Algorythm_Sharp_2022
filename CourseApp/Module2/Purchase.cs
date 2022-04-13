using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module2
{
    public class Purchase
    {
        public static void CountPurcase()
        {
            StreamReader reader = new StreamReader("input.txt");
            int count_positions = int.Parse(reader.ReadLine());

            int[] storage = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();

            int count_orders = int.Parse(reader.ReadLine());
            int[] orders = reader.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            reader.Close();

            int[] counting = new int[count_positions];
            CheckOrders(orders, counting, count_orders);

            StreamWriter output = new StreamWriter("output.txt");

            for (int i = 0; i < count_positions; i++)
            {
                if (counting[i] <= storage[i])
                {
                    output.WriteLine("no");
                }
                else
                {
                    output.WriteLine("yes");
                }
            }

            output.Close();
        }

        public static void CheckOrders(int[] orders, int[] count, int count_orders)
        {
            for (int i = 0; i < count_orders; i++)
            {
                count[orders[i] - 1]++;
            }
        }
    }
}