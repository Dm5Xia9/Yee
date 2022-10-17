using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Section.Abstractions
{
    public class BaseYeeProto<T> : IYeeProto<T>
    {
        public string DisplayName { get; set; }

        public T Value { get; set; }

        public virtual void SetDefualtValue()
        {
            Value = default;
        }

        public override string ToString()
        {
            return Value?.ToString() ?? "";
        }

    }
}
