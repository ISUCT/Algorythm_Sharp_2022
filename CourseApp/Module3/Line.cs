using System;

namespace CourseApp.Module3
{
    public class Line
    {
        public static void Line_Main()
        {
            int i = 0;
            int x = -1;
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            while (i != -1)
            {
                i = s.IndexOf(t, x + 1);
                if (i != -1)
                {
                    Console.Write(i + " ");
                }

                x = i;
            }
        }
    }
}
