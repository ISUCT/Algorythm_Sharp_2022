using System;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void Bubble_sort()
        {
            int mas_L = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[mas_L];
            bool per = true;
            var mas = Console.ReadLine();
            var elems_mas = mas.Split(' ');

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(elems_mas[i]);
            }

            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        string result = string.Join(" ", arr);
                        per = false;
                        Console.WriteLine(result);
                    }
                }
            }

            if (per)
            {
                Console.WriteLine(Convert.ToInt32(!per));
            }
        }
    }
}
