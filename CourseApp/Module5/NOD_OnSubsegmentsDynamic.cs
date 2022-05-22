using System;
using System.Collections.Generic;

public class NOD_OnSubsegmentsDynamic
{
    public static void NOD_OnSubsegmentsDynamicMethod()
    {
        int size = int.Parse(Console.ReadLine());
        string[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int requests = int.Parse(Console.ReadLine());
        List<int> result = new List<int>();

        DynamicSegment tree = new DynamicSegment(size);
        tree.Convert(elements);

        for (int i = 0; i < requests; i++)
        {
            string[] borders = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (borders[0] == "u")
            {
                tree.Update(int.Parse(borders[1]), int.Parse(borders[2]));
            }
            else
            {
                result.Add(tree.GetNOD(int.Parse(borders[1]), int.Parse(borders[2])));
            }
        }

        Console.WriteLine(string.Join(" ", result));
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

        public int NOD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }

        public void Convert(string[] elements)
        {
            Converting(0, 0, size, elements);
        }

        public int GetNOD(int leftRequest, int rightRequest)
        {
            return GettingNOD(0, 0, size, segments, leftRequest - 1, rightRequest);
        }

        public void Update(int index, int value)
        {
            Updating(0, 0, size, segments, index - 1, value);
        }

        private void Updating(int index, int left, int right, int[] segment, int vdIndex, int value)
        {
            if (right - left == 1)
            {
                segments[index] = value;
                return;
            }

            int h = (left + right) / 2;
            if (vdIndex < h)
            {
                Updating((2 * index) + 1, left, h, segment, vdIndex, value);
            }
            else
            {
                Updating((2 * index) + 2, h, right, segment, vdIndex, value);
            }

            segments[index] = NOD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private int GettingNOD(int index, int left, int right, int[] segment, int leftRequest, int rightRequest)
        {
            if (leftRequest <= left && rightRequest >= right)
            {
                return segment[index];
            }

            if (leftRequest >= right || rightRequest <= left)
            {
                return 0;
            }

            int h = (left + right) / 2;
            int conclusion_left = GettingNOD((2 * index) + 1, left, h, segment, leftRequest, rightRequest);
            int conclusion_right = GettingNOD((2 * index) + 2, h, right, segment, leftRequest, rightRequest);
            return NOD(conclusion_left, conclusion_right);
        }

        private void Converting(int index, int left, int right, string[] elements)
        {
            if (right - left == 1)
            {
                segments[index] = int.Parse(elements[left]);
                return;
            }

            int h = (left + right) / 2;
            Converting((2 * index) + 1, left, h, elements);
            Converting((2 * index) + 2, h, right, elements);
            segments[index] = NOD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }
    }
}