using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module3
{
    public class Task2
    {
        public static int MainMethod(string strOne, string strTwo, long ogr, int primeNumber)
        {
            if (strTwo == strOne)
            {
                return 0;
            }

            long oneHash = 0;
            long twoHash = 0;
            long a = 1;
            long b = 1;

            strTwo = string.Concat(Enumerable.Repeat(strTwo, 2));
            foreach (char i in strOne.Reverse())
            {
                oneHash = (oneHash + (i * a)) % ogr;
                a = (a * primeNumber) % ogr;
            }

            a = 1;
            for (int i = strOne.Length - 1; i >= 0; i--)
            {
                twoHash = (twoHash + (strTwo[i] * a)) % ogr;
                a = (a * primeNumber) % ogr;
            }

            for (int i = 0; i < strOne.Length - 1; i++)
            {
                b = (b * primeNumber) % ogr;
            }

            for (int i = 1; i < strTwo.Length - strOne.Length + 1; i++)
            {
                if (oneHash == twoHash)
                {
                    return i - 1;
                }

                twoHash = ((primeNumber * (twoHash - (strTwo[i - 1] * b))) + strTwo[i + strOne.Length - 1]) % ogr;

                if ((twoHash < 0 && ogr > 0) || (twoHash > 0 && ogr < 0))
                {
                    twoHash += ogr;
                }
            }

            return -1;
        }

        public static void Task2Main()
        {
            string strOne = Console.ReadLine();
            string strTwo = Console.ReadLine();
            long ogr = 1000000000;
            int primeNumber = 23;
            Console.WriteLine(MainMethod(strOne, strTwo, ogr, primeNumber));
        }
    }
}
