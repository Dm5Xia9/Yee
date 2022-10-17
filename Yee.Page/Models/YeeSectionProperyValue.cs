using Ability.Core.Models;

namespace Yee.Page.Models
{
    public class YeeProperty : BaseRecord
    {
        public string Property { get; set; }
        public YeePropertyValue YeePropertyValue { get; set; }
        public YeeComponentValues YeeComponentValues { get; set; }
    }


    public class YeePropertyValue : BaseRecord
    {
        public string DisplayName { get; set; }
        public bool IsModelData { get; set; }
        public string Value { get; set; }
        public List<YeeProperty> YeeProperties { get; set; }
    }


}
