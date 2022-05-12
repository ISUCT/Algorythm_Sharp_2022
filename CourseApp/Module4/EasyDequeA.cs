using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class EasyDequeA<T>
    {
        private List<T> items = new List<T>();

        private T Head => items.Last();

        private T Tail => items.First();

        public int Size()
        {
            return items.Count;
        }

        public void PushBack(T data)
        {
            items.Insert(0, data);
        }

        public void PushFront(T data)
        {
            items.Add(data);
        }

        public T POPback()
        {
            var item = Tail;
            items.Remove(item);
            return item;
        }

        public T POPfront()
        {
            var item = Head;
            items.Remove(item);
            return item;
        }

        public T PeekBack()
        {
            return Tail;
        }

        public T PeekFront()
        {
            return Head;
        }

        public T Min()
        {
            return items.Min();
        }
    }
}
