using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class TrainStack
    {
        public static void Train(int lens, string[] numb)
        {
            var easyStack = new EasyStack<int>();

            int count = 1;
            bool verefications = true;

            for (int i = 0; i < lens; i++)
            {
                int inp = int.Parse(numb[i]);

                if (easyStack.Size() > 0 && inp > easyStack.Peek())
                {
                    verefications = false;
                    break;
                }

                easyStack.Push(inp);
                while (easyStack.Size() > 0 && count == easyStack.Peek())
                {
                    easyStack.POP();
                    count++;
                }
            }

            if (verefications)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        public static void Main_train()
        {
            int lens = int.Parse(Console.ReadLine());
            string[] numb = Console.ReadLine().Split(' ');

            Train(lens, numb);
        }
    }
}
