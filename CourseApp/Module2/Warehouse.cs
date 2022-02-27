using System;

public class Warehouse
{
    public static void Storage()
    {
        int numberProducts = int.Parse(Console.ReadLine());
        int[] products = new int[numberProducts];
        string[] valuesProducts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numberProducts; i++)
        {
            products[i] = int.Parse(valuesProducts[i]);
        }

        int numberOrders = int.Parse(Console.ReadLine());
        string[] valuesOrders = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] orders = new int[numberOrders];
        int max = 0;
        for (int i = 0; i < numberOrders; i++)
        {
            orders[i] = int.Parse(valuesOrders[i]);
            if (orders[i] > max)
            {
                max = orders[i];
            }
        }

        var sorted = Sorting(orders, max);

        for (int i = 0; i < products.Length; i++)
        {
            if (products[i] >= sorted[i])
            {
                Console.WriteLine("no");
            }
            else
            {
                Console.WriteLine("yes");
            }
        }
    }

    public static int[] Sorting(int[] orders, int max)
    {
        int[] sorted = new int[max];
        foreach (int item in orders)
        {
            if (item > 0)
            {
                sorted[item - 1] += 1;
            }
            else
            {
                break;
            }
        }

        return sorted;
    }
}