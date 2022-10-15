using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Yee.Section.Prototypes;

namespace Yee.Section.Navigation
{
    public interface IMenuItem
    {
        string Title { get; }
        ProtoLink Link { get; }
        string Icon { get; }
        bool IsActive(string currentUri);
    }

    public interface IActionMenuItem : IMenuItem
    {


    }
    
    public interface IGroupMenuItem : IMenuItem
    {
        bool HasChilds { get; }
        IEnumerable<IMenuItem> ChildItems { get; }
    }
}
