using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Yee.Section.Abstractions;

namespace Yee.Section.Extensions
{
    public static class SectionHelper
    {

        public static SectionInfo Analyze(Type type)
        {
            var sectionInfo = new SectionInfo();

            sectionInfo.Type = type;
            sectionInfo.Parameters = new List<SectionParameter>();
            foreach (var param in type.GetProperties()
                .Where(p => p.CustomAttributes.Any(p => p.AttributeType == typeof(ParameterAttribute))))
            {
                var par = new SectionParameter();

                par.Name = param.Name;
                par.DisplayName = param.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                par.ParamType = param.PropertyType;
                sectionInfo.Parameters.Add(par);
            }

            return sectionInfo;
        }
    }
}
