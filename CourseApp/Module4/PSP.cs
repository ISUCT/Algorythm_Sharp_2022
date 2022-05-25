using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class PSP
    {
        public static void PSPmet(string q)
        {
            var easyStack = new EasyStack<char>();

            for (int i = 0; i < q.Length; i++)
            {
                easyStack.Push(q[i]);
            }

            int open = 0;
            int clous = 0;

            while (easyStack.Size() > 0)
            {
                if (clous == 0 && easyStack.Peek() == '(')
                {
                    open++;
                    easyStack.POP();
                }
                else if (clous > 0 && easyStack.Peek() == '(')
                {
                    clous--;
                    easyStack.POP();
                }
                else if (easyStack.Peek() == ')')
                {
                    clous++;
                    easyStack.POP();
                }
                else if (clous <= 0 && easyStack.Peek() == ')')
                {
                    clous++;
                    easyStack.POP();
                }
            }

            Console.WriteLine(open + clous);
        }

        public static void Main_PSP()
        {
            string q = Console.ReadLine();
            PSPmet(q);
        }
    }
}
