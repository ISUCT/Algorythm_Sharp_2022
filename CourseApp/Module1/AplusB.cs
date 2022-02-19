using System;

namespace CourseApp.Module1
{
    public class AplusB
    {
        public static void Calculate()
        {
            string s = Console.ReadLine();
            string[] values = s.Split(' ');
            int a = int.Parse(values[0]);
            int b = int.Parse(values[1]);
            Console.WriteLine(a + b);
        }
    }
}
