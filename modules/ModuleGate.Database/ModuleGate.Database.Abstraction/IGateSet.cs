using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleGate.Database.Abstraction
{
    public interface IGateSet<T> : IQueryable<T> where T : class
    {

    }
}
