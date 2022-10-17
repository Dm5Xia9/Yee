
////using System;
////using System.Collections.Generic;
////using System.Drawing;
////using System.Linq;
////using System.Text;
////using Yee.Section.Prototypes;

////namespace Yee.Section.Navigation
////{
////    public class GroupMenuItem : IGroupMenuItem
////    {
////        public string Title { get; set; }

////        public bool HasChilds => ChildItems.Count() > 0;
////        public List<IMenuItem> ChildItems { get; set; }

////        public ProtoLink Link { get; set; }

////        public string Icon { get; set; }

//<<<<<<< HEAD
////        public bool IsActive(string currentUri)
////        {
////            var uri = new Uri(currentUri);
////            return uri.LocalPath == Link.Value;
////        }
//=======
//        public bool IsActive(string currentUri, bool isShortUri = false)
//        {
//            var uri = new Uri(currentUri);
//            return uri.LocalPath == Link.Value;
//        }
//>>>>>>> origin/mikhail-yee

////        public override string ToString()
////        {
////            return $"[Group: {ChildItems.Count()}]";
////        }
////    }
////}
