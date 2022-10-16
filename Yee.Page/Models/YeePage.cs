using Ability.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Page.Models
{
    public class YeePage : BaseRecord
    {
        public string DisplayName { get; set; }

        [Column(TypeName = "jsonb")]
        public YeeCSharpLink RouterLink { get; set; }

        public string BodyId { get; set; }
        public string BodyClass { get; set; }

        [Column(TypeName = "jsonb")]
        public YeeCSharpLink StyleLink { get; set; }



        [Column(TypeName = "jsonb")]
        public YeeCSharpLink HeaderSectionLink { get; set; }

        [Column(TypeName = "jsonb")]
        public List<YeeSectionProperyValue> HeaderValues { get; set; }


        public List<YeeSectionValue> YeeSectionValues { get; set; }
            = new List<YeeSectionValue>();
    }

    public class YeeCSharpLink
    {
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }

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
