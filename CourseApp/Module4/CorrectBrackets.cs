using System;
using System.Collections.Generic;
using System.Text;
using CourseApp.Module4;

namespace CourseApp.Module4
{
    public class CorrectBrackets
    {
        public static void Brackets()
        {
            int counter = 0;
            string str = Console.ReadLine();
            Stack brackets = new Stack(str.Length);
            foreach (char item in str)
            {
                if (item == '(')
                {
                    brackets.Push(item);
                }
                else if (brackets.Empty() == false && item == ')')
                {
                    brackets.Pop();
                }
                else
                {
                    counter++;
                }
            }

            Console.WriteLine(counter + brackets.Count);
        }
    }
}
