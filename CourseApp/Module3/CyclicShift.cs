using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module3
{
    public class CyclicShift
    {
        public static void FindStringEntry()
        {
            StreamReader reader = new StreamReader("input.txt");
            string data = reader.ReadLine();
            string key = reader.ReadLine();
            reader.Close();

            long simp_numb = 9999993;
            int alphabet = 26;
            int count = RabinKarpAlgorythm(data, key, alphabet, simp_numb);
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(count);
            output.Close();
        }

        public static int RabinKarpAlgorythm(string text, string key, int alphabet, long simp_numb)
        {
            int count = 0;
            long basis = 1;
            int size = text.Length;
            text = text + text;
            for (int i = 0; i < size - 1; i++)
            {
                basis = (basis * alphabet) % simp_numb;
            }

            long hash_key = 0;
            long hash_text = 0;
            for (int i = size - 1; i >= 0; i--)
            {
                hash_key = ((hash_key * alphabet) + key[i]) % simp_numb;
                hash_text = ((hash_text * alphabet) + text[i]) % simp_numb;
            }

            for (int i = size; i >= 0; i--)
            {
                bool trigger = true;
                if (hash_key == hash_text)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (key[j] != text[i + j])
                        {
                            trigger = false;
                        }
                    }

                    if (trigger)
                    {
                        return count;
                    }
                }

                count++;
                if (i != 0)
                {
                    hash_text = ((alphabet * (hash_text - (text[i + size - 1] * basis))) + text[i - 1]) % simp_numb;
                    hash_text = (hash_text + simp_numb) % simp_numb;
                }
            }

            return -1;
        }
    }
}