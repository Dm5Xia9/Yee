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
        public YeeCSharpLink RouterLink { get; set; }

        public string BodyId { get; set; }
        public string BodyClass { get; set; }

        [Column(TypeName = "jsonb")]
        public YeeCSharpLink StyleLink { get; set; }
        public List<YeeComponentValues> YeeComponents { get; set; }
            = new List<YeeComponentValues>();
    }
}
