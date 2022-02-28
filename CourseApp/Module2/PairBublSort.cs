using System;

namespace CourseApp.Module2
{
    public class PairBublSort
    {
        public static void PairBubbleSort()
        {

                int n = Convert.ToInt32(Console.ReadLine());
                string[] arr_str;
                int[,] arr = new int[n, 2];

                for(int i = 0; i < n; ++i)
                {   
                    //Получение строк
                    string str = Console.ReadLine();
                    arr_str = str.Split(' ');

                    //Преобразование строк в числа
                    arr[i, 0] = int.Parse(arr_str[0]);
                    arr[i, 1] = int.Parse(arr_str[1]);
                }

                for(int i = 0; i < n - 1; ++i)
                {
                    for(int j = 0; j < n - 1; ++j)
                    {   
                        //Сортировка по цене
                        if(arr[j, 1] < arr[j + 1, 1])
                        {
                            (arr[j + 1, 1], arr[j, 1]) = (arr[j, 1], arr[j + 1, 1]);
                            (arr[j + 1, 0], arr[j, 0]) = (arr[j, 0], arr[j + 1, 0]);
                        }   
                            //Сортируем по идентификационному номеру, когда цена одинакова
                            else if(arr[j, 1] == arr[j + 1, 1])
                            {
                                if(arr[j, 0] > arr[j + 1, 0])
                                {
                                    (arr[j + 1, 0], arr[j, 0]) = (arr[j, 0], arr[j + 1, 0]);
                                }
                            }
                    }
                }
                Console.WriteLine();
                for(int i = 0; i < n; ++i)
                {
                    for(int j = 0; j < 2; ++j)
                    {
                        Console.Write(arr[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
        }
    }
}
