using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module4
{
    public class DeadEndSort
    {
        public static void Sort()
        {
            bool trigger = true;
            int size = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            string[] trainS = s.Split(' ');
            int[] train = new int[size];
            Stack<int> stackTrain = new Stack<int>(size);
            for (int i = 0; i < size; i++)
            {
                train[i] = int.Parse(trainS[i]);
            }

            Stack sortVien = new Stack(size);
            int[] routeB = new int[size];
            int buff = 0;
            int elem = 1;

            for (int i = 0; i < size; i++)
            {
                sortVien.Push(train[i]);
                if (train[i] == elem)
                {
                    routeB[buff] = sortVien.Peek();
                    sortVien.Pop();
                    buff++;
                    elem++;
                    while (sortVien.Empty() ? false : sortVien.Peek() == elem)
                    {
                        routeB[buff] = sortVien.Peek();
                        sortVien.Pop();
                        buff++;
                        elem++;
                    }
                }
            }

            for (int i = 0; i < size - 1; i++)
            {
                if (routeB[i] > routeB[i + 1])
                {
                    trigger = false;
                    break;
                }
            }

            Console.WriteLine(trigger ? "YES" : "NO");
        }
    }
}
