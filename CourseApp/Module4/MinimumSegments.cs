using System;

public class MinimumSegments
{
    public static void Main()
    {
        string nF = Console.ReadLine();
        string[] First = nF.Split(' ');
        int[] massF = new int[2];
        for (int i = 0; i < 2; i++)
        {
            massF[i] = int.Parse(First[i]);
        }
        string nS = Console.ReadLine();
        string[] Second = nS.Split(' ');
        int[] massS = new int[massF[0]];
        for (int i = 0; i < massF[0]; i++)
        {
           massS[i] = int.Parse(Second[i]);
        }
        for (int i = 0; i < massF[1]; i++)
        {
            while (Segments.Empty() == false && massS[i] < massS[Segments.Begin()])
            {
                Segments.Pop_Front();
            }

            Segments.Push_First(i);
        }
        for (int i = massF[1]; i < massF[0]; i++)
        {
            Console.WriteLine(massS[Segments.Ago()]);

            while (Segments.Empty() == false && Segments.Ago() <= i - massF[1])
            {
                Segments.Pop_Ago();
            }
            while (Segments.Empty() == false && massS[i] < massS[Segments.Begin()])
            {
                Segments.Pop_Front();
                if (Segments.Size() == 0)
                {
                    Segments.Clear();
                }
            }
            Segments.Push_First(i);
        }

        Console.WriteLine(massS[Segments.Ago()]);
    }
    private class Segments
    {
        private static int[] buffer = new int[100000001];
        private static int a = 0;
        private static int b = 100000001 - 1;
        private static int c = 0;
        public static void Push_Ago(int t)
        {
            b++;
            if (b == 100000001)
            {
                b = 0;
            }

            buffer[b] = t;
            c++;
        }
        public static void Push_First(int o)
        {
            a--;
            if (a < 0)
            {
                a = 100000001 - 1;
            }

            buffer[a] = o;
            c++;
        }

        public static void Pop_Ago()
        {
            b--;
            if (b < 0)
            {
                b = 100000001 - 1;
            }

            c--;
        }

        public static void Pop_Front()
        {
            a++;
            if (a == 100000001)
            {
                a = 0;
            }

            c--;
        }

        public static void Clear()
        {
            a = 0;
            b = 100000001 - 1;
            c = 0;
        }

        public static int Begin()
        {
            return buffer[a];
        }

        public static int Ago()
        {
            return buffer[b];
        }

        public static int Size()
        {
            return c;
        }

        public static bool Empty()
        {
            return c == 0;
        }
    }
}