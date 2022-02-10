using System;
using CourseApp.Module2;

namespace CourseApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            int[] array = new int[Convert.ToInt32(Console.ReadLine())];
            string[] s = Console.ReadLine().Split(' ');
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(s[i]);
            }
            
            BubbleSort.BubbleSortMethod(array.Length, array);
            Console.WriteLine("Hello World");
        }
    }
}
