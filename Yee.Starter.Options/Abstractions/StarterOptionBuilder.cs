using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Starter.Options.Abstractions
{
    public class StarterOptionBuilder
    {
    }
    public class StarterOption
    {
        public string DisplayName { get; set; }
        public Type ValueType { get; set; }
        public Action<string> IsActive { get; set; }
        
    }
}
