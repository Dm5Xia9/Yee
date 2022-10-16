using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Yee.Section.Prototypes;

namespace Yee.Section.Navigation
{
    public class ActionMenuItem : IActionMenuItem
    {
        public string Title { get; set; }

        public ProtoLink Link { get; set; }

        public string Icon { get; set; }
        public ActionMenuItem()
        {
        }
        public bool IsActive(string currentUri, bool isShortUri = false)
        {
            if(isShortUri)
                return currentUri == Link.Value;
            var uri = new Uri(currentUri);
            return uri.LocalPath == Link.Value;
        }

        public override string ToString()
        {
            return $"{Title}:{Link?.Value}";
        }

    }
}
