using System;

namespace CourseApp.Module2
{
    public class CountInversions
    {
        private static long inversionsCount;

        public static void CountInversionsMethod()
        {
            MergeSortClone(); // Подсмотрела у Ваньки из 42 как это запустить нормально
        }

        public static void MergeSortClone()
        {
            inversionsCount = 0; // счётчик инверсий
            int num = int.Parse(Console.ReadLine()); // Запись кол-ва элементов в массиве, преобразовывая строковое значение в 32-битовое целое число со знаком

            if (num >= 1)
            {
                string str = Console.ReadLine(); // содали строку для ввода элментов, считываем
                string[] sValues = str.Split(' '); // массив строк для разделения элементов через пробел. sValues - Строковое представление элемента
                int[] array = new int[num];

                for (int i = 0; i < sValues.Length; i++)
                {
                    array[i] = int.Parse(sValues[i]); // перебор от первого до последнего элемента, преобразование каждого строкогого элемента в число с записью в массив
                }

                int[] result = Sorting(array, 0, num);
                Console.WriteLine($"{inversionsCount}"); // вывод кол-ва инверсий
            }
            else
            {
                Console.WriteLine(0); // если перестановок нет, вывести 0
            }
        }

        public static int[] MergeSort(int[] left, int[] right)
        {
            int i = 0; // индекс для left
            int j = 0; // индекс для right
            // код из MergeSort
            int[] result = new int[left.Length + right.Length]; // в результате слияние двух длин левой и правой частей
            for (int k = 0; k < result.Length; k++)
            {
                if (i == left.Length)
                {
                    result[k] = right[j];
                    j++;
                }
                else if (j == right.Length)
                {
                    result[k] = left[i];
                    i++;
                }
                else if (left[i] <= right[j])
                {
                    result[k] = left[i];
                    i++;
                }
                else
                {
                    result[k] = right[j];
                    j++;
                    inversionsCount += left.Length - i;
                }
            }

            return result;
        }

        public static int[] Sorting(int[] mas, int lowIndex, int highIndex)
        {
            if (highIndex - lowIndex == 1)
            {
                int[] res = new int[1];
                res[0] = mas[lowIndex];
                return res;
            }

            int middleIndex = (lowIndex + highIndex) / 2; // "средний" индекс будет равен раздёленной пополам сумме первого и последнего
            int[] left = Sorting(mas, lowIndex, middleIndex); // левая часть будет отсортирована из массива от первого до "среднего" индекса
            int[] right = Sorting(mas, middleIndex, highIndex); // правая часть будет отсортирована из массива от "среднего" до последнего индекса

            return MergeSort(left, right);
        }
    }
}
