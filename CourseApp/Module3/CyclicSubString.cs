using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module3
{
    public class CyclicSubString
    {
        public static void FindStringEntry()
        {
            StreamReader reader = new StreamReader("input.txt");
            string data = reader.ReadLine();
            reader.Close();
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(data.Length - Prefix(data)[data.Length - 1]);
            output.Close();
        }

        public static int[] Prefix(string input)
        {
            int[] result = new int[input.Length];
            result[0] = 0;
            for (int i = 0; i < input.Length - 1; i++)
            {
                int buffer = result[i];
                while (buffer > 0 && input[i + 1] != input[buffer])
                {
                    buffer = result[buffer - 1];
                }

                if (input[i + 1] == input[buffer])
                {
                    result[i + 1] = buffer + 1;
                }
                else
                {
                    result[i + 1] = 0;
                }
            }

            return result;
        }
    }
}