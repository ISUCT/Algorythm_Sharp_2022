using System;

public class PeriodOfString
{
    public static void PeriodOfStringMethod()
    {
        string basedString = Console.ReadLine();
        int[] result = FindPeriodOfString(basedString);

        int division = basedString.Length - result[result.Length - 1];

        if (basedString.Length % division == 0)
        {
            Console.WriteLine(basedString.Length / division);
        }
        else
        {
            Console.WriteLine(1);
        }
    }

    public static int[] FindPeriodOfString(string s)
    {
        int[] result = new int[s.Length];
        result[0] = 0;

        for (int i = 0; i < s.Length - 1; i++)
        {
            int j = result[i];

            while (j > 0 && s[i + 1] != s[j])
            {
                j = result[j - 1];
            }

            if (s[i + 1] == s[j])
            {
                result[i + 1] = j + 1;
            }
            else
            {
                result[i + 1] = 0;
            }
        }

        return result;
    }
}
