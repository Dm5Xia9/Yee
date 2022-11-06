using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Abstractions;

namespace Yee.Abstractions
{
    public interface IYeeProvider<out T> where T:
        BaseYeeModule
    {
        public IEnumerable<BaseYeeModule> Resolve();
    }



}
