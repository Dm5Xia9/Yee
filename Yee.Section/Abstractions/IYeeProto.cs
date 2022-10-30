using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Section.Abstractions
{
    public interface IYeeProto<T> : IYeeProto
    {
        public T Value { get; internal set; }
    }

    public interface IYeeProto
    {
        public string DisplayName { get; set; }
        public void SetDefualtValue();
    }
}
