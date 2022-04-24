using System;

namespace CourseApp.Module2
{
    public class MergeSort
    {
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

        private static int[] ArrSort(ref int[] arr, int begin, int end)
        {
            if (end - begin == 1)  //если 2 эл-т на 1 > 1 эл-та, то меняем местами (1/3)
            {
                int[] res = new int[1]; //(2/3)
                res[0] = arr[begin]; //(3/3)
                return res; //возвращаем результат
            }

            int mid = (begin + end) / 2; //находим середину

            int[] left = ArrSort(ref arr, begin, mid); //проводим через первый if
            int[] right = ArrSort(ref arr, mid, end); //проводим через первый if

            int[] sort = Merge(ref left, ref right); // см стр 20

            Console.WriteLine("{0} {1} {2} {3}", begin + 1, end, sort[0], sort[^1]);

            return Merge(ref left, ref right);
        }

        private static int[] InputParse()
        {
            int n = int.Parse(Console.ReadLine()); //заполняем матрицу с консоли
            int[] arr = new int[n]; //создаём новый массив
            string s = Console.ReadLine(); //создём строку введённых данных
            string[] sValues = s.Split(' '); //делим на части
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]); //заполняем новый массив
            }

            return arr;
        }
    }
}