using Ability.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Yee.Page.Models
{
    public class YeeProperty : BaseRecord
    {
        public string Property { get; set; }
        public Guid YeePropertyValueId { get; set; }
        public YeePropertyValue YeePropertyValue { get; set; }
        public YeeComponentValues YeeComponentValues { get; set; }
    }


    public class YeePropertyValue : BaseRecord
    {
        [Column(TypeName = "jsonb")]
        public YeeCSharpLink PropertyType { get; set; } 
        public string DisplayName { get; set; }
        public bool IsModelData { get; set; }
        public string Value { get; set; }
        public List<YeeProperty> YeeProperties { get; set; }
    }


}
