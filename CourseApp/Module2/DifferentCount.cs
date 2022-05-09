using System;
using System.Collections.Generic;

namespace CourseApp.Module2
{
    public class DifferentCount
    {
        public static void CountDifferent()
        {
            int[] arr = InputParse();
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                set.Add(arr[i]);
            }

            Console.WriteLine(set.Count);
        }

        private static int[] InputParse()
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string s = Console.ReadLine();
            string[] sValues = s.Split(' ');
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]);
            }

            return arr;
        }
    }
}
