namespace CourseApp.Module3
{
    using System;

    public class PeriodString
    {
        public static void PeriodStringMethod()
        {
            string line = Console.ReadLine();
            int[] f = new int[line.Length];
            f[0] = 0;
            for (int i = 0; i < line.Length - 1; i++)
            {
                int current = f[i];
                while (current > 0 && line[i + 1] != line[current])
                {
                    current = f[current - 1];
                }

                if (line[i + 1] == line[current])
                {
                    f[i + 1] = current + 1;
                }
                else
                {
                    f[i + 1] = 0;
                }
            }

            int result = line.Length - f[line.Length - 1];

            if (line.Length % result == 0)
            {
                Console.WriteLine(line.Length / result);
            }
            else
            {
                Console.WriteLine(1);
            }
        }
    }
}
