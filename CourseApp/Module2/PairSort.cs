using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module2
{
    public class PairSort
    {
        public static void PairSortMethod()
        {
            int[,] arr = InputParse();

            int n = arr.Length / 2;

            SortArrFirst(ref arr, ref n);
            SortArrSecond(ref arr, ref n);
            Show(ref arr, ref n);
        }

        private static void SortArrFirst(ref int[,] arr, ref int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1, 1] > arr[j, 1])
                    {
                        Swap(ref arr[j, 0], ref arr[j + 1, 0]);
                        Swap(ref arr[j, 1], ref arr[j + 1, 1]);
                    }
                }
            }
        }

        private static void SortArrSecond(ref int[,] arr, ref int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j + 1, 1] == arr[j, 1] && arr[j + 1, 0] < arr[j, 0])
                    {
                        Swap(ref arr[j, 0], ref arr[j + 1, 0]);
                        Swap(ref arr[j, 1], ref arr[j + 1, 1]);
                    }
                }
            }
        }

        private static int[,] InputParse()
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n, 2];
            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                string[] sValues = s.Split(' ');
                for (int j = 0; j < 2; j++)
                {
                    arr[i, j] = int.Parse(sValues[j]);
                }
            }

            return arr;
        }

        private static void Show(ref int[,] arr, ref int n)
        {
            string result = null;
            for (int i = 0; i < n; i++)
            {
                result = arr[i, 0] + " " + arr[i, 1];
                Console.Write(result);
                Console.WriteLine();
            }
        }

        private static void Swap(ref int left, ref int right)
        {
            int temp = right;
            right = left;
            left = temp;
        }
    }
}
