using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class NODSubSectionDynamic
    {
        public static void NODSubSectionDynamic_Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int naturalNumber = int.Parse(Console.ReadLine());

            DynamicSubSections tree = new DynamicSubSections(arr.Length);
            tree.Convert(arr);

            List<int> result = new List<int>();

            for (int i = 0; i < naturalNumber; i++)
            {
                string[] arrlr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (arrlr[0] == "u")
                {
                    tree.Update(int.Parse(arrlr[1]), int.Parse(arrlr[2]));
                }
                else
                    result.Add(tree.GetNOD(int.Parse(arrlr[1]), int.Parse(arrlr[2])));
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + " ");
            }
        }

        public class DynamicSubSections
        {
            private int[] elements;

            private int size;

            public DynamicSubSections(int data)
            {
                elements = new int[4 * data];
                size = data;
            }

            public void Convert(string[] arrStr)
            {
                Converting(0, 0, size, arrStr);
            }

            public int GetNOD(int lSide, int last)
            {
                return GetNOD(0, 0, size, elements, lSide - 1, last);
            }
            public void Update(int i, int arr)
            {
                Updating(0, 0, size, elements, i - 1, arr);
            }
            private void Updating(int i, int l, int r, int[] elements, int vdIndex, int arr)
            {
                if (r - l == 1)
                {
                    elements[i] = arr;
                    return;
                }

                int mid = (l + r) / 2;
                if (vdIndex < mid)
                {
                    Updating((2 * i) + 1, l, mid, elements, vdIndex, arr);
                }
                else
                {
                    Updating((2 * i) + 2, mid, r, elements, vdIndex, arr);
                }

                elements[i] = NOD(elements[(2 * i) + 1], elements[(2 * i) + 2]);
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

            private void Converting(int i, int l, int r, string[] arrStr)
            {
                if (r - l == 1)
                {
                    elements[i] = int.Parse(arrStr[l]);
                    return;
                }

                int mid = (l + r) / 2;

                Converting((2 * i) + 1, l, mid, arrStr);
                Converting((2 * i) + 2, mid, r, arrStr);

                elements[i] = NOD(elements[(2 * i) + 1], elements[(2 * i) + 2]);
            }

            private int GetNOD(int i, int l, int r, int[] elements, int lSide, int rSide)
            {
                if (lSide <= l && rSide >= r)
                {
                    return elements[i];
                }

                if (lSide >= r || rSide <= l)
                {
                    return 0;
                }

                int mid = (l + r) / 2;
                int lResult = GetNOD((2 * i) + 1, l, mid, elements, lSide, rSide);
                int rResult = GetNOD((2 * i) + 2, mid, r, elements, lSide, rSide);

                return NOD(lResult, rResult);
            }
        }
    }
}
