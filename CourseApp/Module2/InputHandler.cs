using System;

namespace CourseApp.Module2;

public class InputHandler
{
    public static int[] ArrayHandler()
    {
        int countElems = Convert.ToInt32(Console.ReadLine());
        int[] array = new int[countElems];
        for (int i = 0; i < countElems; i++)
        {
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        return array;
    }
}