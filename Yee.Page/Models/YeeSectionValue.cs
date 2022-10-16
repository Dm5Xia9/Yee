using Ability.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yee.Page.Models
{
    public class YeeSectionValue : BaseRecord
    {
        [Column(TypeName = "jsonb")]
        public YeeCSharpLink SectionLink { get; set; }

        [Column(TypeName = "jsonb")]
        public List<YeeSectionProperyValue> Values { get; set; }


        public YeePage YeePage { get; set; }
        public long YeePageId { get; set; }
    }

    public class YeeSectionProperyValue
    {
        public string Property { get; set; }
        public string Value { get; set; }
    }
}
