using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class Warehouse
    {
        public static void WarehouseSort(int[] arrA, int[] arrB, int k)
        {
            int a = 0;
            int b = 0;
            int[] c = new int[k + 1];
            int[] arrOrds = new int[k];
            for (int i = 0; i < arrB.Length; i++)
            {
                c[arrB[i]]++;
            }
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] != 0)
                {
                    arrOrds[a++] = c[i];
                    if (arrA[b] >= arrOrds[b])
                    {
                        Console.WriteLine("no");
                    }
                    else
                    {
                        Console.WriteLine("yes");
                    }

                    b++;
                }
            }
        }
        private static string[] sValues = null;
        public static void WarehouseMain()
        {
            int a = int.Parse(Console.ReadLine());
            string s = Console.ReadLine();
            sValues = s.Split(' ');
            int[] arrA = new int[a];
            for (int i = 0; i < arrA.Length; i++)
            {
                arrA[i] = int.Parse(sValues[i]);
            }

            int b = int.Parse(Console.ReadLine());
            s = Console.ReadLine();
            sValues = s.Split(' ');
            int[] arrB = new int[b];
            for (int i = 0; i < arrB.Length; i++)
            {
                arrB[i] = int.Parse(sValues[i]);
            }
            WarehouseSort(arrA, arrB, arrA.Length);
        }
    }
}
