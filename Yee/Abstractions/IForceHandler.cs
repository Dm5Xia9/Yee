using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Abstractions
{
    public interface IForceHandler
    {
        public void Up(IEnumerable<BaseYeeModule> modules);
    }
}
