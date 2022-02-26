using System;
using System.Linq;

namespace CourseApp.Module2;

public class InputHandler
{
    public static int[] ArrayHandler()
    {
        var countElems = Convert.ToInt32(Console.ReadLine());
        var array = new int[countElems];
        var inputStrings = Console.ReadLine().Split();
        for (var i = 0; i < countElems; i++)
        {
            array[i] = Convert.ToInt32(inputStrings[i]);
        }

        return array;
    }
}