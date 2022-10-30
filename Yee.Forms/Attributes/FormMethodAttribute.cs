using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Yee.Forms.Attributes
{
    public class FormMethodAttribute : Attribute
    {
        public FormMethodAttribute(string method)
        {
            Method = method;
        }

        public string Method { get; set; }
    }

    public class FormGetMethodAttribute : FormMethodAttribute
    {
        public FormGetMethodAttribute() : base(HttpConst.GET)
        {
        }
    }

    public class FormPostMethodAttribute : FormMethodAttribute
    {
        public FormPostMethodAttribute() : base(HttpConst.POST)
        {

        }
    }

    /// <summary>
    /// Проверьте свою форму по маршруту /debug-forms/{<paramref name="FriendlyName" />}/
    /// </summary>
    public class DebugFormAttribute : Attribute
    {
        public DebugFormAttribute(string friendlyName)
        {
            FriendlyName = friendlyName;
        }

        public string FriendlyName { get; set; }

    }

}
