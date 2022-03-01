using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Task2
    {
        public static void Task2_Sort()
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[,] pairs = new int[size, 2];
            for (int i = 0; i < size; i++)
            {
                string data = Console.ReadLine();
                string[] massif_data = data.Split(' ');
                pairs[i, 0] = Convert.ToInt32(massif_data[0]);
                pairs[i, 1] = Convert.ToInt32(massif_data[1]);
            }

            for (int i = 0; i < (pairs.Length / 2) - 1; i++)
            {
                for (int j = 0; j < (pairs.Length / 2) - i - 1; j++)
                {
                    if (pairs[j, 1] < pairs[j + 1, 1])
                    {
                        (pairs[j, 1], pairs[j + 1, 1]) = (pairs[j + 1, 1], pairs[j, 1]);
                        (pairs[j, 0], pairs[j + 1, 0]) = (pairs[j + 1, 0], pairs[j, 0]);
                    }
                    else if (pairs[j, 1] == pairs[j + 1, 1])
                    {
                        if (pairs[j, 0] > pairs[j + 1, 0])
                        {
                            (pairs[j, 0], pairs[j + 1, 0]) = (pairs[j + 1, 0], pairs[j, 0]);
                            (pairs[j, 1], pairs[j + 1, 1]) = (pairs[j + 1, 1], pairs[j, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < pairs.Length / 2; i++)
            {
                Console.WriteLine($"{pairs[i, 0]} {pairs[i, 1]}");
            }
        }
    }
}
