using System;
using System.Text;

namespace CourseApp.Module2
{
    public class PairSort
    {
        public static void PairSortMethod()
        {
            int amountPair = int.Parse(Console.ReadLine()); // считываем ожидаемое количество пар
            int[,] pairs = new int[amountPair, 2]; // Заводим массив, в который запишем каждую пару. Раздление по 2 элемента в паре
            for (int i = 0; i < amountPair; i++)
            {
                var readPair = Console.ReadLine().Split(" "); // считывание элементов пар через пробел
                pairs[i, 0] = int.Parse(readPair[0]); // преобразование к числу первого (нулевого) элемента
                pairs[i, 1] = int.Parse(readPair[1]); // проебразование к числу второго (первого) элемента
            }

            for (int i = 0; i < (pairs.Length / 2) - 1; i++)
            {
                for (int j = 0; j < (pairs.Length / 2) - i - 1; j++)
                {
                    if (pairs[j, 1] < pairs[j + 1, 1])
                    {
                        (pairs[j, 0], pairs[j + 1, 0]) = (pairs[j + 1, 0], pairs[j, 0]); // сравнение первых (нулевых) элементов из соседних пар, сортировка их по убыванию
                        (pairs[j, 1], pairs[j + 1, 1]) = (pairs[j + 1, 1], pairs[j, 1]); // сравнение вторых (первых) элементов из соседних пар, сортировка по убыванию
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
                Console.WriteLine($"{pairs[i, 0]} {pairs[i, 1]}"); // вывод
            }
        }
    }
}
