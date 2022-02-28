using System;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod()
        {
            int number = int.Parse(Console.ReadLine()); // int.Parse - Преобразует строковое представление числа в указанном формате в эквивалентное ему 32-битовое целое число со знаком.
            string str = Console.ReadLine(); // содали строку для ввода элментов, считываем
            string[] sValues = str.Split(' '); // массив строк для разделения элементов через пробел. sValues - Строковое представление элемента
            int[] array = new int[number]; // содали массив размерностью, которую указали ранее в number
            for (int i = 0; i < number; i++)
            {
                array[i] = int.Parse(sValues[i]); // перебор от первого до последнего элемента, преобразование каждого строкогого элемента в число с записью в массив
            }

            bool flag = false;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]); // сравниваем предыдущий элемент (i) с последующим (j), если элемент массива i больше элемента массива j, то меняем элементы местами
                        string result = string.Join(" ", array);
                        Console.WriteLine(result);
                        flag = true;
                    }
                }
            }

            if (flag == false)
            {
                Console.WriteLine(0);
            }
            else
            {
                flag = false;
            }
        }
    }
}
