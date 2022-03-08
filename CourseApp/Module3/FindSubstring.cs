using System;

public class FindSubstring
{
    public static void FindSubstringMethod()
    {
        string basedString = Console.ReadLine();
        string subString = Console.ReadLine();

        int numberOfValues = 26;
        int maxLength = 50001;

        RabinKarp(basedString, subString, numberOfValues, maxLength);
    }

    public static void RabinKarp(string s, string t, int x, int p)
    {
        int hashT = GetHash(t, t.Length, p, x);
        int hashS = GetHash(s, t.Length, p, x);
        int xt = 1;

        for (int i = 0; i < t.Length; i++)
        {
            xt = (xt * x) % p;
        }

        for (int i = 0; i <= s.Length - t.Length; i++)
        {
            if (hashS == hashT)
            {
                if (s.Substring(i, t.Length) == t)
                {
                    Console.Write(i + " ");
                }
            }

            if (i + t.Length < s.Length)
            {
                hashS = ((hashS * x) - (s[i] * xt) + s[i + t.Length]) % p;
                hashS = (hashS + p) % p;
            }
        }
    }

    public static int GetHash(string s, int len, int p, int x)
    {
        int result = 0;

        for (int i = 0; i < len; i++)
        {
            result = ((result * x) + s[i]) % p;
        }

        return result;
    }
}