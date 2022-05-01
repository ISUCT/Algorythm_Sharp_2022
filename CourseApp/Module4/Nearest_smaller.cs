using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class Nearest_smaller
    {
        public static void Nearest_smaller_Method(int coll, string[] data)
        {
            var easyStack = new EasyStack<int>();
            int[] arr = new int[coll];
            int[] arrAnswer = new int[coll];

            for (int i = 0; i < coll; i++)
            {
                arr[i] = int.Parse(data[i]);
            }

            for (int i = coll - 1; i >= 0; i--)
            {
                while (easyStack.Size() > 0 && arr[easyStack.Peek()] >= arr[i])
                {
                    easyStack.POP();
                }

                if (easyStack.Size() == 0)
                {
                    arrAnswer[i] = -1;
                }
                else
                {
                    arrAnswer[i] = easyStack.Peek();
                }

                easyStack.Push(i);
            }

            for (int i = 0; i < coll; i++)
            {
                Console.Write($"{arrAnswer[i]} ");
            }
        }

        public static void Nearest_smaller_Main()
        {
            int q = int.Parse(Console.ReadLine());
            string[] data = Console.ReadLine().Split(' ');

            Nearest_smaller_Method(q, data);
        }
    }
}
