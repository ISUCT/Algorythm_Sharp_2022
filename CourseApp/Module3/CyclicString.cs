using System;

namespace CourseApp.Module3
{
    public class CyclicString
    {
        public static int[] PrfxFunction(string k)
        {
            int[] result = new int[k.Length];
            result[0] = 0;

            for (int g = 0; g < k.Length - 1; g++)
            {
                int j = result[g];

                while (j > 0 && k[g + 1] != k[j])
                {
                    j = result[j - 1];
                }

                if (k[g + 1] == k[j])
                {
                    result[g + 1] = j + 1;
                }
                else
                {
                    result[g + 1] = 0;
                }
            }

            return result;
        }

        public static void ClassMain()
        {
            string k = Console.ReadLine();

            int[] prefixK = PrfxFunction(k);

            int result = k.Length - prefixK[k.Length - 1];

            Console.WriteLine(result);
        }
    }
}