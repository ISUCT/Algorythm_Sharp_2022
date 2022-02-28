using System;

namespace CourseApp.Module2
{
    public class Warehouse
    {
        public static void CountInversionsMethod()
        {
            WarehouseMethod();
        }

        public static void WarehouseMethod()
        {
            int numberProd = int.Parse(Console.ReadLine()); // считываем количество видов товара на складе
            int[] prod = new int[numberProd]; // создали массив под колчичество видов товара на складе
            string valuesProd = Console.ReadLine(); // содали строку для ввода элментов, считываем количество товаров i-го вида на складе.
            string[] sValuesProd = valuesProd.Split(' '); // массив строк для разделения элементов через пробел. sValues - Строковое представление элемента

            for (int i = 0; i < numberProd; i++)
            {
                prod[i] = int.Parse(sValuesProd[i]); // перебор от первого до последнего элемента, преобразование каждого строкогого элемента в число с записью в массив
            }

            int numberOrd = int.Parse(Console.ReadLine()); // считываем общее количество заказов клиентов
            string valuesOrd = Console.ReadLine(); // создали строку для ввода элментов, считываем заказы клиентов в произвольном порядке.
            string[] sValuesOrd = valuesOrd.Split(' '); // массив строк для разделения элементов через пробел. sValues - Строковое представление элемента
            int[] ord = new int[numberOrd]; // массив под заказы клиентов заполняем данными из numberOrd
            int max = 0; // берём точку отсчёта максимума за 0, как минимально возможную неотрицателньную

            for (int i = 0; i < numberOrd; i++)
            {
                ord[i] = int.Parse(sValuesOrd[i]);

                if (ord[i] > max)
                {
                    max = ord[i]; // находим максимальный заказ среди всех
                }
            }

            var sorted = Sort(ord, max); // переменной присваиваем вывод из метода сортировки

            for (int i = 0; i < prod.Length; i++)
            {
                if (prod[i] >= sorted[i])
                {
                    Console.WriteLine("no"); // если товара больше (или равно), чем максимальный заказ, выведем No
                }
                else
                {
                    Console.WriteLine("yes"); // если товара меньше, чем максимальный заказ, выведем yes
                }
            }
        }

        public static int[] Sort(int[] ord, int max)
        {
            int[] sorted = new int[max]; // заносим значение максимального заказа в переменную
            foreach (int element in ord)
            {
                if (element > 0)
                {
                    sorted[element - 1] += 1; // если элемент > 0, тогда к предыдущему значению добавляем 1
                }
                else
                {
                    break; // выходим
                }
            }

            return sorted; // возвращаем отсортированный максимальный заказ
        }
    }
}
