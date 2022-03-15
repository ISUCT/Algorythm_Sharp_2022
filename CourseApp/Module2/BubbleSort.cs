using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module2
{
    public class BubbleSort
    {
        public static void DoBubbleSort()
        {
            StreamReader reader = new StreamReader("input.txt");
            int size = int.Parse(reader.ReadLine());
            string[] data = reader.ReadLine().Split(" ");
            int[] array = new int[size];
            int index = 0;
            foreach (var item in data)
            {
                array[index] = int.Parse(item);
                index++;
            }

            reader.Close();
            BubbleSortMethod(array);
        }

        public static void BubbleSortMethod(int[] array)
        {
            StreamWriter output = new StreamWriter("output.txt");
            bool trigger = false;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        output.WriteLine(string.Join(" ", array));
                        trigger = true;
                    }
                }
            }

            if (!trigger)
            {
                output.WriteLine("0");
            }

            output.Close();
        }
    }
}