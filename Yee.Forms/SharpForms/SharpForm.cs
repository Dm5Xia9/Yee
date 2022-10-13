using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Yee.Forms.Abstractions;

namespace Yee.Forms.SharpForms
{
    public class SharpForm : YeeForm<SharpFormArg>
    {
        public string? DebugName { get; set; }
        public Type Type { get; set; }
        public List<Attribute> Attributes { get; set; }
    }

    public class SharpFormArg : YeeFormArg
    {
        public PropertyInfo Property { get; set; }
        public List<Attribute> Attributes { get; set; }
    }
}
