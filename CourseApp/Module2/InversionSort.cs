using System;

namespace CourseApp.Module2
{
    public class InversionSort
    {
        private static long inversion = 0;

        public static void MergeSortMethod()
        {
            int[] arr = InputParse(); 

            int[] sortedArr = ArrSort(ref arr, 0, arr.Length); 

            Console.WriteLine("{0}", string.Join(" ", sortedArr));
        }

        private static int[] Merge(ref int[] left, ref int[] right) 
        {
            int i = 0;
            int j = 0;
            int[] add = new int[left.Length + right.Length];
            for (int k = 0; k < add.Length; k++)
            {
                if (i == left.Length)
                {
                    add[k] = right[j];
                    j++;
                }
                else if (j == right.Length || left[i] <= right[j])
                {
                    add[k] = left[i];
                    i++;
                }
                else
                {
                    add[k] = right[j];
                    j++;
                }
            }

            return add;
        }

        private static int[] ElementsSort(ref int[] order, int left, int right)
        {
            if (right - left == 1)  
            {
                int[] res = new int[1]; 
                res[0] = order[left]; 
                return res; 
            }

            int mid = (left + right) / 2; 

            int[] leftEl = ElementsSort(ref order, left, mid); 
            int[] rightEl = ElementsSort(ref order, mid, right); 

            int[] sort = Merge(ref leftEl, ref rightEl) 

            return sort;
        }

        private static void InputParse()
        {
            int n = int.Parse(Console.ReadLine()); 
            int[] arr = new int[n]; 
            string s = Console.ReadLine(); 
            string[] sValues = s.Split(' '); 
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(sValues[i]); 
            }

            Console.WriteLine(inversion);
        }
    }
}