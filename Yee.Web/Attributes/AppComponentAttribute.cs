using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Web.Attributes
{
    public class AppComponentAttribute : Attribute
    {
        public bool Router { get; set; }
    }
}
