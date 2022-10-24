using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.DynamicRouters.Models
{
    public class YeeRoute : BaseRecord
    {
        public string LocalPath { get; set; }

        public string StaticContent { get; set; }
    }
}
