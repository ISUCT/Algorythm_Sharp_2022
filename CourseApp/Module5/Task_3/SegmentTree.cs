namespace CourseApp.Module5.Task_3
{
    public class SegmentTree
    {
        private int[] segments;

        private int size;

        public SegmentTree(int input)
        {
            segments = new int[4 * input];
            size = input;
        }

        public int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public void Build(int[] numbers)
        {
            InnerBuild(0, 0, size, numbers);
        }

        public int GetGCD(int query_left, int query_right)
        {
            return InnerGetGCD(0, 0, size, segments, query_left - 1, query_right);
        }

        private void InnerBuild(int index, int left, int right, int[] numbers)
        {
            if (right - left == 1)
            {
                segments[index] = numbers[left];
                return;
            }

            int half = (left + right) / 2;
            InnerBuild((2 * index) + 1, left, half, numbers);
            InnerBuild((2 * index) + 2, half, right, numbers);
            segments[index] = GCD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private int InnerGetGCD(int index, int left, int right, int[] segment, int query_left, int query_right)
        {
            if (query_left <= left && query_right >= right)
            {
                return segment[index];
            }

            if (query_left >= right || query_right <= left)
            {
                return 0;
            }

            int half = (left + right) / 2;
            int ans_left = InnerGetGCD((2 * index) + 1, left, half, segment, query_left, query_right);
            int ans_right = InnerGetGCD((2 * index) + 2, half, right, segment, query_left, query_right);
            return GCD(ans_left, ans_right);
        }
    }
}