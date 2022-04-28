using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4
{
#pragma warning disable SA1649 // File name must match first type name
    public class Stack<T>
#pragma warning restore SA1649 // File name must match first type name
    {
        private List<T> items = new List<T>();

        public int Count => items.Count;

        public bool IsEmpty => items.Count == 0;

        public void Push(T item)
        {
            items.Add(item);
        }

        public T Pop()
        {
            if (!IsEmpty)
            {
                var item = items.LastOrDefault();
                var itemIndex = items.LastIndexOf(item);
                items.RemoveAt(itemIndex);
                return item;
            }
            else
            {
                throw new NullReferenceException("Stack clear");
            }
        }

        public T Peek()
        {
            if (!IsEmpty)
            {
                return items.LastOrDefault();
            }
            else
            {
                throw new NullReferenceException("Stack clear");
            }
        }

        public override string ToString()
        {
            return $"Stack element: {Count}";
        }
    }
}
