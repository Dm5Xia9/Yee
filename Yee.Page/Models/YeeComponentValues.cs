using Ability.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Yee.Page.Models
{
    public class YeeComponentValues : BaseRecord
    {
        [Column(TypeName = "jsonb")]
        public YeeCSharpLink ComponentRef { get; set; }

        public List<YeeProperty> Properties { get; set; }

        public List<YeePage> Pages { get; set; }

        public bool IsHeader { get; set; }
        public Dictionary<string, JObject> ToDictionary()
        {
            return Properties?.ToDictionary(p => p.Property, p => Newtonsoft.Json.Linq.JObject.Parse(p.YeePropertyValue.Value));
        }
    }
}
