using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Base
{
    public class ProtoTextArea : BaseYeeProto<string>
    {
        public override string ToString()
        {
            return Value;
        }
    }
}
