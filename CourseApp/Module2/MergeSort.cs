
namespace CourseApp.Module2
{
    public class MergeSort
    {

        public static int[] Merge(int[] a, int[] b)
        {
            int idxA = 0;
            int idxB = 0;
            int k = 0;
            int[] result = new int[a.Length + b.Length];
            while (k < result.Length)
            {
                // || - или     && - и
                if (idxB == b.Length || (idxA < a.Length && a[idxA] < b[idxB]))
                {
                    result[k] = a[idxA];
                    idxA++;
                }
                else
                {
                    result[k] = b[idxB];
                    idxB++;
                }

                k++;
            }

            return result;
        }

        public static int[] MergeSorting(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }

            var (left, right) = Split(array);
            left = MergeSorting(left);
            right = MergeSorting(right);
            return Merge(left, right);
        }

        public static (int[], int[]) Split(int[] array)
        {
            var len = array.Length / 2;
            int[] left = new int[len];
            for (int i = 0; i < len; i++)
            {
                left[i] = array[i];
            }

            len = (array.Length / 2) + (array.Length % 2);
            int[] right = new int[len];

            for (int i = 0; i < len; i++)
            {
                right[i] = array[i + len - (array.Length % 2)];
            }

            return (left, right);
        }
    }
}
