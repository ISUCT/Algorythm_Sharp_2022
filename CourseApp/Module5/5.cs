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
            int[] orber = Console.ReadLine().Trim().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
            int do_count = int.Parse(Console.ReadLine());
            DynamicSegment dy_tree = new DynamicSegment(size);
            dy_tree.Build(orber);
            List<int> res = new List<int>();
            for (int i = 0; i < do_count; i++)
            {
                string[] borders = Console.ReadLine().Trim().Split(' ').ToArray();
                if (borders[0] == "u")
                {
                    dy_tree.Update(int.Parse(borders[1]), int.Parse(borders[2]));
                }
                else
                {
                    res.Add(dy_tree.GetGCD(int.Parse(borders[1]), int.Parse(borders[2])));
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
    public class DynamicSegment
    {
        private int[] segments;

        private int size;

        public DynamicSegment(int input)
        {
            segments = new int[4 * input];
            size = input;
        }

        public int GCD(int x, int y)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }

            return x;
        }

        public void Build(int[] orber)
        {
            HereBuild(0, 0, size, orber);
        }

        public void Update(int index, int value)
        {
            HereUpdate(0, 0, size, segments, index - 1, value);
        }

        public int GetGCD(int do_left, int do_right)
        {
            return HereGetGCD(0, 0, size, segments, do_left - 1, do_right);
        }

        private void HereBuild(int index, int left, int right, int[] orber)
        {
            if (right - left == 1)
            {
                segments[index] = orber[left];
                return;
            }

            int h = (left + right) / 2;
           HereBuild((2 * index) + 1, left, h, orber);
            HereBuild((2 * index) + 2, h, right, orber);
            segments[index] = GCD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private void HereUpdate(int index, int left, int right, int[] segment, int vd_index, int value)
        {
            if (right - left == 1)
            {
                segments[index] = value;
                return;
            }

            int h = (left + right) / 2;
            if (vd_index < h)
            {
                HereUpdate((2 * index) + 1, left, h, segment, vd_index, value);
            }
            else
            {
                HereUpdate((2 * index) + 2, h, right, segment, vd_index, value);
            }

            segments[index] = GCD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private int HereGetGCD(int index, int left, int right, int[] segment, int do_left, int do_right)
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
            int conclusion_left = HereGetGCD((2 * index) + 1, left, h, segment, do_left, do_right);
            int conclusion_right = HereGetGCD((2 * index) + 2, h, right, segment, do_left, do_right);
            return GCD(conclusion_left, conclusion_right);
        }
    }
}
