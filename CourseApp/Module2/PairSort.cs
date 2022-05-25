using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class PairSort
    {
        public static void PairSortMethod()
        {
            int[,] arr = InputParse(); //InputParse - ф-ция, к-ая заполняет матрицу

            int n = arr.Length / 2; // находим середину

            SortArrFirst(ref arr, ref n); // ref - ссылка на arr из InputParse
            SortArrSecond(ref arr, ref n);
            Show(ref arr, ref n);
        }

        private static void SortArrFirst(ref int[,] arr, ref int n) //сама сортировка 1 пр-ра
        {
            for (int i = 0; i < n; i++) //строка матрицы
            {
                for (int j = 0; j < n - i - 1; j++) // столбец матрицы
                {
                    if (arr[j + 1, 1] > arr[j, 1]) // 
                    {
                        Swap(ref arr[j, 0], ref arr[j + 1, 0]); //стравниваем и при необх-ти меняем местами индекс
                        Swap(ref arr[j, 1], ref arr[j + 1, 1]); //стравниваем и при необх-ти меняем местами стоимость
                    }
                }
            }
        }

        private static void SortArrSecond(ref int[,] arr, ref int n) //см SortArrFirst
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1, 1] == arr[j, 1] && arr[j + 1, 0] < arr[j, 0])
                    {
                        Swap(ref arr[j, 0], ref arr[j + 1, 0]);
                        Swap(ref arr[j, 1], ref arr[j + 1, 1]);
                    }
                }
            }
        }

        private static int[,] InputParse() // Сама функция (см 13стр)
        {
            int n = int.Parse(Console.ReadLine()); // кол-во эл-тов как в пузырьке
            int[,] arr = new int[n, 2]; // осн матрица n - стб, 2 - стр
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();// вводим строку (см пузырёк) (56-64)
                string[] sValues = s.Split(' ');
                for (int j = 0; j < 2; j++)
                {
                    arr[i, j] = int.Parse(sValues[j]);
                }
            }

            return arr; // отдаём в 13стр 
        }

        private static void Show(ref int[,] arr, ref int n) // вывод
        {
            string result = null;
            for (int i = 0; i < n; i++)
            {
                result = arr[i, 0] + " " + arr[i, 1]; // записываем строчку из матрицы 
                Console.WriteLine(result);
            }
        }

        private static void Swap(ref int left, ref int right) // (см 30стр 31 стр) (см 45стр 46стр) 
        {
            int temp = right;
            right = left;
            left = temp;
        }
    }
}