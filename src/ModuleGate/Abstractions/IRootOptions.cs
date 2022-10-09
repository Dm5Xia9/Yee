using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Abstractions
{
    public interface IRootOptions
    {
        public void Set<T>(string key, T value);
        public T? Get<T>(string key);
    }
}
