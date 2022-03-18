using System;

public class CyclicShift
{
    public static void CyclicShiftMethod()
    {
        string subString = Console.ReadLine();
        string basedString = Console.ReadLine();

        if (basedString.GetHashCode() == subString.GetHashCode())
        {
            Console.WriteLine(0);
        }
        else
        {
            Console.WriteLine(FindShifting(subString, basedString));
        }
    }

    public static int FindShifting(string s, string t)
    {
        for (int i = 0; i < s.Length; i++)
        {
            char temp1 = s[s.Length - 1];
            string temp2 = s.Substring(0, s.Length - 1);
            s = temp1 + temp2;
            if (Equal(s, t) == true)
            {
                return i + 1;
            }
        }

        return -1;
    }

    public static bool Equal(string s, string t)
    {
        int hashS = s.GetHashCode();
        int hashT = t.GetHashCode();

        if (hashS == hashT)
        {
            return true;
        }

        return false;
    }
}