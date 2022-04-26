using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace CourseApp.Module5.Task_6
{
    public class DynamicSegmentTree
    {
        private List<int>[] segments;

        private int size;

        public DynamicSegmentTree(int input)
        {
            segments = new List<int>[4 * input];
            size = input;
        }

        public List<int> Check(List<int> a, List<int> b)
        {
            List<int> temp;
            if (a.Count() == 0 && b.Count() != 0)
            {
                temp = new List<int>(b);
                return temp;
            }
            else if (a.Count() != 0 && b.Count() != 0)
            {
                temp = new List<int>(a);
                temp.AddRange(b);
                return temp;
            }

            temp = new List<int>(a);
            return temp;
        }

        public void Build(int[] numbers)
        {
            InnerBuild(0, 0, size, numbers);
        }

        public void Update (int index, bool trigger)
        {
            int pos = 0;
            InnerUpdate(0, 0, size, segments, index - 1, trigger, ref pos);
        }

        public int GetIndex(int query_left, int query_right, int find)
        {
            bool trigger = true;
            List<int> buf = InnerGetIndex(0, 0, size, segments, query_left - 1, query_right, ref find, ref trigger);
            if (buf.Count() < find)
            {
                return -1;
            }
            else
            {
                return buf.ElementAt(find - 1);
            }
        }

        private void InnerBuild(int index, int left, int right, int[] numbers)
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
            InnerBuild((2 * index) + 1, left, half, numbers);
            InnerBuild((2 * index) + 2, half, right, numbers);
            segments[index] = Check(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private void InnerUpdate (int index, int left, int right, List<int>[] segments, int upd_index, bool trigger, ref int pos)
        {
            if (right - left == 1)
            {
                segments[index] = new List<int>();
                if (trigger)
                {
                    segments[index].Add(upd_index + 1);
                }

                return;
            }

            int half = (left + right) / 2;
            if (upd_index < half)
            {
                InnerUpdate((2 * index) + 1, left, half, segments, upd_index, trigger, ref pos);
                if (trigger)
                {
                    segments[index].Insert(pos, upd_index + 1);
                }
                else
                {
                    segments[index].Remove(upd_index + 1);
                }
            }
            else
            {
                InnerUpdate((2 * index) + 2, half, right, segments, upd_index, trigger, ref pos);
                if (trigger)
                {
                    if (segments[index].Count() == 0)
                    {
                        segments[index].Add(upd_index + 1);
                    }
                    else if (segments[(2 * index) + 2].Count() == 1)
                    {
                        pos = segments[index].Count();
                        segments[index].Add(upd_index + 1);
                    }
                    else
                    {
                        int dif = segments[index].Count() - segments[(2 * index) + 2].Count();
                        if (dif <= 0)
                        {
                            pos++;
                            segments[index].Insert(pos, upd_index + 1);
                        }
                        else
                        {
                            pos += dif;
                            segments[index].Insert(pos, upd_index + 1);
                        }
                    }
                }
                else
                {
                    segments[index].Remove(upd_index + 1);
                }
            }
        }

        private List<int> InnerGetIndex(int index, int left, int right, List<int>[] segments, int query_left, int query_right, ref int find, ref bool trigger)
        {
            if (trigger == false)
            {
                return new List<int>();
            }

            if (query_left <= left && query_right >= right)
            {
                return segments[index];
            }

            if (query_left >= right || query_right <= left)
            {
                return new List<int>();
            }

            int half = (left + right) / 2;
            List<int> ans_left = InnerGetIndex((2 * index) + 1, left, half, segments, query_left, query_right, ref find, ref trigger);
            if (ans_left.Count() != 0)
            {
                if (ans_left.Count() < find)
                {
                    find -= ans_left.Count();
                }
                else
                {
                    trigger = false;
                    return ans_left;
                }
            }

            List<int> ans_right = InnerGetIndex((2 * index) + 2, half, right, segments, query_left, query_right, ref find, ref trigger);
            if (ans_right.Count() != 0)
            {
                if (ans_right.Count() < find)
                {
                    find -= ans_right.Count();
                }
                else
                {
                    trigger = false;
                    return ans_right;
                }
            }

            return new List<int>();
        }
    }
}