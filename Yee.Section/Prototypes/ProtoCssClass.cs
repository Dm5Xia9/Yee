using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Prototypes
{
    public class ProtoCssClass : BaseYeeProto<List<string>>
    {
        public override string ToString()
        {
            return string.Join(" ", this.Value);
        }

        public static ProtoCssClass Instance(params string[] clases)
        {
            return new ProtoCssClass
            {
                Value = clases.ToList()
            };
        }
    }
}
