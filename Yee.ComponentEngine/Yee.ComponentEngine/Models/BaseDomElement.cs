using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yee.ComponentEngine.Models
{
    public class BaseDomElement : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }
        [Parameter]
        public Dictionary<string, string> Attributes { get; set; } = new();
        [Parameter]
        public List<RenderFragment> Childs { get; set; } = new List<RenderFragment>();
        [Parameter]
        public string InnerHtml { get; set; }
        public static readonly string TagName = "Base";
    }
}
