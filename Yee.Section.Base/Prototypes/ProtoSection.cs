using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Base
{
    public class ProtoSection : BaseYeeProto<SectionInfoLink>
    {

    }

    public class SectionInfoLink
    {
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }


        [NotMapped]
        [JsonIgnore]
        public Type Type => ToType();

        public static SectionInfoLink FromType(Type type)
        {
            var link = new SectionInfoLink();
            if (type == null)
                return link;
            link.AssemblyName = type.Assembly.GetName().Name;
            link.TypeName = type.Name;

            return link;
        }

        public Type ToType()
        {
            var all = AssemblyLoadContext.All
                .SelectMany(p => p.Assemblies);

            var assembly = all.FirstOrDefault(p => p.GetName().Name == AssemblyName);
            if (assembly == null)
                return null;

            return assembly.GetTypes().FirstOrDefault(p => p.Name == TypeName);

        }
    }
}
