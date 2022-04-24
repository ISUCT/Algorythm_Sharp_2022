using System;

namespace CourseApp.Module2
{
    public class InversionSort
    {
        private static long inversion = 0;

        public static void MergeSortMethod()
        {
            int[] arr = InputParse(); //см стр 68

            int[] sortedArr = ArrSort(ref arr, 0, arr.Length); //см стр 47

            Console.WriteLine("{0}", string.Join(" ", sortedArr));
        }

        private static int[] Merge(ref int[] left, ref int[] right) //основной алгоритм сортировки
        {
            int i = 0;
            int j = 0;
            int[] add = new int[left.Length + right.Length];
            for (int k = 0; k < add.Length; k++)
            {
                if (i == left.Length)
                {
                    add[k] = right[j];
                    j++;
                }
                else if (j == right.Length || left[i] <= right[j])
                {
                    add[k] = left[i];
                    i++;
                }
                else
                {
                    add[k] = right[j];
                    j++;
                }
            }

            return add;
        }

        private static int[] ElementsSort(ref int[] order, int left, int right)
        {
            if (right - left == 1)  //если 2 эл-т на 1 > 1 эл-та, то меняем местами (1/3)
            {
                int[] res = new int[1]; //(2/3)
                res[0] = order[left]; //(3/3)
                return res; //возвращаем результат
            }

            int mid = (left + right) / 2; //находим середину

            int[] leftEl = ElementsSort(ref order, left, mid); //проводим через первый if
            int[] rightEl = ElementsSort(ref order, mid, right); //проводим через первый if

            int[] sort = Merge(ref leftEl, ref rightEl) // см стр 20

            return sort;
        }

        private static void InputParse()
        {
            int n = int.Parse(Console.ReadLine()); //заполняем матрицу с консоли
            int[] arr = new int[n]; //создаём новый массив
            string s = Console.ReadLine(); //создём строку введённых данных
            string[] sValues = s.Split(' '); //делим на части
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]); //заполняем новый массив
            }

            Console.WriteLine(inversion);
        }
    }
}