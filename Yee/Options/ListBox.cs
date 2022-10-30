using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Options
{
    public class ListBox<T>
    {
        public ListBox()
        {
            Value = new List<T>();
        }

        public List<T> Value { get; init; }
    }
}
