using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options
{
    public interface IFlexOptionsProvider
    {
        public T GetOptions<T>();
    }
}
