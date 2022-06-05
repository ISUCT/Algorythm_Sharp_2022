using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseApp.Module4
{
    public class MinSegments
    {
        public static void MinSegmentsMethod()
        {
            int[] arraySizes = Console.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();
            int masSize = arraySizes[0];
            int winSize = arraySizes[1];
            int[] arrayElements = Console.ReadLine().Trim().Split(" ").Select(n => Convert.ToInt32(n)).ToArray();

            Queue mins = new Queue(masSize);
            for (int i = 0; i < winSize; i++)
            {
                while (!mins.Empty() && mins.Back() > arrayElements[i])
                {
                    mins.PopB();
                }

                mins.PushB(arrayElements[i]);
            }

            Console.WriteLine(mins.Front());
            for (int i = winSize; i < masSize; i++)
            {
                while (!mins.Empty() && mins.Back() > arrayElements[i])
                {
                    mins.PopB();
                }

                mins.PushB(arrayElements[i]);
                if (!mins.Empty() && mins.Front() == arrayElements[i - winSize])
                {
                    mins.PopF();
                }

                Console.WriteLine(mins.Front());
            }
        }
    }
}
