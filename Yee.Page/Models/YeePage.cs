using Ability.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Page.Models
{
    public class YeePage : BaseRecord
    {
        public string DisplayName { get; set; }

        [Column(TypeName = "jsonb")]
        public PageDbContext RouterLink { get; set; }

        public List<YeeSectionValue> YeeSectionValues { get; set; }
    }

    public class YeeCSharpLink
    {
        public string AssemblyName { get; set; }
        public string TypeName { get; set; }
    }
}
