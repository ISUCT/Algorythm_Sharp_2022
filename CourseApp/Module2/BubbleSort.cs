using System;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod()
        {
            int[] array = new int[Convert.ToInt32(Console.ReadLine())];
            string[] s = Console.ReadLine().Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(s[i]);
            }

            StringBuilder sb = new StringBuilder();
            bool swaps = false;
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        Console.WriteLine("{0}", sb.AppendJoin(" ", array).ToString());
                        sb.Clear();
                        swaps = true;
                    }
                }
            }

            if (swaps == false)
            {
                Console.WriteLine(0);
            }
            else
            {
                swaps = false;
            }
        }
    }
}
