using System;

namespace CourseApp.Module2
{
    public class Task5
    {
        public static void Task5_Main()
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[size];
            string data = Console.ReadLine();
            string[] sdata = data.Split(' ');
            int size_sort_massif = 1;
            int[] sort_arr = new int[size_sort_massif];
            for (int i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(sdata[i]);
            }

            bool flag = false;
            sort_arr[0] = arr[0];
            for (int i = 1; i < size; i++)
            {
                for (int j = 0; j < size_sort_massif; j++)
                {
                    if (arr[i] == sort_arr[j])
                    {
                        flag = false;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }

                if (flag)
                {
                    size_sort_massif++;
                    sort_arr[size_sort_massif - 1] = arr[i];
                }
            }

            Console.WriteLine(size_sort_massif);
        }
    }
}
