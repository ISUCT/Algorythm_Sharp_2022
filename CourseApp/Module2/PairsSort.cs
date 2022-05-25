using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class PairsSort
    {
        public static void PairsS()
        {
            int sortPairs = Convert.ToInt32(Console.ReadLine());
            int[,] pairs = new int[sortPairs, 2];
            for (int i = 0; i < sortPairs; i++)
            {
                string value = Console.ReadLine();
                string[] sValues = value.Split(' ');
                pairs[i, 0] = int.Parse(sValues[0]);
                pairs[i, 1] = int.Parse(sValues[1]);
            }

            for (int i = 0; i < (pairs.Length / 2) - 1; i++)
            {
                for (int q = 0; q < (pairs.Length / 2) - i - 1; q++)
                {
                    if (pairs[q, 1] < pairs[q + 1, 1])
                    {
                        (pairs[q, 1], pairs[q + 1, 1]) = (pairs[q + 1, 1], pairs[q, 1]);
                        (pairs[q, 0], pairs[q + 1, 0]) = (pairs[q + 1, 0], pairs[q, 0]);
                    }

                    if (pairs[q, 1] == pairs[q + 1, 1])
                    {
                        if (pairs[q, 0] > pairs[q + 1, 0])
                        {
                            (pairs[q, 0], pairs[q + 1, 0]) = (pairs[q + 1, 0], pairs[q, 0]);
                            (pairs[q, 1], pairs[q + 1, 1]) = (pairs[q + 1, 1], pairs[q, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < sortPairs; i++)
            {
                Console.WriteLine($"{pairs[i, 0]} {pairs[i, 1]}");
            }
        }
    }
}
