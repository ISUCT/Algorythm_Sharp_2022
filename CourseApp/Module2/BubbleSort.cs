using System;

public class BubbleSort
{
    public static void BubbleSortMethod()
    {
        bool changes = false;
        string size = Console.ReadLine();
        string value = Console.ReadLine();
        string[] numbers = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = 0; j < numbers.Length - 1 - i; j++)
            {
                if (int.Parse(numbers[j]) > int.Parse(numbers[j + 1]))
                {
                    (numbers[j], numbers[j + 1]) = (numbers[j + 1], numbers[j]);
                    string result = string.Join(" ", numbers);
                    Console.WriteLine(result);
                    changes = true;
                }
            }
        }

        if (changes == false)
        {
            Console.WriteLine(0);
        }
    }
}