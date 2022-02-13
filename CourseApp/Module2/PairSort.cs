using System;

public class PairSort
{
    public static void PairSortMethod()
    {
        int numberOfElements = int.Parse(Console.ReadLine());
        string[][] arrayOfElements = new string[numberOfElements][];

        for (int i = 0; i < numberOfElements; i++)
        {
            string[] value = Console.ReadLine().Split(new char[] { ' ' });
            arrayOfElements[i] = value;
        }

        for (int l = 0; l < numberOfElements - 1; l++)
        {
            for (int k = 0; k < numberOfElements - 1; k++)
            {
                if (Convert.ToInt32(arrayOfElements[k][1]) < Convert.ToInt32(arrayOfElements[k + 1][1]))
                {
                    (arrayOfElements[k], arrayOfElements[k + 1]) = (arrayOfElements[k + 1], arrayOfElements[k]);
                }
                else if (arrayOfElements[k][1] == arrayOfElements[k + 1][1])
                {
                    if (Convert.ToInt32(arrayOfElements[k][0]) > Convert.ToInt32(arrayOfElements[k + 1][0]))
                    {
                        (arrayOfElements[k], arrayOfElements[k + 1]) = (arrayOfElements[k + 1], arrayOfElements[k]);
                    }
                }
            }
        }

        for (int p = 0; p < numberOfElements; p++)
        {
            string result = string.Join(" ", arrayOfElements[p]);
            Console.WriteLine(result);
        }

        Console.WriteLine();
    }
}