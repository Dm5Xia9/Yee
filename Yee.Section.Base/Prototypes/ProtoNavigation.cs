using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yee.Section.Abstractions;

namespace Yee.Section.Base
{
    public class ProtoNavigation : BaseYeeProto<List<NavMenuItem>>
    {

    }

    public class NavMenuItem
    {
        public string Title { get; set; }

        public string Link { get; set; }

        public string Icon { get; set; }

        public bool IsGroup => ChildItems != null;

        public bool HasChilds => ChildItems?.Count() > 0;
        public List<NavMenuItem> ChildItems { get; set; }

        public bool IsActive(string currentUri, bool isShortUri = false)
        {
            if (isShortUri)
                return currentUri == Link;
            var uri = new Uri(currentUri);
            return uri.LocalPath == Link;
        }

        public bool IsActive(string currentUri)
        {
            var uri = new Uri(currentUri);
            return uri.LocalPath == Link;
        }
    }


}
