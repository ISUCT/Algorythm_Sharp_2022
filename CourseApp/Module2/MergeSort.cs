using System;
using System.Text;

namespace CourseApp.Module2
{
    public class MergeSort
    {
        public static void MergeSortMethod() // ввод:
        {
            int num = int.Parse(Console.ReadLine()); // int.Parse - Преобразует строковое представление числа в указанном формате в эквивалентное ему 32-битовое целое число со знаком.
            string str = Console.ReadLine(); // содали строку для ввода элментов, считываем
            string[] sValues = str.Split(' '); // массив строк для разделения элементов через пробел. sValues - Строковое представление элемента
            int[] array = new int[num]; // содали массив размерностью, которую указали ранее в num
            for (int i = 0; i < num; i++)
            {
                array[i] = int.Parse(sValues[i]); // перебор от первого до последнего элемента, преобразование каждого строк.элемента в число с записью в массив
            }

            int[] result = MergeSorting(array, 0, num); // вызываем merge sort и задаём туда массив, нулевой индекс 0 и последний индекс = значению num
            for (int i = 0; i < result.Length; i++)
            {
                Console.Write($"{result[i]} ");
            }
        }

        public static int[] Merge(int[] left, int[] right)
        {
            int i = 0; // индекс для left
            int j = 0; // индекс для right
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
                }
            }

            return result;
        }

        public static int[] MergeSorting(int[] mas, int lowIndex, int highIndex)
        {
            if (highIndex - lowIndex == 1)
            {
                int[] res = new int[1]; // если размерность (разность последнего и первого индексов) массива равна единице, выведем сам элемент массива
                res[0] = mas[lowIndex];
                return res;
            }

            int middleIndex = (lowIndex + highIndex) / 2; // "средний" индекс будет равен раздёленной пополам сумме первого и последнего
            int[] left = MergeSorting(mas, lowIndex, middleIndex); // левая часть будет отсортирована из массива от первого до "среднего" индекса
            int[] right = MergeSorting(mas, middleIndex, highIndex); // правая часть будет отсортирована из массива от "среднего" до последнего индекса
            int[] result = Merge(left, right); // в результате запишем слияние левой и правой частей после merge
            Console.WriteLine($"{lowIndex + 1} {highIndex} {result[0]} {result[^1]}"); // вывод нулевого (первого, поэтому +1) индекса из области слияния, идекс конца области, значение нулевого (первого) элемента и посленего элемента области

            return Merge(left, right);
        }
    }
}