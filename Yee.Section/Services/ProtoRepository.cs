using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Services
{
    public abstract class ProtoRepository
    {
        public abstract ProtoHeap GetPrototypesFromSectionValue(Guid id);


    }

    public class ProtoHeap
    {
        public List<ProtoMetaValue> Parameters { get; set; }
    }

    public class ProtoMetaValue
    {
        public string ProtoTypeName { get; set; }
        public object ProtoValue { get; set; }
        public List<ProtoMetaValue> ChildValues { get; set; }
    }
}
