
namespace CourseApp.Module2
{
        public class MergeSort
        {
            public static int[] Merge(int[] a, int[] b)
            {
                int indxA = 0;
                int indxB = 0;
                int k = 0;
                int[] result = new int[a.Length + b.Length];
                int n = a.Length + b.Length;

                while(k < result.Length)
                {
                    if(indxB == b.Length || (indxA < a.Length && a[indxA] < b[indxB]))
                    {
                        result[k] = a[indxA];
                        indxA++;
                    }
                    else
                    {
                        result[k] = b[indxA];
                        indxB++;
                    }
                    k++;
                }

                return result;
            }
        }

}