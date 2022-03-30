using System.IO;

namespace CourseApp.Module3
{
    public class StringPeriod
    {
        public static void FindStringEntry()
        {
            StreamReader reader = new StreamReader("input.txt");
            string data = reader.ReadLine();
            reader.Close();

            long simp_numb = 9999993;
            int alphabet = 26;
            int count = GetCountOfRepeating(data, alphabet, simp_numb);
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(count);
            output.Close();
        }

        public static int GetCountOfRepeating(string text, int alphabet, long simp_numb)
        {
            int size = text.Length;
            int count = 1;

            for (int i = 2; i <= (size / 2) + 1; i++)
            {
                if (size % i != 0)
                {
                    continue;
                }

               count = CheckEqual(i, size, count, text, alphabet, simp_numb);
            }

            count = CheckEqual(size, size, count, text, alphabet, simp_numb);

            return count;
        }

        public static int CheckEqual(int i, int size, int count, string text, int alphabet, long simp_numb)
        {
            long[] buffer = new long[i];
            for (int j = 0; j < buffer.Length; j++)
            {
                long hash = 0;
                for (int k = (size / i) * j; k < ((size / i) * j) + (size / i); k++)
                {
                    hash = ((hash * alphabet) + text[k]) % simp_numb;
                }

                buffer[j] = hash;
                if (j > 0)
                {
                    if (buffer[j] != buffer[j - 1])
                    {
                        break;
                    }
                }
            }

            if (size > 1)
            {
                if ((buffer[buffer.Length - 1] != 0) && (buffer[buffer.Length - 1] == buffer[buffer.Length - 2]))
                {
                    count = i;
                } 
            }

            return count;
        }
    }
}