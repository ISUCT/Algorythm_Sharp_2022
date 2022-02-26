using System;
using System.Collections.Generic;

namespace CourseApp.Module2;

public class CountDiff
{
    public static void Count()
    {
        var array = InputHandler.ArrayHandler();
        List<int> digits = new List<int>();
        foreach (var sym in array)
        {
            if (!digits.Contains(sym))
            {
                digits.Add(sym);
            }
        }

        Console.WriteLine(digits.Count);
    }
}