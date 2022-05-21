using System;
using System.Collections.Generic;

public class NOD_OnSegments
{
    public static void NOD_OnSegmentsMethod()
    {
        int size = int.Parse(Console.ReadLine());
        string[] elements = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int numberOfRequests = int.Parse(Console.ReadLine());

        Segment tree = new Segment(size);
        tree.Convert(elements);

        List<int> result = new List<int>();

        for (int i = 0; i < numberOfRequests; i++)
        {
            string[] borders = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            result.Add(tree.GetNOD(int.Parse(borders[0]), int.Parse(borders[1])));
        }

        for (int i = 0; i < result.Count; i++)
        {
            Console.Write(result[i]);
        }
    }

    public class Segment
    {
        private int[] segments;

        private int size;

        public Segment(int data)
        {
            segments = new int[4 * data];
            size = data;
        }

        public void Convert(string[] elements)
        {
            Converting(0, 0, size, elements);
        }

        public int GetNOD(int leftSide, int lastRequest)
        {
            return GettingNOD(0, 0, size, segments, leftSide - 1, lastRequest);
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

        private void Converting(int index, int left, int right, string[] elements)
        {
            if (right - left == 1)
            {
                segments[index] = int.Parse(elements[left]);
                return;
            }

            int half = (left + right) / 2;

            Converting((2 * index) + 1, left, half, elements);
            Converting((2 * index) + 2, half, right, elements);

            segments[index] = NOD(segments[(2 * index) + 1], segments[(2 * index) + 2]);
        }

        private int GettingNOD(int index, int left, int right, int[] segment, int leftSide, int rightSide)
        {
            if (leftSide <= left && rightSide >= right)
            {
                return segment[index];
            }

            if (leftSide >= right || rightSide <= left)
            {
                return 0;
            }

            int average = (left + right) / 2;
            int leftResult = GettingNOD((2 * index) + 1, left, average, segment, leftSide, rightSide);
            int rightResult = GettingNOD((2 * index) + 2, average, right, segment, leftSide, rightSide);

            return NOD(leftResult, rightResult);
        }
    }
}