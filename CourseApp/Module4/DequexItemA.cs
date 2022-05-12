using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseApp.Module4
{
    public class DequexItemA<T>
    {
        public T Data { get; set; }

        public DequexItemA<T> Next { get; set; }

        public DequexItemA<T> Previous { get; set; }

/*        public DequexItem(T data)
        {
            Data = data;
        }*/

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
