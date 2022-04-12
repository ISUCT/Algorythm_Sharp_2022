using System;
using System.IO;

namespace CourseApp.Module4
{
    public class CorrectBracketSequence
    {
        public static void CountFails()
        {
            StreamReader reader = new StreamReader("input.txt");
            string data = reader.ReadLine();
            reader.Close();

            Stack bracket = new Stack(data.Length);
            int fails = 0;
            foreach (char item in data)
            {
                switch (item)
                {
                    case '(':
                    {
                        bracket.Push(Convert.ToInt32('('));
                    }

                    break;
                    case ')':
                    {
                        if (!bracket.Empty())
                        {
                            bracket.Back();
                            bracket.Pop();
                        }
                        else
                        {
                            fails++;
                        }
                    }

                    break;
                    default:
                    break;
                }
            }

            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(bracket.Size() + fails);
            output.Close();
        }
    }
}