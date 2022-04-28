using System;
using System.Collections.Generic;
using System.Text;

namespace CourseApp.Module3
{
    public class Task1
    {
        public static int GetHash(string str, int primeNumberTwo)
        {
            ulong hash = 0;
            for (int i = 0; i < str.Length; i++)
            {
                hash += (ulong)(str[i] - 'A') * (ulong)Math.Pow(primeNumberTwo, str.Length - 1 - i);
            }

            return (int)(hash % 5);
        }

        public static int NewHash(string str, char add, int hash, int primeNumberTwo, int primeNumber)
        {
            var newHash = (ulong)(hash * primeNumberTwo) - ((str[0] - 'A') * Math.Pow(primeNumberTwo, str.Length));
            newHash += add - 'A';
            newHash %= primeNumber;
            newHash = (newHash + primeNumber) % primeNumber;
            return (int)newHash;
        }

        public static string RabinCarp()
        {
            string strOne = Console.ReadLine();
            string strTwo = Console.ReadLine();
            int primeNumber = 7;
            int primeNumberTwo = 5;
            var hashStrTwo = GetHash(strTwo, primeNumberTwo);
            var hashStrOne = GetHash(strOne.Substring(0, strTwo.Length), primeNumberTwo);
            var result = new List<int>();
            for (int i = 0; i <= strOne.Length - strTwo.Length; i++)
            {
                if (hashStrTwo == hashStrOne)
                {
                    var flag = true;
                    for (int j = 0; j < strTwo.Length; j++)
                    {
                        if (strTwo[j] != strOne[i + j])
                        {
                            flag = false;
                            break;
                        }
                    }

                    if (flag)
                    {
                        result.Add(i);
                    }
                }

                if ((i + strTwo.Length) < strOne.Length)
                {
                    hashStrOne = NewHash(strOne.Substring(i, strTwo.Length), strOne[i + strTwo.Length], hashStrOne, primeNumberTwo, primeNumber);
                }
            }

            return string.Join(" ", result);
        }

        public static void Task1Main()
        {
            Console.WriteLine(RabinCarp());
        }
    }
}