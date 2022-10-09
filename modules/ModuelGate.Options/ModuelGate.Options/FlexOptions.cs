using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options
{
    public class FlexOptions<T> : IFlexOptions<T>
    {
        private readonly T _value;

        public FlexOptions(T value)
        {
            _value = value;
        }

        public T Value => _value;
    }
}
