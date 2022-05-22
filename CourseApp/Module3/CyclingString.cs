using System;

public class CyclingString
{
    public static void CyclingStringMethod()
    {
        string basedString = Console.ReadLine();

        int result = PrefixFunctionLastElement(basedString);

        Console.WriteLine(basedString.Length - result);
    }

    public static int PrefixFunctionLastElement(string s)
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

        return result[result.Length - 1];
    }
}
