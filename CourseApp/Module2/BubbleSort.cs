using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod()
        {
            int n = int.Parse(Console.ReadLine()); //чтобы нужный тип - parse
            string s = Console.ReadLine();
            string[] sValues = s.Split(' '); //массив sValues разделяем на части (Values - ценности), он не понимает, что это отдельные числа
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]); //в инт из строки, присваиваем числа ввода в осн массив
            }

            bool swap = false;
            for (int i = 0; i < arr.Length - 1; i++)//(1/2) это + 
            {
                for (int j = 0; j < arr.Length - i - 1; j++) //(2/2) это вот  - сама сортировка из алгоритма (см. презенташку)
                {
                    if (arr[j] > arr[j + 1]) // 1й эл-т сравниваем со 2м
                    {
                        swap = true;
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); //меняем местами
                        string result = string.Join(" ", arr); // join вводит " " м/у эл-тами массива
                        Console.WriteLine(result);
                    }
                }
            }

            if (swap == false)
            {
                Console.WriteLine(0);
            }
        }
    }
}