using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMeth()
        {
                int arr_size = int.Parse(Console.ReadLine());
                string[] arr_str = Console.ReadLine().Split(' ');
                int[] arr = new int[arr_size];

                //Строковый массив в целочисенный массив
                for(int i = 0; i < arr_size; ++i)
                {
                    arr[i] = int.Parse(arr_str[i]);
                }

                //Были перестановки или нет
                bool flag = false;
                //Сортировка
                for(int i = 0; i < arr_size; ++i)
                {
                    for(int j = 0; j < arr_size - i - 1; ++j)
                    {
                        if(arr[j] > arr[j+1])
                        {
                            (arr[j], arr[j+1]) = (arr[j+1], arr[j]);
                            string reslt = string.Join(" ", arr);
                            Console.WriteLine(reslt);
                            flag = true;
                        }
                    }
                }
                
                if(flag == false)
                {
                    Console.WriteLine("0");
                }
        }
    }
}