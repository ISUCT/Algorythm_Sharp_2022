using System;
using System.Collections.Generic;

namespace CourseApp.Module4
{
    public class Psp
    {
        public static void PspMethod()
        {
            string brackets = Console.ReadLine();
            Stack<char> bracketsStack = new Stack<char>(brackets.Length);
            for (int i = 0; i < brackets.Length; i++)
            {
                bracketsStack.Push(brackets[i]);
            }

            int closedCounter = 0;
            int openCounter = 0;
            while (bracketsStack.Count > 0)
            {
                if (closedCounter == 0 && bracketsStack.Peek() == '(')
                {
                    openCounter++;
                    bracketsStack.Pop();
                }
                else if (closedCounter > 0 && bracketsStack.Peek() == '(')
                {
                    closedCounter--;
                    bracketsStack.Pop();
                }
                else if (bracketsStack.Peek() == ')')
                {
                    closedCounter++;
                    bracketsStack.Pop();
                }
                else if (closedCounter <= 0 && bracketsStack.Peek() == ')')
                {
                    closedCounter++;
                    bracketsStack.Pop();
                }
            }

            Console.WriteLine(openCounter + closedCounter);
        }
    }
}
