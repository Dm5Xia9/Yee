using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Handlers;

namespace Yee.Section.Services
{

    public class SectionState
    {
        public SectionState()
        {
            ProtoHandlers = new ProtoHandlerCollection();
            Sections = new List<Type>();
        }

        public ProtoHandlerCollection ProtoHandlers { get; set; }

        public List<Type> Sections { get; set; }

        public SectionState AddSection<T>()
        {
            Sections.Add(typeof(T));
            return this;
        }
    }

    public class ProtoHandlerCollection : Dictionary<Type, Type>
    {

    }
}
