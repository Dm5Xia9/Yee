using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Loader;
using System.Text.Json.Serialization;

namespace Yee.Page.Models
{
    public class YeeCSharpLink
    {
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }


        [NotMapped]
        [JsonIgnore]
        public Type Type => ToType();

        public static YeeCSharpLink FromType(Type type)
        {
            var link = new YeeCSharpLink();
            if(type == null)
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
