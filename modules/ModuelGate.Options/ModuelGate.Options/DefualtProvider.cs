using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuelGate.Options
{
    public class DefualtProvider : IFlexOptionsProvider
    {
        public T GetOptions<T>()
        {
            return Activator.CreateInstance<T>();
        }
    }
}
