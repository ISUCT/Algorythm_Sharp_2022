using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubblePairSort
    {
        public static void BubblePairSortMethod()
        {
            int cols = Convert.ToInt32(Console.ReadLine());
            int rows = 2;
            int[,] mas = new int[cols, rows];

            string input;
            string[] input_mas;

            for (int i = 0; i < cols; i++)
            {
                input = Console.ReadLine();
                input_mas = input.Split(' ');

                mas[i, 0] = Convert.ToInt32(input_mas[0]);
                mas[i, 1] = Convert.ToInt32(input_mas[1]);
            }

            int tmp_id = 0;
            int tmp_value = 0;

            for (int j = 0; j < cols - 1; j++)
            {
                for (int i = 0; i < cols - 1; i++)
                {
                    if (mas[i, 1] < mas[i + 1, 1])
                    {
                        tmp_id = mas[i, 0];
                        tmp_value = mas[i, 1];
                        mas[i, 0] = mas[i + 1, 0];
                        mas[i, 1] = mas[i + 1, 1];
                        mas[i + 1, 0] = tmp_id;
                        mas[i + 1, 1] = tmp_value;
                    }
                    else if (mas[i, 1] == mas[i + 1, 1])
                    {
                        if (mas[i, 0] > mas[i + 1, 0])
                        {
                            tmp_id = mas[i, 0];
                            tmp_value = mas[i, 1];
                            mas[i, 0] = mas[i + 1, 0];
                            mas[i, 1] = mas[i + 1, 1];
                            mas[i + 1, 0] = tmp_id;
                            mas[i + 1, 1] = tmp_value;
                        }
                    }
                }
            }

            for (int i = 0; i <= cols - 1; i++)
            {
                Console.WriteLine($"{mas[i, 0]} {mas[i, 1]}");
            }
        }
    }
}
