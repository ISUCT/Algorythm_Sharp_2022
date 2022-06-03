using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class KSubSection
    {
        public static void KSubSection_Main()
        {
            int length = int.Parse(Console.ReadLine());
            string[] arr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int naturalNumber = int.Parse(Console.ReadLine());

            SubSections tree = new SubSections(arr.Length);
            tree.Convert(arr);

            List<int> result = new List<int>();

            for (int i = 0; i < naturalNumber; i++)
            {
                string[] arrlrk = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                result.Add(tree.Geti(int.Parse(arrlrk[0]), int.Parse(arrlrk[1]), int.Parse(arrlrk[2])));
            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
    public class SubSections
    {
        private List<int>[] elements;

        private int size;

        public SubSections(int data)
        {
            elements = new List<int>[4 * data];
            size = data;
        }
        public List<int> Check(List<int> first, List<int> second)
        {
            List<int> list;

            if (first.Count == 0 && second.Count != 0)
            {
                list = new List<int>(second);

                return list;
            }
            else if (first.Count != 0 && second.Count != 0)
            {
                list = new List<int>(first);
                list.AddRange(second);

                return list;
            }

            list = new List<int>(first);

            return list;
        }
        public int Geti(int lSide, int rSide, int k)
        {
            bool trigger = true;
            List<int> list = Getingi(0, 0, size, elements, lSide - 1, rSide, ref k, ref trigger);

            if (list.Count < k)
            {
                return -1;
            }
            else
            {
                return list.ElementAt(k - 1);
            }
        }
        private List<int> Getingi(int i, int l, int r, List<int>[] elements, int lSide, int rSide, ref int k, ref bool trigger)
        {
            if (!trigger)
            {
                return new List<int>();
            }

            if (lSide <= l && rSide >= r)
            {
                return elements[i];
            }

            if (lSide >= r || rSide <= l)
            {
                return new List<int>();
            }

            int mid = (l + r) / 2;
            List<int> lResult = Getingi((2 * i) + 1, l, mid, elements, lSide, rSide, ref k, ref trigger);

            if (lResult.Count() != 0)
            {
                if (lResult.Count() < k)
                {
                    k -= lResult.Count();
                }
                else
                {
                    trigger = false;
                    return lResult;
                }
            }

            List<int> rResult = Getingi((2 * i) + 2, mid, r, elements, lSide, rSide, ref k, ref trigger);

            if (rResult.Count() != 0)
            {
                if (rResult.Count() < k)
                {
                    k -= rResult.Count();
                }
                else
                {
                    trigger = false;

                    return rResult;
                }
            }

            return new List<int>();
        }

        public void Convert(string[] arrStr)
        {
            Converting(0, 0, size, arrStr);
        }
        private void Converting(int i, int l, int r, string[] arrStr)
        {
            if (r - l == 1)
            {
                elements[i] = new List<int>();
                if (int.Parse(arrStr[l]) == 0)
                {
                    elements[i].Add(l + 1);
                }

                return;
            }

            int mid = (l + r) / 2;

            Converting((2 * i) + 1, l, mid, arrStr);
            Converting((2 * i) + 2, mid, r, arrStr);

            elements[i] = Check(elements[(2 * i) + 1], elements[(2 * i) + 2]);
        }
    }
}
