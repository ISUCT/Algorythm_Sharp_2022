using System;

public class PairSort
{
    public static void PairSortMethod()
    {
        int numberOfElements = int.Parse(Console.ReadLine());
        string[][] array = new string[numberOfElements][];
        string[] value = Console.ReadLine().Split(new char[] { ' ' });
        array[0] = value;
        for (int i = 1; i < numberOfElements;  i++)
        {
            string[] temp = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            array[i] = temp;

            for (int j = 0; j < i; j++)
            {
                if (int.Parse(array[j][1]) < int.Parse(array[i][1]))
                {
                    (array[j], array[i]) = (array[i], array[j]);
                }
                else if (int.Parse(array[j][1]) == int.Parse(array[i][1]))
                {
                    if (int.Parse(array[j][0]) > int.Parse(array[i][0]))
                    {
                        (array[j], array[i]) = (array[i], array[j]);
                    }
                }
            }
        }

        for (int i = 0; i < numberOfElements; i++)
        {
            Console.WriteLine(array[i][0] + " " + array[i][1]);
        }
    }
}