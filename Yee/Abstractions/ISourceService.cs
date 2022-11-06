using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Abstractions
{
    public interface ISourceService
    {
        public void Set<T>(Func<IYeeSource<T>> source);
        public IYeeSource<T> Get<T>() where T: class;
    }
}
