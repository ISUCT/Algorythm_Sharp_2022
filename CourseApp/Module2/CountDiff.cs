using System;
using System.Collections.Generic;

namespace CourseApp.Module2;

public class CountDiff
{
    public static void Count()
    {
        int s = 0;
        var array = InputHandler.ArrayHandler();
        List<int> digits = new List<int>();
        foreach (var sym in array)
        {
            if (!digits.Contains(sym))
            {
                digits.Add(sym);
            }
            else
            {
                s++;
            }
        }

        Console.WriteLine(digits.Count);
    }
}