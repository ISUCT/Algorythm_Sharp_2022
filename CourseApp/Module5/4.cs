using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Module5
{
    public class IndexOfNulls
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[] orber = Console.ReadLine().Trim().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
            int query_count = int.Parse(Console.ReadLine());
            Segment tree = new Segment(size);
            tree.Build(orber);
            List<int> res = new List<int>();
            for (int i = 0; i < query_count; i++)
            {
                int[] comands = Console.ReadLine().Trim().Split(' ').Select(a => Convert.ToInt32(a)).ToArray();
                res.Add(tree.GetIndex(comands[0], comands[1], comands[2]));
            }

            Console.WriteLine(string.Join(" ", res));
        }
    }
    public class Segment
    {
        private List<int>[] segments;

        private int size;

        public Segment(int input)
        {
            segments = new List<int>[4 * input];
            size = input;
        }

        public List<int> Check(List<int> x, List<int> y)
        {
            List<int> temp;
            if (x.Count() == 0 && y.Count() != 0)
            {
                temp = new List<int>(y);
                return temp;
            }
            else if (x.Count() != 0 && y.Count() != 0)
            {
                temp = new List<int>(x);
                temp.AddRange(y);
                return temp;
            }

            temp = new List<int>(x);
            return temp;
        }

        public void Build(int[] orber)
        {
            HereBuild(0, 0, size, orber);
        }

        public int GetIndex(int do_left, int do_right, int find)
        {
            bool trigger = true;
            List<int> buf = HereGetIndex(0, 0, size, segments, do_left - 1, do_right, ref find, ref trigger);
            if (buf.Count() < find)
            {
                return -1;
            }
            else
            {
                return buf.ElementAt(find - 1);
            }
        }

        private void HereBuild(int index, int left, int right, int[] numbers)
        {
            if (right - left == 1)
            {
                segments[index] = new List<int>();
                if (numbers[left] == 0)
                {
                    segments[index].Add(left + 1);
                }

                return;
            }

            int half = (left + right) / 2;
            HereBuild((2 * index) + 1, left, half, numbers);
            HereBuild((2 * index) + 2, half, right, numbers);
            segments[index] = Check(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private List<int> HereGetIndex(int index, int left, int right, List<int>[] segment, int do_left, int do_right, ref int find, ref bool q)
        {
            if (!q)
            {
                return new List<int>();
            }

            if (do_left <= left && do_right >= right)
            {
                return segment[index];
            }

            if (do_left >= right || do_right <= left)
            {
                return new List<int>();
            }

            int h = (left + right) / 2;
            List<int> conclusion_left = HereGetIndex((2 * index) + 1, left, h, segment, do_left, do_right, ref find, ref q);
            if (conclusion_left.Count() != 0)
            {
                if (conclusion_left.Count() < find)
                {
                    find -= conclusion_left.Count();
                }
                else
                {
                    q = false;
                    return conclusion_left;
                }
            }

            List<int> conclusion_right = HereGetIndex((2 * index) + 2, h, right, segment, do_left, do_right, ref find, ref q);
            if (conclusion_right.Count() != 0)
            {
                if (conclusion_right.Count() < find)
                {
                    find -= conclusion_right.Count();
                }
                else
                {
                    q = false;
                    return conclusion_right;
                }
            }

            return new List<int>();
        }
    }

}