using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class Sorting
    {
        public static void Main()
        {
            int quantity = int.Parse(Console.ReadLine());
            int[,] two = new int[quantity, 2];
            
            for (int i = 0; i < quantity; i++)
            {
                string line = Console.ReadLine();
                string[] v = line.Split(' ');
                two[i, 0] = int.Parse(v[0]);
                two[i, 1] = int.Parse(v[1]);
            }
            for (int i = 0; i < (two.Length / 2) - 1; i++)
            {
                for (int j = 0; j < (two.Length / 2) - i - 1; j++)
                {
                    if (two[j, 1] < two[j + 1, 1])
                    {
                        (two[j, 1], two[j + 1, 1]) = (two[j + 1, 1], two[j, 1]);
                        (two[j, 0], two[j + 1, 0]) = (two[j + 1, 0], two[j, 0]);
                    }
                    else if (two[j, 1] == two[j + 1, 1])
                    {
                        if (two[j, 0] > two[j + 1, 0])
                        {
                            (two[j, 0], two[j + 1, 0]) = (two[j + 1, 0], two[j, 0]);
                            (two[j, 1], two[j + 1, 1]) = (two[j + 1, 1], two[j, 1]);
                        }
                    }
                }
            }

            for (int i = 0; i < quantity; i++)
            {
                Console.WriteLine("{0} {1}", two[i, 0], two[i, 1]);
            }
        }
    }
}