using System;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void BubbleSortMethod(int n, int[] array)
        {
            StringBuilder sb = new StringBuilder();
            bool swaps = false;
            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n - i - 1; ++j)
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
            } else {
                swaps = false;
            }
        }
    }
}
