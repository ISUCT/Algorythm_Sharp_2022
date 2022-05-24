using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class Less1
    {
        public static void TreeW()
        {
            var tree = new Tree<int>();
            string[] numbers = Console.ReadLine().Split(' ');
            int[] arrNumbers = new int[numbers.Length - 1];

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                arrNumbers[i] = int.Parse(numbers[i]);
            }

            for (int i = 0; i < arrNumbers.Length; i++)
            {
                tree.Add(arrNumbers[i]);
            }

            foreach (var item in tree.Children())
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
