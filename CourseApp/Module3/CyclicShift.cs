using System;

public class CyclicShift
{
    public static void CyclicShiftMethod()
    {
        string subString = Console.ReadLine();
        string basedString = Console.ReadLine();
        subString = ReverseString(subString);
        basedString = ReverseString(basedString);
        int numberOfValues = 26;
        int maxLength = 10000000 - 7;

        Console.WriteLine(FindShifting(subString, basedString, numberOfValues, maxLength));
    }

    public static int FindShifting(string subString, string basedString, int numberOfValues, int maxLength)
    {
        int hashB = GetHash(basedString, basedString.Length, maxLength, numberOfValues);
        int hashS = GetHash(subString, subString.Length, maxLength, numberOfValues);
        int xt = 1;

        if (hashB == hashS)
        {
            return 0;
        }
        else if (subString.Length == 1)
        {
            return -1;
        }
        else
        {
            basedString = subString + subString;

            for (int i = 0; i < subString.Length; i++)
            {
                xt = (xt * numberOfValues) % maxLength;
            }

            for (int i = 1; i < subString.Length + 1; i++)
            {
                if (hashB == hashS)
                {
                    return i - 1;
                }

                hashS = ((hashS * numberOfValues) - (subString[i - 1] * xt) + basedString[i + subString.Length - 1]) % maxLength;
                hashS = (hashS + maxLength) % maxLength;
            }
        }

        return -1;
    }

    public static int GetHash(string s, int lengthOfString, int maxLength, int numberOfValues)
    {
        int result = 0;

        for (int i = 0; i < lengthOfString; i++)
        {
            result = ((result * numberOfValues) + s[i]) % maxLength;
        }

        return result;
    }

    public static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}