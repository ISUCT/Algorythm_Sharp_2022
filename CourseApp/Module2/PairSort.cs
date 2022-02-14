using System.IO;

namespace CourseApp.Module2
{
    public class PairSort
    {
        public static void DoPairSort()
        {
            StreamReader reader = new StreamReader("input.txt");
            string size = reader.ReadLine();
            string[] data = new string[int.Parse(size)];
            for (int i = 0; !reader.EndOfStream; i++)
            {
                data[i] = reader.ReadLine();
            }

            reader.Close();
            StreamWriter output = new StreamWriter("output.txt");
                foreach (string item in PairBubbleSortMethod(data))
                {
                    output.WriteLine(item);
                }

                output.Close();
        }

         public static string[] PairBubbleSortMethod(string[] array)
        {
            int[,] buffer = new int[2, 2];
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    buffer[0, 0] = int.Parse(array[j].Split(" ")[0]);
                    buffer[0, 1] = int.Parse(array[j].Split(" ")[1]);

                    buffer[1, 0] = int.Parse(array[j + 1].Split(" ")[0]);
                    buffer[1, 1] = int.Parse(array[j + 1].Split(" ")[1]);

                    if (buffer[0, 1] < buffer[1, 1])
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    }
                    else if (buffer[0, 1] == buffer[1, 1])
                    {
                        if (buffer[0, 0] > buffer[1, 0])
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                        }
                    }
                }
            }

            return array;
        }
    }
}