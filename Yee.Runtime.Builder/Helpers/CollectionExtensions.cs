using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Runtime.Builder.Helpers
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                collection.Add(item);
            }
        }
    }
}
