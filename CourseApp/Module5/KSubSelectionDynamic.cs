using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module5
{
    public class KSubSelectionDynamic
    {
        private static int[] Parse(string[] arrStr)
        {
            int[] arr = new int[arrStr.Length];
            for (int i = 0; i < arrStr.Length; i++)
            {
                arr[i] = int.Parse(arrStr[i]);
            }
            return arr;
        }
        public static void KSubSelectionDynamic_Main()
        {
            int length = int.Parse(Console.ReadLine());
            int[] arr = Parse(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            int naturalNumber = int.Parse(Console.ReadLine());
            DynamicSubSections tree = new DynamicSubSections(arr.Length);
            tree.Convert(arr);

            List<int> result = new List<int>();

            for (int i = 0; i < naturalNumber; i++)
            {
                string[] arrlrk = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (arrlrk[0] == "u")
                {
                    int first = int.Parse(arrlrk[1]);
                    int second = int.Parse(arrlrk[2]);
                    if ((arr[first - 1] != 0 && second == 0) || (arr[first - 1] == 0 && second != 0))
                    {
                        bool add_or_del = (arr[first - 1] != 0 && second == 0) ? true : false;
                        arr[first - 1] = second;
                        tree.Update(int.Parse(arrlrk[1]), add_or_del);
                    }
                }
                else
                    result.Add(tree.Geti(int.Parse(arrlrk[1]), int.Parse(arrlrk[2]), int.Parse(arrlrk[3])));

            }

            for (int i = 0; i < result.Count; i++)
            {
                Console.Write(result[i] + " ");
            }
        }
    }
    public class DynamicSubSections
    {
        public List<int>[] elements;

        public int size;

        public DynamicSubSections(int data)
        {
            elements = new List<int>[4 * data];
            size = data;
        }

        public void Update(int i, bool trigger)
        {
            int pos = 0;
            Updating(0, 0, size, elements, i - 1, trigger, ref pos);
        }
        public void Updating(int i, int l, int r, List<int>[] elements, int vdIndex, bool trigger, ref int pos)
        {
            if (r - l <= 1)
            {
                if (trigger)
                {
                    elements[i].Add(vdIndex + 1);
                }
                else
                {
                    elements[i] = new List<int>();
                }

                return;
            }

            int mid = (l + r) / 2;
            if (vdIndex < mid)
            {
                Updating((2 * i) + 1, l, mid, elements, vdIndex, trigger, ref pos);
                if (trigger)
                {
                    elements[i].Insert(pos, vdIndex + 1);
                }
                else
                {
                    elements[i].Remove(vdIndex + 1);
                }
            }
            else
            {
                Updating((2 * i) + 2, mid, r, elements, vdIndex, trigger, ref pos);
                if (trigger)
                {
                    if (elements[i].Count() == 0)
                    {
                        elements[i].Add(vdIndex + 1);
                    }
                    else if (elements[(2 * i) + 2].Count() == 1)
                    {
                        pos = elements[i].Count();
                        elements[i].Add(vdIndex + 1);
                    }
                    else
                    {
                        pos = elements[(2 * i) + 1].Count() + pos;
                        elements[i].Insert(pos, vdIndex + 1);
                    }
                }
                else
                {
                    elements[i].Remove(vdIndex + 1);
                }

            }
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

        public void Convert(int[] arr)
        {
            Converting(0, 0, size, arr);
        }
        private void Converting(int i, int l, int r, int[] arr)
        {
            if (r - l == 1)
            {
                elements[i] = new List<int>();
                if (arr[l] == 0)
                {
                    elements[i].Add(l + 1);
                }

                return;
            }

            int mid = (l + r) / 2;

            Converting((2 * i) + 1, l, mid, arr);
            Converting((2 * i) + 2, mid, r, arr);
            elements[i] = new List<int>(elements[(2 * i) + 1]);
            elements[i].AddRange(elements[(2 * i) + 2]);
        }
    }
}
