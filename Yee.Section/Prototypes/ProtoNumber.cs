using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Prototypes
{
    public class ProtoNumber : BaseYeeProto<decimal>
    {
        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
