using System;
using System.Collections.Generic;
using System.Linq;

public class Subsegment
{
    public static void SubsegmentMethod()
    {
        int size = int.Parse(Console.ReadLine());
        string[] numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int requests = int.Parse(Console.ReadLine());
        List<int> result = new List<int>();

        SubsegmentTree tree = new SubsegmentTree(size);
        tree.Convert(numbers);

        for (int i = 0; i < requests; i++)
        {
            string[] comands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            result.Add(tree.GetIndex(int.Parse(comands[0]), int.Parse(comands[1]), int.Parse(comands[2])));
        }

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(result[i] + " ");
        }
    }

    public class SubsegmentTree
    {
        private List<int>[] segments;

        private int size;

        public SubsegmentTree(int data)
        {
            segments = new List<int>[4 * data];
            size = data;
        }

        public List<int> Check(List<int> first, List<int> second)
        {
            List<int> temp;

            if (first.Count == 0 && second.Count != 0)
            {
                temp = new List<int>(second);

                return temp;
            }
            else if (first.Count != 0 && second.Count != 0)
            {
                temp = new List<int>(first);
                temp.AddRange(second);

                return temp;
            }

            temp = new List<int>(first);

            return temp;
        }

        public int GetIndex(int leftSide, int rightSide, int find)
        {
            bool trigger = true;
            List<int> buf = InnerGetIndex(0, 0, size, segments, leftSide - 1, rightSide, ref find, ref trigger);

            if (buf.Count < find)
            {
                return -1;
            }
            else
            {
                return buf.ElementAt(find - 1);
            }
        }

        public void Convert(string[] numbers)
        {
            Converting(0, 0, size, numbers);
        }

        private void Converting(int index, int left, int right, string[] numbers)
        {
            if (right - left == 1)
            {
                segments[index] = new List<int>();
                if (int.Parse(numbers[left]) == 0)
                {
                    segments[index].Add(left + 1);
                }

                return;
            }

            int half = (left + right) / 2;

            Converting((2 * index) + 1, left, half, numbers);
            Converting((2 * index) + 2, half, right, numbers);

            segments[index] = Check(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private List<int> InnerGetIndex(int index, int left, int right, List<int>[] segment, int leftSide, int rightSide, ref int find, ref bool trigger)
        {
            if (!trigger)
            {
                return new List<int>();
            }

            if (leftSide <= left && rightSide >= right)
            {
                return segment[index];
            }

            if (leftSide >= right || rightSide <= left)
            {
                return new List<int>();
            }

            int half = (left + right) / 2;
            List<int> leftResult = InnerGetIndex((2 * index) + 1, left, half, segment, leftSide, rightSide, ref find, ref trigger);

            if (leftResult.Count() != 0)
            {
                if (leftResult.Count() < find)
                {
                    find -= leftResult.Count();
                }
                else
                {
                    trigger = false;
                    return leftResult;
                }
            }

            List<int> rightResult = InnerGetIndex((2 * index) + 2, half, right, segment, leftSide, rightSide, ref find, ref trigger);

            if (rightResult.Count() != 0)
            {
                if (rightResult.Count() < find)
                {
                    find -= rightResult.Count();
                }
                else
                {
                    trigger = false;

                    return rightResult;
                }
            }

            return new List<int>();
        }
    }
}
