using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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

        public SectionState AddPrototype<TProto, THandler>()
        {
            if (ProtoHandlers.ContainsKey(typeof(TProto)))
            {
                ProtoHandlers[typeof(TProto)].Handlers.Add(typeof(THandler));
                return this;
            }

            ProtoHandlers.Add(typeof(TProto), new ProtoDescriptor
            {
                Proto = typeof(TProto),
                Handlers = new List<Type> { typeof(THandler) }
            });

            return this;
        }
    }

    public class ProtoHandlerCollection : Dictionary<Type, ProtoDescriptor>
    {

    }

    public class ProtoDescriptor
    {
        public ProtoDescriptor()
        {
            Handlers = new List<Type>();
        }

        public Type Proto { get; set; }
        public List<Type> Handlers { get; set; }
    }
}
