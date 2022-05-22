using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Module5
{
    public class SegmentGCD
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] orber = Console.ReadLine().Trim().Split(' ').Select(k => Convert.ToInt32(k)).ToArray();
            int do_count = int.Parse(Console.ReadLine());
            Segment tree = new Segment(size);
            tree.Build(orber);
            List<int> res = new List<int>();
            for (int i = 0; i < do_count; i++)
            {
                int[] b = Console.ReadLine().Trim().Split(' ').Select(k => Convert.ToInt32(k)).ToArray();
                res.Add(tree.GetGCD(b[0], b[1]));
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
    public class Segment
    {
        private int[] segments;

        private int size;

        public Segment(int input)
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

        public void Build(int[] orber)
        {
            HereBuild(0, 0, size, orber);
        }

        public int GetGCD(int do_left, int query_right)
        {
            return HereGCD(0, 0, size, segments, do_left - 1, query_right);
        }

        private void HereBuild(int index, int left, int right, int[] orber)
        {
            if (right - left == 1)
            {
                segments[index] = orber[left];
                return;
            }

            int half = (left + right) / 2;
            HereBuild((2 * index) + 1, left, half, orber);
            HereBuild((2 * index) + 2, half, right, orber);
            segments[index] = GCD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private int HereGCD(int index, int left, int right, int[] segment, int do_left, int do_right)
        {
            if (do_left <= left && do_right >= right)
            {
                return segment[index];
            }

            if (do_left >= right || do_right <= left)
            {
                return 0;
            }

            int h = (left + right) / 2;
            int concl_left = HereGCD((2 * index) + 1, left, h, segment, do_left, do_right);
            int concl_right = HereGCD((2 * index) + 2, h, right, segment, do_left, do_right);
            return GCD(concl_left, concl_right);
        }
    }
}