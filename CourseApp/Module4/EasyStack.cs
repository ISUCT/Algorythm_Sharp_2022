using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class EasyStack<T>
    {
        private List<T> items = new List<T>();

        private int sizze = 0;

        public int Count => items.Count;

        public bool Isempty => items.Count == 0;

        public int Size()
        {
            return sizze;
        }

        public void Push(T item)
        {
            items.Add(item);
            sizze++;
        }

       public T POP()
       {
            if (!Isempty)
            {
                var item = items.LastOrDefault();
                var itemsIndex = items.LastIndexOf(item);
                items.RemoveAt(itemsIndex);
                sizze--;
                return item;
            }
            else
            {
                throw new NullReferenceException("stack off");
            }
       }

        public T Peek()
        {
            if (!Isempty)
            {
                return items.LastOrDefault();
            }
            else
            {
                throw new NullReferenceException("stack off");
            }
        }
    }
}
