using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module3
{
    public class RabinKarp
    {
        public static void FindStringEntry()
        {
            StreamReader reader = new StreamReader("input.txt");
            string data = reader.ReadLine();
            string pattern = reader.ReadLine();
            reader.Close();

            int simp_numb = 117;
            int alphabet = 26;
            List<int> index = new List<int>();
            RabinKarpAlgorythm(index, data, pattern, alphabet, simp_numb);
            StreamWriter output = new StreamWriter("output.txt");
            output.WriteLine(string.Join(" ", index));
            output.Close();
        }

        public static void RabinKarpAlgorythm(List<int> index, string text, string pattern, int alphabet, int simp_numb)
        {
            int basis = 1;
            int txt_size = text.Length;
            int pat_size = pattern.Length;
            for (int i = 0; i < pat_size - 1; i++)
            {
                basis = (basis * alphabet) % simp_numb;
            }

            int hash_pat = 0;
            int hash_text = 0;
            for (int i = 0; i < pat_size; i++)
            {
                hash_pat = ((hash_pat * alphabet) + pattern[i]) % simp_numb;
                hash_text = ((hash_text * alphabet) + text[i]) % simp_numb;
            }

            bool trigger = true;
            for (int i = 0; i <= txt_size - pat_size; i++)
            {
                trigger = true;
                if (hash_pat == hash_text)
                {
                    for (int j = 0; j < pat_size; j++)
                    {
                        if (pattern[j] != text[i + j])
                        {
                            trigger = false;
                            break;
                        }
                    }

                    if (trigger)
                    {
                        index.Add(i);
                    }
                }

                if (i < txt_size - pat_size)
                {
                    hash_text = ((alphabet * (hash_text - (text[i] * basis))) + text[i + pat_size]) % simp_numb;
                    hash_text = (hash_text + simp_numb) % simp_numb;
                }
            }
        }
    }
}