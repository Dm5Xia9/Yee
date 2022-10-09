using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options
{
    public interface IFlexOptions<T>
    {
        public T Value { get; }
    }
}
