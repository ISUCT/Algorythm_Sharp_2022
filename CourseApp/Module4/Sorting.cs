using System;

namespace CourseApp.Module4
{
    public class Sorting
    {
        public static void GetSorting()
        {
            var numberOfWagons = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            var sValues = s.Split(' ');
            var arrayWagons = new int[numberOfWagons];
            var answerArray = new int[numberOfWagons];
            for (int g = 0; g < numberOfWagons; g++)
            {
                arrayWagons[g] = int.Parse(sValues[g]);
            }

            int value1 = 0;
            int value2 = 0;

            while (value1 != numberOfWagons)
            {
                if (Stack.Empty() == true || (value2 < numberOfWagons && arrayWagons[value2] < Stack.Back()))
                {
                    Stack.Push(arrayWagons[value2]);
                    value2++;
                }
                else
                {
                    answerArray[value1] += Stack.Back();
                    Stack.Pop();
                    value1++;
                }
            }

            bool isAnswer = true;

            for (int g = 0; g < answerArray.Length - 1; g++)
            {
                if (answerArray[g] > answerArray[g + 1])
                {
                    isAnswer = false;
                }
            }

            if (isAnswer == true)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }

        private class Stack
        {
            private static int[] buffer = new int[100000001];
            private static int top = -1;

            public static void Push(int a)
            {
                top++;
                buffer[top] = a;
            }

            public static void Pop()
            {
                top--;
            }

            public static int Size()
            {
                return top + 1;
            }

            public static bool Empty()
            {
                return top == -1;
            }

            public static void Clear()
            {
                top = -1;
            }

            public static int Back()
            {
                return buffer[top];
            }
        }
    }
}
