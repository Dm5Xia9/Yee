using Ability.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Page.Models
{
    public class YeeRoute : BaseRecord
    {
        public string LocalPath { get; set; }

        public string StaticContent { get; set; }

        public Guid? PageId { get; set; }
        public YeePage Page { get; set; }
    }
}
