using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class Window
    {
        public static void Window_method(int[] collArr, string[] windowA)
        {
            var easyDeque = new EasyDeque<int>();

            int sizearray = collArr[0];

            int sizewindow = collArr[1];

            int[] windowArr = new int[sizearray];

            for (int i = 0; i < sizearray; i++)
            {
                windowArr[i] = int.Parse(windowA[i]);
            }

            for (int i = 0; i < sizearray;)
            {
                while (easyDeque.Size() < sizewindow)
                {
                    easyDeque.PushFront(windowArr[i]);

                    i++;
                }

                Console.WriteLine(easyDeque.Min());
                easyDeque.POPback();
            }
        }

        public static void Window_Main()
        {
            string[] coll = Console.ReadLine().Split(' ');

            int[] collArray = new int[coll.Length];

            for (int i = 0; i < coll.Length; i++)
            {
                collArray[i] = int.Parse(coll[i]);
            }

            string[] windowArr = Console.ReadLine().Split(' ');

            Window_method(collArray, windowArr);
        }
    }
}